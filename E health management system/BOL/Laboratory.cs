using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Laboratory
    {
        #region Laboratory Fields
        private int lid;
        private int linfoid;
        private int laddid;
        private int lcontactid;
        private int lcertid;
        private string username;
        private string password;
        private string laboratoryname;
        private string inchargename;
        private string address;
        private string city;
        private string state;
        private int pincode;
        private string mobile;
        private string email;
        private string licence;
        #endregion
        #region Laboratory Constructors
        public Laboratory()
        {
        }
        public Laboratory(string username, string password, string laboratoryname, string inchargename, string dob,
            string gender, string address, string city, string state, int pincode, string mobile, string email,
            string licence)
        {
            this.username = username;
            this.password = password;
            this.laboratoryname = laboratoryname;
            this.inchargename = inchargename;
            this.address = address;
            this.city = city;
            this.state = state;
            this.pincode = pincode;
            this.mobile = mobile;
            this.email = email;
            this.licence = licence;
        }
        #endregion
        public int Lid
        {
            get { return lid; }
            set { lid = value; }
        }
        public int Linfoid
        {
            get { return linfoid; }
            set { linfoid = value; }
        }
        public int Laddid
        {
            get { return laddid; }
            set { laddid = value; }
        }
        public int Lcontactid
        {
            get { return lcontactid; }
            set { lcontactid = value; }
        }
        public int Lcertid
        {
            get { return lcertid; }
            set { lcertid = value; }
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
        public string Laboratoryname
        {
            get { return laboratoryname; }
            set { laboratoryname = value; }
        }
        public string Inchargename
        {
            get { return inchargename; }
            set { inchargename = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        public string State
        {
            get { return state; }
            set { state = value; }
        }
        public int Pincode
        {
            get { return pincode; }
            set { pincode = value; }
        }
        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Licence
        {
            get { return licence; }
            set { licence = value; }
        }
    }
}
