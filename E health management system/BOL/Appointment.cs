using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Appointment
    {
        #region Appointment Fields
        private int appointmentid;
        private int dinfoid;
        private int pinfoid;
        private int prescriptionid;
        private string pfirstname;
        private string plastname;
        private string dfirstname;
        private string dlastname;
        private string details;
        private string timeslot;
        private string date;
        private int status;
        #endregion

        #region Appointment constructors
        public Appointment()
        {

        }

        public Appointment(int appointmentid,int doctorid,int patientid,int prescriptionid,string pfirstname,string plastname,
            string dfirstname,string dlastname,string details,string timeslot, string date,int status)
        {
            this.appointmentid = appointmentid;
            this.dinfoid = doctorid;
            this.dinfoid = patientid;
            this.prescriptionid = prescriptionid;
            this.pfirstname = pfirstname;
            this.plastname = plastname;
            this.dfirstname = dfirstname;
            this.dlastname = dlastname;
            this.details = details;
            this.timeslot = timeslot;
            this.date = date;
            this.status = status;
        }
        #endregion

        public int Appointmentid
        {
            get { return appointmentid; }
            set { appointmentid = value; }
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
        public int Prescriptionid
        {
            get { return prescriptionid; }
            set { prescriptionid = value; }
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
        public string Dfirstname
        {
            get { return dfirstname; }
            set { dfirstname = value; }
        }
        public string Dlastname
        {
            get { return dlastname; }
            set { dlastname = value; }
        }
        public string Details
        {
            get { return details; }
            set { details = value; }
        }
        public string Timeslot
        {
            get { return timeslot; }
            set { timeslot = value; }
        }
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        public int Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
