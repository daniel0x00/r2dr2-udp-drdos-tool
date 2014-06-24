using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//# Custom imports:
using System.Net;
using System.Net.Sockets;
using System.IO;

using PcapDotNet.Packets.Ethernet;
using PcapDotNet.Packets;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets.Transport;
using PcapDotNet.Core;

namespace UDPRequester
{
    class UDPRequest
    {
        //# Global vars:
        private int eth;
        private string ip_origen;
        private string ip_destino;
        private int puerto_origen;
        private int puerto_destino;
        private string mac_origen;
        private string mac_destino;
        private int intentos;

        private PacketDevice selectedDevice;
        private List<string> paquete;

        public UDPRequest(int eth, string ip_origen, int puerto_origen, string mac_origen, string ip_destino, int puerto_destino, string mac_destino, int intentos)
        {
            this.eth = eth;
            this.ip_origen = ip_origen;
            this.puerto_origen = puerto_origen;
            this.mac_origen = mac_origen;
            this.ip_destino = ip_destino;
            this.puerto_destino = puerto_destino;
            this.mac_destino = mac_destino;
            this.intentos = intentos;

            seleccionaInterface();
        }
        ~UDPRequest() { }

        private void seleccionaInterface()
        {
            //# Selecciona la interfaz a usarse para el envío de paquetes
            //# Error conocido: PacketGetAdapterNames: El área de datos transferida a una llamada del sistema es demasiado pequeña. (122)
            //# Al haber muchos threads intentando acceder al listado de recursos del sistema (listado de tarjetas de red), el driver WinPcap no siempre contesta bien.
            //# Por lo tanto se para el thread e intenta nuevamente en 200 milisegundos.
            try
            {
                
                IList<LivePacketDevice> allDevices = LivePacketDevice.AllLocalMachine;
                this.selectedDevice = allDevices[this.eth];
            }
            catch (InvalidOperationException) { System.Threading.Thread.Sleep(200); seleccionaInterface(); }
        }

        public void EnviaMensaje(List<string> paquete)
        {
            this.paquete = paquete;

            //# Previene errores en envío de paquete. NO HAY gestión de errores porque si se produce un error en el envío de paquete, debe seguir al siguiente. 
            //# El usuario debe fijarse si se produce muchas excepciones de golpe para detener el proceso o dejarlo seguir:
            try
            {
                using (PacketCommunicator communicator = this.selectedDevice.Open(10, PacketDeviceOpenAttributes.None, 1))
                {
                    int contador_de_intentos = 1;
                    do
                    {
                        foreach (string hex in this.paquete)
                        {
                            communicator.SendPacket(BuildUdpPacket(this.StringToByteArray(hex)));
                            Intercambio.cantidad_peticiones_enviadas++;
                        }
                        contador_de_intentos++;
                    } while (contador_de_intentos <= this.intentos);

                }
            }
            catch { Intercambio.cantidad_excepciones++; }
        }

        //# Método de pcapDotNet, construcción de paquete IP, UDP, Ethernet y finalmente payload:
        private Packet BuildUdpPacket(byte[] bytes_a_enviar)
        {
            EthernetLayer ethernetLayer = new EthernetLayer
            {
                Source = new MacAddress(this.mac_origen),
                Destination = new MacAddress(this.mac_destino),
                EtherType = EthernetType.IpV4,
            };

            IpV4Layer ipV4Layer = new IpV4Layer
            {
                Source = new IpV4Address(this.ip_origen),
                CurrentDestination = new IpV4Address(this.ip_destino),
                Fragmentation = IpV4Fragmentation.None,
                HeaderChecksum = null,
                Identification = 123,
                Options = IpV4Options.None,
                Protocol = null, 
                Ttl = 100,
                TypeOfService = 0,
            };

            UdpLayer udpLayer = new UdpLayer
            {
                SourcePort = (ushort)this.puerto_origen,
                DestinationPort = (ushort)this.puerto_destino,
                Checksum = null, 
                CalculateChecksumValue = true,
            };

            PayloadLayer payloadLayer = new PayloadLayer
            {
                Data = new Datagram(bytes_a_enviar),
            };

            PacketBuilder builder = new PacketBuilder(ethernetLayer, ipV4Layer, udpLayer, payloadLayer);

            return builder.Build(DateTime.Now);
        }

        //# Método de stackoverflow.com:
        private byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }


}
