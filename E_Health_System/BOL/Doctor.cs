using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Doctor
    {
        #region Doctor Fields
        private int did;
        private int dinfoid;
        private int daddid;
        private int dcontactid;
        private int dcertid;
        private int dtimeid;
        private string username;
        private string password;
        private string firstname;
        private string lastname;
        private string dob;
        private string gender;
        private string address;
        private string city;
        private string state;
        private int pincode;
        private string mobile;
        private string email;
        private string licence;
        private string specialization;
        private string certification;
        private int fees;
        private int rating;
        private int experience;
        private string checkin;
        private string checkout;
        #endregion
        #region Doctor Constructors
        public Doctor()
        {
        }
        public Doctor(string username, string password, string firstname, string lastname, string dob,
            string gender, string address, string city, string state, int pincode, string mobile, string email,
            string licence, string specialization, string certification, int fees, int rating, int experience,
            string checkin, string checkout)
        {
            this.username = username;
            this.password = password;
            this.firstname = firstname;
            this.lastname = lastname;
            this.dob = dob;
            this.gender = gender;
            this.address = address;
            this.city = city;
            this.state = state;
            this.pincode = pincode;
            this.mobile = mobile;
            this.email = email;
            this.licence = licence;
            this.specialization = specialization;
            this.certification = certification;
            this.fees = fees;
            this.rating = rating;
            this.experience = experience;
            this.checkin = checkin;
            this.checkout = checkout;
        }
        #endregion
        public int Did
        {
            get { return did; }
            set { did = value; }
        }
        public int Dinfoid
        {
            get { return dinfoid; }
            set { dinfoid = value; }
        }
        public int Daddid
        {
            get { return daddid; }
            set { daddid = value; }
        }
        public int Dcontactid
        {
            get { return dcontactid; }
            set { dcontactid = value; }
        }
        public int Dcertid
        {
            get { return dcertid; }
            set { dcertid = value; }
        }
        public int Dtimeid
        {
            get { return dtimeid; }
            set { dtimeid = value; }
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
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }
        public string Dob
        {
            get { return dob; }
            set { dob = value; }
        }
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
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
        public string Specialization
        {
            get { return specialization; }
            set { specialization = value; }
        }
        public string Certification
        {
            get { return certification; }
            set { certification = value; }
        }
        public int Fees
        {
            get { return fees; }
            set { fees = value; }
        }
        public int Rating
        {
            get { return rating; }
            set { rating = value; }
        }
        public int Experience
        {
            get { return experience; }
            set { experience = value; }
        }
        public string Checkin
        {
            get { return checkin; }
            set { checkin = value; }
        }
        public string Checkout
        {
            get { return checkout; }
            set { checkout = value; }
        }
    }
}
