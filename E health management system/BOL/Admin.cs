using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Admin
    {
        #region Admin Fields
        private int adminid;
        private string username;
        private string password;
        private string email;
        #endregion

        #region Admin Constructors
        public Admin()
        {
        }
        public Admin(int adminid, string username, string password, string email)
        {
            this.adminid = adminid;
            this.username = username;
            this.password = password;
            this.email = email;
        }
        #endregion

        public int Adminid
        {
            get { return adminid; }
            set { adminid = value; }
        }
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}
