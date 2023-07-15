using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clientSide
{
    public partial class intruForm : Form
    {
        private static Socket _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
       
        public intruForm()
        {
            InitializeComponent();
            ConnectToServer();
        }

        private void ConnectToServer()
        {
           if (!_clientSocket.Connected)
           {
              try
              {
                  _clientSocket.Connect(IPAddress.Loopback, 50000);
                    //Clientsocket. Connect (IPAddress.Parse("192.168.11.2"),100)) ;
                    MessageBox.Show("connected.");
              }
              catch (SocketException)
              {
                  MessageBox.Show (":not connected.");
              }
             
           }
        }

        private void NTlogin_Click(object sender, EventArgs e)
        {
            loginForm x = new loginForm(_clientSocket);
            this.Visible = false;
            x.Show();
        }

        private void BTregister_Click(object sender, EventArgs e)
        {
            registration x = new registration(_clientSocket);
            this.Visible = false;
            x.Show();
        }


    }
}
