using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BOL
{
    public class Patient
    {
        #region Patient Fields
        private int pid;
        private int pinfoid;
        private int paddid;
        private int pcontactid;
        private string username;
        private string password;
        private string firstname;
        private string lastname;
        private string dob;
        private string gender;
        private string history;
        private string address;
        private string city;
        private string state;
        private int pincode;
        private string mobile;
        private string email;
        #endregion
        #region Patient Constructor
        public Patient()
        {
        }
        public Patient(string username, string password, string firstname, string lastname, string dob,
            string gender, string address, string city, string state, int pincode, string mobile, string email,
            string history)
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
            this.history = history;
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
        [Required]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        [DataType(DataType.Password)]
        [Required]
        [RegularExpression("([a-z]|[A-Z]|[0-9]|[\\W]){4}[a-zA-Z0-9\\W]{3,11}", ErrorMessage = "weak password....It must contain alpha-numeric")]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        [Required]
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        [Required]
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }
        [Required]
        public string Dob
        {
            get { return dob; }
            set { dob = value; }
        }
        [Required]
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        public string History
        {
            get { return history; }
            set { history = value; }
        }
        [Required]
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        [Required]
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        [Required]
        public string State
        {
            get { return state; }
            set { state = value; }
        }
        [Required]
        public int Pincode
        {
            get { return pincode; }
            set { pincode = value; }
        }
        [Required]
        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}
