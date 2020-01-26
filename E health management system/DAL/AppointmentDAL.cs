using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BOL;

namespace DAL
{
    public class AppointmentDAL
    {
        private static string conString = string.Empty;
        static AppointmentDAL()
        {
            conString = ConfigurationManager.ConnectionStrings["e_health_db"].ConnectionString;
        }

        public static List<Appointment> GetAll(string username)
        {
            int dinfoid=0;
            
            List<Appointment> appointments = new List<Appointment>();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    string query = "SELECT dinfo from DoctorInfo where username=@username";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@username", username));
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                {
                                    dinfoid = int.Parse(reader["dinfoid"].ToString());
                                };
                            }
                            reader.Close();
                        }
                    }


                    query = "SELECT AppointmentMaster.appointmentid,PatientInfo.firstname,PatientInfo.lastname,AppointmentMaster.timeslot,AppointmentMaster.date,AppointmentMaster.status FROM patientInfo INNER JOIN AppointmentMaster  on PatientInfo.pinfoid=AppointmentMaster.pinfoid where AppointmentMaster.dinfoid=@dinfoid";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@dinfoid", dinfoid));
                    reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Appointment appointment = new Appointment()
                                {
                                    Appointmentid = int.Parse(reader["appointmentid"].ToString()),
                                    Pfirstname = reader["firstname"].ToString(),
                                    Plastname = reader["lastname"].ToString(),
                                    Timeslot = reader["timeslot"].ToString(),
                                    Date = reader["date"].ToString(),
                                    Status = int.Parse(reader["status"].ToString())
                            };
                                appointments.Add(appointment);
                            }
                            reader.Close();
                        }
                    }
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return appointments;
        }

        public static List<Appointment> History(int patientid)
        {
            List<Appointment> appointments = new List<Appointment>();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT DoctorInfo.firstname,DoctorInfo.lastname,AppointmentMaster.date,PrescriptionMaster.Details FROM PrescriptionMaster INNER JOIN AppointmentMaster ON PrescriptionMaster.appointmentid = AppointmentMaster.appointmentid INNER JOIN DoctorInfo ON PrescriptionMaster.dinfoid = DoctorInfo.dinfoid INNER JOIN PatientInfo ON PrescriptionMaster.pinfoid = PatientInfo.pinfoid WHERE(PrescriptionMaster.pinoid = 12)";
                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Appointment history = new Appointment()
                                {
                                    Dfirstname=reader["firstname"].ToString(),
                                    Dlastname=reader["lastname"].ToString(),
                                    Details=reader["details"].ToString(),
                                    Date = reader["date"].ToString(),
                                    
                                };
                                appointments.Add(history);
                            }
                            reader.Close();
                        }
                    }
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return appointments;
        }

        public static bool BookAppointment(Appointment appointment)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "INSERT INTO AppointmentMaster (dinfoid, pinfoid, timeslot, date, status) " +
                        "VALUES (@dinfoid, @pinfoid, @timeslot, @date, @status)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@dinfoid", appointment.Dinfoid));
                    cmd.Parameters.Add(new SqlParameter("@pinfoid", appointment.Pinfoid));
                    cmd.Parameters.Add(new SqlParameter("@timeslot", appointment.Timeslot));
                    cmd.Parameters.Add(new SqlParameter("@date", appointment.Date));
                    cmd.Parameters.Add(new SqlParameter("@status", appointment.Status));
                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    status = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return status;
        }
    }
}
