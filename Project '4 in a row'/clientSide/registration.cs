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
    public partial class registration : Form
    {
        Socket _clientSocket;
        public registration(Socket x)
        {
            InitializeComponent();
            _clientSocket = x;
        }

        private void BTreset_Click(object sender, EventArgs e)
        {
            TBfirstName.Text = "";
            TBlaseName.Text = "";
            TBemail.Text = "";
            TBusername.Text = "";
            TBpassword_1.Text = "";
            TBpassword_2.Text = "";
        }

        private void BTregister_Click(object sender, EventArgs e)
        {
            LBerrorpassword_1.Visible = false;
            LBerrorpassword_2.Visible = false;
            LBerrorEmail.Visible = false;
            LBerrorFiresName.Visible = false;
            LBerrorLastName.Visible = false;
            bool flagCheckPasswordOk = CheckPasswordOk();
            bool flagCheckEmailOk = CheckEmailOk();
            bool flagCheckNameOk = CheckNameOk();
            bool flagCheckUserNameOK = checkUserNameOk();
            if (!flagCheckPasswordOk || !flagCheckEmailOk || !flagCheckNameOk || !flagCheckUserNameOK)
            {
                if (!flagCheckPasswordOk)
                {
                    LBerrorpassword_1.Visible = true;
                    LBerrorpassword_2.Visible = true;
                    TBpassword_1.Text = "";
                    TBpassword_2.Text = "";
                }
                if (!flagCheckEmailOk)
                {
                    LBerrorEmail.Visible = true;
                    TBemail.Text = "";
                }
                if (!flagCheckNameOk)
                {
                    LBerrorFiresName.Visible = true;
                    LBerrorLastName.Visible = true;
                    TBfirstName.Text = "";
                    TBlaseName.Text = "";
                }
                if (!flagCheckUserNameOK)
                {
                    LBerroruser.Visible = true;
                    TBusername.Text = "";
                }
            }
            else
            {
                // send the user information to the server
                string registratioInfo = "registraion;" + TBfirstName.Text + ";" + TBlaseName.Text + ";"
                                          + TBemail.Text + ";" + TBusername.Text + ";" + TBpassword_1.Text;
                byte[] userInfo = Encoding.Unicode.GetBytes(registratioInfo);
                TBfirstName.Text = "";
                _clientSocket.Send(userInfo);

                // recive from thes server the resault, if the user name and the password are ok
                byte[] buffer = new byte[1024];
                int rec = _clientSocket.Receive(buffer);
                byte[] temp = new byte[rec];
                Array.Copy(buffer, temp, rec);
                string serverResault = Encoding.Unicode.GetString(temp);
                string[] serverInfo = serverResault.Split(';');
                if (serverInfo[0].Equals("registraion"))
                {
                    if (serverInfo[1].Equals("ok"))
                    {
                        loginForm x = new loginForm(_clientSocket);
                        this.Visible = false;
                        x.Show();
                    }
                    else
                    {
                        LBerroruser.Visible = false;
                        TBusername.Text = "";
                    }
                }
            }
        }

        private bool checkUserNameOk()
        {
            return TBusername.Text.Length > 5 && countNum(TBusername.Text) == 3;
        }

        private int countNum(string st)
        {
            int count = 0;
            for (int i=0;i<st.Length;i++)
            {
                if (st[i] >= '0' && st[i] <= '9')
                    count++;
            }
            return count;
        }
        private bool CheckNameOk()
        {
            return countNum(TBfirstName.Text) == 0 && countNum(TBlaseName.Text) == 0;
        }

        private bool CheckEmailOk()
        {
            int count1 = 0;
            for (int i=0;i<TBemail.Text.Length;i++)
            {
                if (TBemail.Text[i] == '@')
                    count1++;
            }
            return count1  == 1;
        }

        private bool CheckPasswordOk()
        {
            bool empty = TBpassword_1.Text != "" && TBpassword_2.Text != "";
            bool cmp = TBpassword_1.Text.Equals(TBpassword_2.Text);
            return empty && cmp;
        }
    }
}
