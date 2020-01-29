using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Feedback
    {
        #region Feedback Fields
        private int feedbackid;
        private int appointmentid;
        private int dinfoid;
        private int pinfoid;
        private string pusername;
        private string pfirstname;
        private string plastname;
        private string dfirstname;
        private string dlastname;
        private string details;
        private string date;
        #endregion

        #region Feedback constructors
        public Feedback()
        {

        }

        public Feedback(int feedbackid, int appointmentid, int doctorid, int patientid, string pfirstname, string plastname,
            string dfirstname, string dlastname, string details, string date)
        {
            this.feedbackid = feedbackid;
            this.appointmentid = appointmentid;
            this.dinfoid = doctorid;
            this.dinfoid = patientid;
            this.pfirstname = pfirstname;
            this.plastname = plastname;
            this.dfirstname = dfirstname;
            this.dlastname = dlastname;
            this.details = details;
            this.date = date;
        }
        #endregion

        public int Feedbackid
        {
            get { return feedbackid; }
            set { feedbackid = value; }
        }
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
        public string Pusername
        {
            get { return pusername; }
            set { pusername = value; }
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
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
    }
}
