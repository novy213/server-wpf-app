using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;
using System.IO;
namespace KLIENT
{
    public partial class MainWindow : Window
    {
        TcpClient tcpclnt;
        Stream stm;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            wyslij();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            String str = wiadXAML.Text;
            stm = tcpclnt.GetStream();
            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] ba = asen.GetBytes(str);
            statusXAML.Text = "Transmitowanie";
            stm.Write(ba, 0, ba.Length);
            //tcpclnt.Close();
        }
        void wyslij()
        {
            int port = Convert.ToInt32(portXAML.Text);
            tcpclnt = new TcpClient();
            statusXAML.Text = "Łączenie";
            tcpclnt.Connect(ipXAML.Text, port);
            statusXAML.Text = "Połączono";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            tcpclnt.Close();
            statusXAML.Text = "Rozłączono";
        }
    }
}
