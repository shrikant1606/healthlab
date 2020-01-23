using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Pharmacy 
    {
        #region Pharmacy Fields
        private int pid;
        private int pinfoid;
        private int paddid;
        private int pcontactid;
        private int pcertid;
        private string username;
        private string password;
        private string companyname;
        private string competentperson;
        private string address;
        private string city;
        private string state;
        private int pincode;
        private string mobile;
        private string email;
        private string licence;
        #endregion

        #region Pharmacy Constructors
        public Pharmacy()
        {
        }
        public Pharmacy(string username, string password, string companyname, string competentperson, string dob,
            string gender, string address, string city, string state, int pincode, string mobile, string email,
            string licence)
        {
            this.username = username;
            this.password = password;
            this.companyname = companyname;
            this.competentperson = competentperson;
            this.address = address;
            this.city = city;
            this.state = state;
            this.pincode = pincode;
            this.mobile = mobile;
            this.email = email;
            this.licence = licence;
        }
        #endregion

        public int Pid
        {
            get { return pid; }
            set { pid = value; }
        }
        public int Pinfoid
        {
            get { return pinfoid; }
            set { pinfoid = value; }
        }
        public int Paddid
        {
            get { return paddid; }
            set { paddid = value; }
        }
        public int Pcontactid
        {
            get { return pcontactid; }
            set { pcontactid = value; }
        }
        public int Pcertid
        {
            get { return pcertid; }
            set { pcertid = value; }
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
        public string Companyname
        {
            get { return companyname; }
            set { companyname = value; }
        }
        public string Competentperson
        {
            get { return competentperson; }
            set { competentperson = value; }
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