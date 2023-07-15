using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class user
    {
        public string _firstName { get; set; }
        public string _lastName { get; set; }
        public string _Email { get; set; }
        public string _userName { get; set; }
        public string _password { get; set; }

        public user() { }
        public user(string firsName, string lastName, string Email, string userName, string password)
        {
            _firstName = firsName;_lastName = lastName;_Email = Email;_userName = userName;_password = password;
        }
    }
}
