using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text.RegularExpressions;

using Newtonsoft.Json;

using PcapDotNet.Packets.Ethernet;
using PcapDotNet.Packets;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets.Transport;
using PcapDotNet.Core;

namespace UDPRequester
{
    public partial class FormBase : Form
    {
        //# Global vars, threads y timers:
        private System.Timers.Timer timer_check;
        private Thread thread_escucha_puerto_modo_pivote;
        private Thread thread_check_respuesta;
        private Thread thread_lanza_peticiones;

        //# Global vars de gestión del archivo JSON config:
        private bool archivo_json_config_correcto = false;
        private RootObject json_root;

        public FormBase()
        {
            InitializeComponent();
        }


        //# 
        //# Eventos del diseñador:
        //#


        private void FormBase_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            #region Muestra la lista de interfaces
            //# Código de la documentación de pcapDotNet:
            try
            {
                IList<LivePacketDevice> allDevices = LivePacketDevice.AllLocalMachine;
                if (allDevices.Count == 0)
                {
                    MessageBox.Show("No hay interfaces disponibles. No se puede continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    buttonCargarJSON.Enabled = false;
                    return;
                }

                var lista_ips_interface = new List<string>();
                for (int i = 0; i != allDevices.Count; i++)
                {
                    LivePacketDevice device = allDevices[i];
                    for (int x = 0; x != device.Addresses.Count; x++)
                    {
                        //# Regex para filtrar por tipo de interface:
                        if (Regex.IsMatch(device.Addresses[x].Address.ToString(), @"(?:[0-9]{1,3}\.){3}[0-9]{1,3}"))
                        {
                            lista_ips_interface.Add(Regex.Match(device.Addresses[x].Address.ToString(), @"(?:[0-9]{1,3}\.){3}[0-9]{1,3}").Groups[0].Value);
                        }
                        else { lista_ips_interface.Add("No IPv4: " + device.Addresses[x].Address.ToString()); }
                        

                        //# Muestra interfaces sin filtro previo:
                        //lista_ips_interface.Add(device.Addresses[x].Address.ToString());
                    }
                    comboBoxInterfaces.Items.Add(i.ToString() + " - " + string.Join(", ", lista_ips_interface));
                    device = null;
                }
                
                comboBoxInterfaces.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar interfaces. No se puede continuar. Verifique la presencia de WinPcap instalado en el equipo.\n\nExcepción:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonCargarJSON.Enabled = false;
                return;
            }
            #endregion

            #region Lanza thread de apertura de puerto de escucha
            this.thread_escucha_puerto_modo_pivote = new Thread(thread_escucha_puerto_udp_modo_pivote);
            this.thread_escucha_puerto_modo_pivote.Start();
            #endregion

            #region Intenta cargar un archivo por defecto llamado "config.txt" en la ruta del ejecutable
            if (!archivo_json_config_correcto)
            {
                string archivo_automatico = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "config.txt");
                if (File.Exists(archivo_automatico)) { this.archivo_json_config_correcto = cargaArchivoJSON(archivo_automatico); }
            }
            #endregion
        }

