using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class loginUser
    {
        public string userName { get; set; }
        public Socket socket { get; set; }
        public int gamePoint { get; set; }
        public loginUser(string userName,Socket socket)
        {
            this.userName = userName;
            this.socket = socket;
            gamePoint = 0;
        }
    }
}
