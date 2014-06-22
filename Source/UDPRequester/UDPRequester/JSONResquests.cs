using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDPRequester
{
    public class Datos
    {
        public string ip_origen { get; set; }
        public string mac_origen { get; set; }
        public string mac_destino { get; set; }
        public int interfaz { get; set; }
        public int threads { get; set; }
    }

    public class Peticion
    {
        public string ip_destino { get; set; }
        public string descripcion { get; set; }
        public int intentos { get; set; }
        public List<string> paquete { get; set; }
    }

    public class RootObject
    {
        public Datos datos { get; set; }
        public List<Peticion> peticion { get; set; }
    }
}