        private void FormBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.timer_check != null) { this.timer_check.Stop(); this.timer_check.Close(); }
            if (this.thread_check_respuesta != null) { this.thread_check_respuesta.Abort(); }
            if (this.thread_escucha_puerto_modo_pivote != null) { this.thread_escucha_puerto_modo_pivote.Abort(); }
        }

        private void buttonCargarJSON_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Todos los archivos (*.*)|*.*";
            dialog.Title = "Selecciona archijo JSON compatible";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (!File.Exists(dialog.FileName)) { MessageBox.Show("El archivo JSON no existe:\n\n" + dialog.FileName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                this.archivo_json_config_correcto = cargaArchivoJSON(dialog.FileName, true);
            }
            else { buttonEmpezar.Enabled = false; }

            this.Cursor = Cursors.Default;
            Application.DoEvents();
        }

        private void buttonEmpezar_Click(object sender, EventArgs e)
        {
            empiezaLanzadorDePeticiones();
        }

        private void comboBoxInterfaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            string interfaz_ip = comboBoxInterfaces.Text;

            if (Regex.IsMatch(interfaz_ip, @"(\d{1,2} \-)"))
            {
                Intercambio.interfaz = Convert.ToInt32(Regex.Match(interfaz_ip, @"(\d{1,2}) \-").Groups[1].Value);
            }
        }

        private void toolStripButtonControlarPivotes_Click(object sender, EventArgs e)
        {
            Form_Pivotes pivotes = new Form_Pivotes();
            pivotes.Show();
        }


        //# 
        //# Threads y timers de gestión:
        //#


        private void thread_escucha_puerto_udp_modo_pivote()
        {
            int udp_puerto_escucha = 9000;
            byte[] data = new byte[1024];

            try
            {
                IPEndPoint ip_endpoint_listener = new IPEndPoint(IPAddress.Any, udp_puerto_escucha);
                UdpClient udp_client = new UdpClient(ip_endpoint_listener);
                IPEndPoint ip_endpoint_sender = new IPEndPoint(IPAddress.Any, udp_puerto_escucha);

                //# Modifica el formulario para indicar que puerto abierto está OK:
                labelEscuchaEnUDP.Text = "Escuchando: OK";

                while (udp_puerto_escuchando)
                {
                    data = udp_client.Receive(ref ip_endpoint_sender);
                    string texto_recibido = Encoding.ASCII.GetString(data, 0, data.Length);

                    if (texto_recibido == "empiezaLanzadorDePeticiones") { empiezaLanzadorDePeticiones(); }
                }
            }
            //# Si se produce un error en cualquier momento de la lectura del puerto (puede ser en cualquier momento por el bloqueo de algún programa tercero), cambio el label a "ERROR".
            catch { labelEscuchaEnUDP.Text = "Escuchando: ERROR"; }
        }
        
        private void thread_lanzador_de_request_Fired()
        {
            int cantidad_threads_maximo = Intercambio.cantidad_threads_maximo;

            //# Bucle de peticiones. Empieza por la petición 1 hasta la última:
            for (int x = 0; x < json_root.peticion.Count; x++)
            {
                //# Verifica si hay threads disponibles para hacer un lanzamiento, de lo contrario espera un segundo para volver a verificar:
                while (Intercambio.cantidad_threads_activos > cantidad_threads_maximo)
                {
                    Thread.Sleep(100);
                }

                Thread thread_request = new Thread(new ParameterizedThreadStart(lanzaRequest));
                thread_request.Start(json_root.peticion[x]);
            }

        }

        private void lanzaRequest(object objeto_peticion)
        {
            //# Libera recurso para que se ejecute el multi-threading:
            Thread.Sleep(1);

            //# Flag para cantidad de threads:
            Intercambio.cantidad_threads_activos++;

            Peticion peticion = (Peticion)objeto_peticion;
            string json_ip_destino = peticion.ip_destino.Split(':')[0];
            int json_puerto_destino = Convert.ToInt32(peticion.ip_destino.Split(':')[1]);
            int json_intentos = peticion.intentos;

            //# Verifica datos básicos para lanzar el request:
            if ((Regex.IsMatch(json_ip_destino, @"(?:[0-9]{1,3}\.){3}[0-9]{1,3}")) && (Regex.IsMatch(Intercambio.ip_origen, @"(?:[0-9]{1,3}\.){3}[0-9]{1,3}")))
            {
                //# Crea objeto UDPRequest y lanza peticiones:
                try
                {
                    UDPRequest request = new UDPRequest(Intercambio.interfaz, Intercambio.ip_origen, Intercambio.puerto_origen, Intercambio.mac_origen, json_ip_destino, json_puerto_destino, Intercambio.mac_destino, json_intentos);
                    request.EnviaMensaje(peticion.paquete);
                }
                catch { Intercambio.cantidad_excepciones++; }
            }

            //# Flag para cantidad de threads:
            Intercambio.cantidad_threads_activos--;
        }

        private void thread_check_respuesta_Fired()
        {
            this.timer_check = new System.Timers.Timer();
            this.timer_check.Interval = 500;
            this.timer_check.Elapsed += timer_check_Elapsed;
            this.timer_check.Enabled = true;
            this.timer_check.Start();
        }

        private void timer_check_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            labelThreadsErrores.Text = Intercambio.cantidad_threads_activos.ToString() + " / " + Intercambio.cantidad_excepciones.ToString();
            labelPaquetesEnviados.Text = Intercambio.cantidad_peticiones_enviadas.ToString();
            labelPaquetesPeticionesRestantes.Text = (Intercambio.cantidad_peticiones_total - Intercambio.cantidad_peticiones_enviadas).ToString();
        }


        //# 
        //# Funcions y métodos de la clase:
        //#
        

        private bool cargaArchivoJSON(string ruta_archivo, bool mostrar_errores = false)
        {
            //#  Deserialize JSON (se pone dentro de un try porque si algo falla, no es posible continuar con el parseo del JSON ni con todo el programa. 
            try
            {
                //# Lee el archivo JSON:
                string json_string = string.Empty;
                using (StreamReader sr = new StreamReader(ruta_archivo)){ json_string = sr.ReadToEnd(); }

                this.json_root = JsonConvert.DeserializeObject<RootObject>(json_string);

                //# Guarda datos en variables globales (si da error es que no se pudo deserializar el json de forma correcta):
                Intercambio.interfaz = this.json_root.datos.interfaz;

                Intercambio.ip_origen = this.json_root.datos.ip_origen.Split(':')[0];
                Intercambio.mac_origen = this.json_root.datos.mac_origen;
                Intercambio.mac_destino = this.json_root.datos.mac_destino;

                Intercambio.puerto_origen = Convert.ToInt32(this.json_root.datos.ip_origen.Split(':')[1]);
                Intercambio.cantidad_threads_maximo = this.json_root.datos.threads;

                //# Cambia el comboBox de Interface seleccionada:
                comboBoxInterfaces.SelectedIndex = Intercambio.interfaz;

                //# Calcula y guarda datos de intercambio para luego mostrar en formulario principal:
                int cantidad_peticiones = 0;
                for (int x = 0; x < this.json_root.peticion.Count; x++) { cantidad_peticiones += this.json_root.peticion[x].intentos * this.json_root.peticion[x].paquete.Count; }

                //# Asigno a clase de intercambio la cantidad máxima de peticiones que habrá:
                Intercambio.cantidad_peticiones_total = cantidad_peticiones;

                //# Asigna los labels de resultados y configuración:
                reseteaVariablesYMuestraEnFormulario();

                //# Habilita el botón de Empezar:
                buttonEmpezar.Enabled = true;
            }
            catch
            {
                if (mostrar_errores) { MessageBox.Show("No se pudo leer de forma adecuada el archivo JSON. Verifique su construcción y que no esté en uso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                return false;
            }

            return true;
        }

        private void empiezaLanzadorDePeticiones()
        {
            //# Si este método es ejecutado desde el modo pivote y el archivo JSON no ha sido cargado, se intena buscar el archivo "config.txt" dentro de la ruta del ejecutable, y si existe, intenta cargarlo
            if (!archivo_json_config_correcto) {
                string archivo_automatico = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "config.txt");

                if (File.Exists(archivo_automatico)) { this.archivo_json_config_correcto = cargaArchivoJSON(archivo_automatico); }
                if (!archivo_json_config_correcto) { return; }
            }

            //# Lanza el Thread par monitorear resultados:
            if (thread_check_respuesta == null)
            {
                thread_check_respuesta = new Thread(thread_check_respuesta_Fired);
                thread_check_respuesta.Start();
                GC.KeepAlive(thread_check_respuesta);
            }

            //# Lanza el Thread principal que envía peticiones:
            if (thread_lanza_peticiones != null)
            {
                thread_lanza_peticiones.Abort();
                thread_lanza_peticiones = null;
                
                //# Muestra un evento en formulario que indica que se está reseteando la sesión (si llega hasta aquí es que es la segunda vez que se ejecutó el comando "Empezar"):
                reseteaVariablesYMuestraEnFormulario();
                buttonEmpezar.Text = "Flushing...";
                buttonEmpezar.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();

                Thread.Sleep(5000);

                buttonEmpezar.Text = "Empezar";
                buttonEmpezar.Enabled = true;
                this.Cursor = Cursors.Default;
                Application.DoEvents();
            }

            thread_lanza_peticiones = new Thread(thread_lanzador_de_request_Fired);
            thread_lanza_peticiones.Start();
            GC.KeepAlive(thread_lanza_peticiones);
        }

        private void reseteaVariablesYMuestraEnFormulario()
        {
            //# Este "reset" de variabls ocurre en el init y cada vez que se recibe el comando de "empezar":
            labelIPspoofeada.Text = Intercambio.ip_origen;
            labelPeticionesAEnviar.Text = Intercambio.cantidad_peticiones_total.ToString();
            labelThreadMaximo.Text = Intercambio.cantidad_threads_maximo.ToString();
            labelThreadsErrores.Text = "0 / 0";
            labelPaquetesEnviados.Text = "0";
            labelPaquetesPeticionesRestantes.Text = "0";

            Intercambio.cantidad_threads_activos = 0;
            Intercambio.cantidad_peticiones_enviadas = 0;
            Intercambio.cantidad_excepciones = 0;
        }

        
    }
}
