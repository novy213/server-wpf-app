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

namespace SERWER
{
    public partial class MainWindow : Window
    { 
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            start();
        }
        TcpListener myList;
        Socket s;
        public void start()
        {
            IPAddress ipAd = IPAddress.Parse(ipXAML.Text);
            int port = Convert.ToInt32(portXAML.Text);
            myList = new TcpListener(ipAd, port);
            myList.Start();
            status.Text = "Uruchomiono";
        }
        public void odbierz()
        { 
            s = myList.AcceptSocket();
            byte[] b = new byte[100];
            int k = s.Receive(b);
            for (int i = 0; i < k; i++)
                tekstXAML.Text += Convert.ToChar(b[i]);
            s.Close();
            tekstXAML.Text += "\n";
            //myList.Stop();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            odbierz();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            status.Text = "Wyłączono";
            myList.Stop();
            
        }
    }
}
