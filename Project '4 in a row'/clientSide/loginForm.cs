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
    public partial class loginForm : Form
    {
        Socket _clientSocket;
        public loginForm(Socket x)
        {
            InitializeComponent();
            _clientSocket = x;
        }

        private void BTregister_Click(object sender, EventArgs e)
        {
            registration x = new registration(_clientSocket);
            this.Visible = false;
            x.Show();
        }

        private void BTreset_Click(object sender, EventArgs e)
        {
            LBerrorpassword.Visible = false;
            LBerroruser.Visible = false;
            TBpassword.Text = "";
            TBusername.Text = "";
        }

        private void BTlogin_Click(object sender, EventArgs e)
        {
            LBerrorpassword.Visible = false;
            LBerroruser.Visible = false;

            if (TBusername.Text=="" || TBpassword.Text=="")
            {
                if (TBpassword.Text == "") LBerrorpassword.Visible = true;
                if (TBusername.Text == "") LBerroruser.Visible = true;
            }
            else
            {
                // send the user name and the password to the server
                string loginInfo = "login;" + TBusername.Text + ";" + TBpassword.Text;
                byte[] userInfo = Encoding.Unicode.GetBytes(loginInfo);
                _clientSocket.Send(userInfo);

                // recive from thes server the resault, if the user name and the password are ok
                byte[] buffer = new byte[1024];
                int rec = _clientSocket.Receive(buffer);
                byte[] temp = new byte[rec];
                Array.Copy(buffer, temp, rec);
                string serverResault = Encoding.Unicode.GetString(temp);
                string[] serverInfo = serverResault.Split(';');
                if (serverInfo[0].Equals("login"))
                {
                    if(serverInfo[1].Equals("ok"))
                    {
                        clientForm x = new clientForm(_clientSocket, TBusername.Text);
                        this.Visible = false;
                        x.Show();
                    }
                    else 
                    {
                        LBerrorpassword.Visible = false;
                        LBerroruser.Visible = false;
                        TBpassword.Text = "";
                        TBusername.Text = "";
                    }
                }
            }
        }
    }
}
