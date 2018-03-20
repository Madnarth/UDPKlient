using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDPKlient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bConnect_Click(object sender, EventArgs e)
        {
            string host = tbHostAddress.Text;
            int port = (int)numPort.Value;
            try
            {
                UdpClient klient = new UdpClient(host, port);
                Byte[] dane = Encoding.ASCII.GetBytes(tbText.Text);
                klient.Send(dane, dane.Length);
                lbLogs.Items.Add("Wysłanie wiadomości do hosta " + host +":" + port);
                klient.Close();
            }
            catch (Exception ex)
            {
                lbLogs.Items.Add("Błąd: Nie udało się wysłać wiadomości!");
                MessageBox.Show(ex.ToString(), "Błąd");
            }
        }
    }
}
