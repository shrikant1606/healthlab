using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BOL
{
    public class Prescription
    {
        #region PrescriptionFields
        private int prescriptionid;
        private int dinfoid;
        private int pinfoid;
        private int appointmentid;
        private string date;
        private string timeslot;
        private string details;
        private string pfirstname;
        private string plastname;
        private string dusername;
        #endregion

        #region PrescriptionConstructors
        public Prescription()
        {
        }
        public Prescription(int dinfoid, int pinfoid, int appointmentid, string date, string timeslot, string pfirstname, string plastname)
        {
            this.dinfoid = dinfoid;
            this.pinfoid = pinfoid;
            this.appointmentid = appointmentid;
            this.date = date;
            this.timeslot = timeslot;
            this.pfirstname = pfirstname;
            this.plastname = plastname;
        }
        #endregion

        public int Prescriptionid
        {
            get { return prescriptionid; }
            set { prescriptionid = value; }
        }
        public int Dinfoid
        {
            get { return dinfoid; }
            set { dinfoid = value; }
        }
        public int Pinfoid
        {
            get { return pinfoid; }
            set { pinfoid = value; }
        }
        public int Appointmentid
        {
            get { return appointmentid; }
            set { appointmentid = value; }
        }
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        public string Timeslot
        {
            get { return timeslot; }
            set { timeslot = value; }
        }
        public string Pfirstname
        {
            get { return pfirstname; }
            set { pfirstname = value; }
        }
        public string Plastname
        {
            get { return plastname; }
            set { plastname = value; }
        }
        public string Dusername
        {
            get { return dusername; }
            set { dusername = value; }
        }
        [Required]
        public string Details
        {
            get { return details; }
            set { details = value; }
        }
    }
}
