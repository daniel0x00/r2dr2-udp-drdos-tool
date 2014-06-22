using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.RegularExpressions;
using System.Net.Sockets;

namespace UDPRequester
{
    public partial class Form_Pivotes : Form
    {
        public Form_Pivotes()
        {
            InitializeComponent();
        }

        private void buttonAgregarIP_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBoxIP.Text.Trim(), @"(?:[0-9]{1,3}\.){3}[0-9]{1,3}"))
            {
                listBoxIPsPivotes.Items.Add(textBoxIP.Text.Trim());
                if (listBoxIPsPivotes.Items.Count > 0) { buttonEnviar.Enabled = true; }
            }
        }

        private void buttonEnviar_Click(object sender, EventArgs e)
        {
            int paquetes_enviados = 0;
            labelStatus.Text = "Enviando paquetes...";
            Application.DoEvents();

            try
            {
                using (UdpClient udp = new UdpClient(0))
                {
                    foreach (var item in listBoxIPsPivotes.Items)
                    {
                        udp.Connect(item.ToString(), 9000);
                        Byte[] sendBytes = Encoding.ASCII.GetBytes("empiezaLanzadorDePeticiones");
                        udp.Send(sendBytes, sendBytes.Length);

                        //# Contador de envíos:
                        paquetes_enviados++;

                        labelStatus.Text = "Enviando paquete a: " + item.ToString();
                        Application.DoEvents();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("No se pudo enviar paquete UDP. Excepción:\n\n"+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            labelStatus.Text = "Culminado. Paquetes enviados: " + paquetes_enviados.ToString() + ".";
        }

        private void textBoxIP_Enter(object sender, EventArgs e)
        {
            ActiveForm.AcceptButton = buttonAgregarIP;
        }
    }
}
