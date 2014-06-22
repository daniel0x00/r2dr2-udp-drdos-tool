using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDPRequester
{
    public static class Intercambio
    {
        private static object bloqueador = new object();

        private static int _interfaz = 0;
        private static string _ip_origen = string.Empty;
        private static int _puerto_origen = 0;
        private static string _mac_origen = string.Empty;
        private static string _mac_destino = string.Empty;

        private static int _cantidad_threads_maximo = 0;
        private static int _cantidad_threads_activos = 0;

        private static int _cantidad_peticiones_enviadas = 0;
        private static int _cantidad_peticiones_total = 0;
        private static int _cantidad_excepciones = 0;

        public static int interfaz
        {
            get { lock (bloqueador) return _interfaz; }
            set { lock (bloqueador) _interfaz = value; }
        }

        public static string ip_origen
        {
            get { lock (bloqueador) return _ip_origen; }
            set { lock (bloqueador) _ip_origen = value; }
        }

        public static int puerto_origen
        {
            get { lock (bloqueador) return _puerto_origen; }
            set { lock (bloqueador) _puerto_origen = value; }
        }

        public static string mac_origen
        {
            get { lock (bloqueador) return _mac_origen; }
            set { lock (bloqueador) _mac_origen = value; }
        }

        public static string mac_destino
        {
            get { lock (bloqueador) return _mac_destino; }
            set { lock (bloqueador) _mac_destino = value; }
        }

        public static int cantidad_threads_maximo
        {
            get { lock (bloqueador) return _cantidad_threads_maximo; }
            set { lock (bloqueador) _cantidad_threads_maximo = value; }
        }

        public static int cantidad_threads_activos
        {
            get { lock (bloqueador) return _cantidad_threads_activos; }
            set { lock (bloqueador) _cantidad_threads_activos = value; }
        }

        public static int cantidad_peticiones_enviadas
        {
            get { lock (bloqueador) return _cantidad_peticiones_enviadas; }
            set { lock (bloqueador) _cantidad_peticiones_enviadas = value; }
        }

        public static int cantidad_peticiones_total
        {
            get { lock (bloqueador) return _cantidad_peticiones_total; }
            set { lock (bloqueador) _cantidad_peticiones_total = value; }
        }

        public static int cantidad_excepciones
        {
            get { lock (bloqueador) return _cantidad_excepciones; }
            set { lock (bloqueador) _cantidad_excepciones = value; }
        }
    }
}
