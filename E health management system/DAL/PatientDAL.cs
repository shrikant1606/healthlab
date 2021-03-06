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
    public class PatientDAL
    {
        private static string conString = string.Empty;
        static PatientDAL()
        {
            conString = ConfigurationManager.ConnectionStrings["e_health_db"].ConnectionString;
        }
        public static bool Insert(Patient patient)
        {
            bool status = false;
            int infoid = 0;
            int addid = 0;
            int contactid = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    string query = "SELECT username from PatientInfo where username = @username";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@username", patient.Username));
                    SqlDataReader reader1 = cmd.ExecuteReader();
                    if (reader1 != null)
                    {
                        if (reader1.HasRows)
                        {
                            status = false;
                            reader1.Close();
                        }
                        else
                        {
                            reader1.Close();
                            query = "INSERT INTO PatientInfo (username, password, firstname, lastname, history, dob, gender) " +
                            "VALUES (@username, @password, @firstname, @lastname, @history, @dob, @gender)";
                            SqlCommand cmd1 = new SqlCommand(query, con);
                            cmd1.Parameters.Add(new SqlParameter("@username", patient.Username));
                            cmd1.Parameters.Add(new SqlParameter("@password", patient.Password));
                            cmd1.Parameters.Add(new SqlParameter("@firstname", patient.Firstname));
                            cmd1.Parameters.Add(new SqlParameter("@lastname", patient.Lastname));
                            cmd1.Parameters.Add(new SqlParameter("@history", patient.History));
                            cmd1.Parameters.Add(new SqlParameter("@dob", patient.Dob));
                            cmd1.Parameters.Add(new SqlParameter("@gender", patient.Gender));
                            cmd1.ExecuteNonQuery();

                            SqlCommand cmd2 = new SqlCommand(query, con);
                            query = "INSERT INTO PatientAddress (address, city, state, pincode) " +
                               "VALUES (@address, @city, @state, @pincode)";
                            cmd2 = new SqlCommand(query, con);
                            cmd2.Parameters.Add(new SqlParameter("@address", patient.Address));
                            cmd2.Parameters.Add(new SqlParameter("@city", patient.City));
                            cmd2.Parameters.Add(new SqlParameter("@state", patient.State));
                            cmd2.Parameters.Add(new SqlParameter("@pincode", patient.Pincode));
                            cmd2.ExecuteNonQuery();

                            SqlCommand cmd3 = new SqlCommand(query, con);
                            query = "INSERT INTO PatientContact (mobile, email) " +
                               "VALUES (@mobile, @email)";
                            cmd3 = new SqlCommand(query, con);
                            cmd3.Parameters.Add(new SqlParameter("@mobile", patient.Mobile));
                            cmd3.Parameters.Add(new SqlParameter("@email", patient.Email));
                            cmd3.ExecuteNonQuery();

                            query = "SELECT TOP 1 * from PatientInfo order by pinfoid desc";
                            SqlCommand cmd4 = new SqlCommand(query, con);
                            SqlDataReader reader = cmd4.ExecuteReader();
                            if (reader != null)
                            {
                                if (reader.HasRows)
                                {
                                    if (reader.Read())
                                    {
                                        infoid = int.Parse(reader["pinfoid"].ToString());
                                    }
                                    reader.Close();
                                }
                            }
                            query = "SELECT TOP 1 * from PatientAddress order by paddid desc";
                            SqlCommand cmd5 = new SqlCommand(query, con);
                            reader = cmd5.ExecuteReader();
                            if (reader != null)
                            {
                                if (reader.HasRows)
                                {
                                    if (reader.Read())
                                    {
                                        addid = int.Parse(reader["paddid"].ToString());
                                    }
                                    reader.Close();
                                }
                            }
                            query = "SELECT TOP 1 * from PatientContact order by pcontactid desc";
                            SqlCommand cmd6 = new SqlCommand(query, con);
                            reader = cmd6.ExecuteReader();
                            if (reader != null)
                            {
                                if (reader.HasRows)
                                {
                                    if (reader.Read())
                                    {
                                        contactid = int.Parse(reader["pcontactid"].ToString());
                                    }
                                    reader.Close();
                                }
                            }
                            SqlCommand cmd7 = new SqlCommand(query, con);
                            query = "INSERT INTO PatientMaster (pinfoid, paddid, pcontactid) " +
                                    "VALUES (@pinfoid, @paddid, @pcontactid)";
                            cmd7 = new SqlCommand(query, con);
                            cmd7.Parameters.Add(new SqlParameter("@pinfoid", infoid));
                            cmd7.Parameters.Add(new SqlParameter("@paddid", addid));
                            cmd7.Parameters.Add(new SqlParameter("@pcontactid", contactid));
                            cmd7.ExecuteNonQuery();
                            status = true;
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
            return status;
        }

        public static bool Delete(int did)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "DELETE FROM DoctorMaster WHERE did=@did";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@did", did));
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

        public static bool ValidateUser(string username, string password)
        {
            bool status = false;
            using (SqlConnection con = new SqlConnection(conString))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string Query = "select * from PatientInfo where username=@username and password=@password";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.Add(new SqlParameter("@username", username));
                cmd.Parameters.Add(new SqlParameter("@password", password));
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        status = true;
                    }
                }
            }
            return status;
        }

        public static List<Patient> PatientDetail(string firstname, string lastname)
        {
            Patient patient = null;
            List<Patient> patients = new List<Patient>();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT PatientInfo.firstname, PatientInfo.lastname, PatientAddress.address, PatientAddress.city, PatientAddress.state, PatientContact.mobile, PatientContact.email, PatientInfo.History FROM PatientInfo INNER JOIN PatientMaster on PatientInfo.pinfoid=PatientMaster.pinfoid INNER JOIN PatientAddress on PatientMaster.paddid=PatientAddress.paddid INNER JOIN PatientContact on PatientMaster.pcontactid=PatientContact.pcontactid WHERE (PatientInfo.firstname=@firstname and PatientInfo.lastname=@lastname)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@firstname", firstname));
                    cmd.Parameters.Add(new SqlParameter("@lastname", lastname));
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                patient = new Patient()
                                {
                                    Firstname = reader["firstname"].ToString(),
                                    Lastname = reader["lastname"].ToString(),
                                    History = reader["history"].ToString(),
                                    Address = reader["address"].ToString(),
                                    City = reader["city"].ToString(),
                                    State = reader["state"].ToString(),
                                    Mobile = reader["mobile"].ToString(),
                                    Email = reader["email"].ToString(),
                                };
                                patients.Add(patient);
                            }
                            reader.Close();
                        }
                    }
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            catch (Exception ex)
            { throw ex; }
            return patients;
        }
    }
}
