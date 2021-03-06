﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using BOL;

namespace DAL
{
    public class PrescriptionDAL
    {
        private static string conString = string.Empty;
        static PrescriptionDAL()
        {
            conString = ConfigurationManager.ConnectionStrings["e_health_db"].ConnectionString;
        }

        public static bool CreatePrescription(Prescription prescription)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT pinfoid from PatientInfo where firstname=@pfirstname";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@pfirstname", prescription.Pfirstname));
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                {
                                    prescription.Pinfoid = int.Parse(reader["pinfoid"].ToString());
                                };
                            }
                            reader.Close();
                        }
                    }

                    query = "SELECT dinfoid from DoctorInfo where username=@username";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@username", prescription.Dusername));
                    reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                {
                                    prescription.Dinfoid = int.Parse(reader["dinfoid"].ToString());
                                };
                            }
                            reader.Close();
                        }
                    }
                    
                    query = "INSERT INTO PrescriptionMaster (dinfoid, pinfoid, appointmentid, date, timeslot, details) " +
                        "VALUES (@dinfoid, @pinfoid, @appointmentid, @date, @timeslot, @details)";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@dinfoid", prescription.Dinfoid));
                    cmd.Parameters.Add(new SqlParameter("@pinfoid", prescription.Pinfoid));
                    cmd.Parameters.Add(new SqlParameter("@appointmentid", prescription.Appointmentid));
                    cmd.Parameters.Add(new SqlParameter("@date", prescription.Date));
                    cmd.Parameters.Add(new SqlParameter("@timeslot", prescription.Timeslot));
                    cmd.Parameters.Add(new SqlParameter("@details", prescription.Details));
                    cmd.ExecuteNonQuery();

                    query = "UPDATE AppointmentMaster SET status = 1 where appointmentid = @appointmentid";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@appointmentid", prescription.Appointmentid));
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

        public static List<Prescription> GetPrescriptions(string firstname, string lastname)
        {
            int pinfoid = 0;

            List<Prescription> prescriptions= new List<Prescription>();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    string query = "SELECT pinfoid from PatientInfo where firstname=@firstname and lastname = @lastname";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@firstname", firstname));
                    cmd.Parameters.Add(new SqlParameter("@lastname", lastname));
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                {
                                    pinfoid = int.Parse(reader["pinfoid"].ToString());
                                };
                            }
                            reader.Close();
                        }
                    }

                    query = "SELECT DoctorInfo.firstname,DoctorInfo.lastname,PrescriptionMaster.date,PrescriptionMaster.Details, PrescriptionMaster.timeslot FROM PrescriptionMaster INNER JOIN DoctorMaster ON PrescriptionMaster.dinfoid = DoctorMaster.dinfoid INNER JOIN DoctorInfo ON DoctorMaster.dinfoid = DoctorInfo.dinfoid WHERE(PrescriptionMaster.pinfoid = @pinfoid)";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@pinfoid", pinfoid));
                    reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Prescription prescription = new Prescription()
                                {
                                    Dfirstname = reader["firstname"].ToString(),
                                    Dlastname = reader["lastname"].ToString(),
                                    Details = reader["details"].ToString(),
                                    Date = reader["date"].ToString(),
                                    Timeslot = reader["timeslot"].ToString()
                                };
                                prescriptions.Add(prescription);
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
            return prescriptions;
        }
    }
}
