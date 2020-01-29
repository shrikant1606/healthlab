using System;
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
    public class PharmacyDAL
    {
        private static string conString = string.Empty;
        static PharmacyDAL()
        {
            conString = ConfigurationManager.ConnectionStrings["e_health_db"].ConnectionString;
        }
        public static bool Insert(Pharmacy pharmacy)
        {
            bool status = false;
            int infoid = 0;
            int addid = 0;
            int contactid = 0;
            int certid = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    string query = "SELECT username from PharmacyInfo where username = @username";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@username", pharmacy.Username));
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
                            query = "INSERT INTO PharmacyInfo (username, password, companyname,competentperson) " +
                            "VALUES (@username, @password, @companyname, @competentperson)";
                            SqlCommand cmd1 = new SqlCommand(query, con);
                            cmd1.Parameters.Add(new SqlParameter("@username", pharmacy.Username));
                            cmd1.Parameters.Add(new SqlParameter("@password", pharmacy.Password));
                            cmd1.Parameters.Add(new SqlParameter("@companyname", pharmacy.Companyname));
                            cmd1.Parameters.Add(new SqlParameter("@competentperson", pharmacy.Competentperson));
                            cmd1.ExecuteNonQuery();

                            SqlCommand cmd2 = new SqlCommand(query, con);
                            query = "INSERT INTO PharmacyAddress (address, city, state, pincode) " +
                               "VALUES (@address, @city, @state, @pincode)";
                            cmd2 = new SqlCommand(query, con);
                            cmd2.Parameters.Add(new SqlParameter("@address", pharmacy.Address));
                            cmd2.Parameters.Add(new SqlParameter("@city", pharmacy.City));
                            cmd2.Parameters.Add(new SqlParameter("@state", pharmacy.State));
                            cmd2.Parameters.Add(new SqlParameter("@pincode", pharmacy.Pincode));
                            cmd2.ExecuteNonQuery();

                            SqlCommand cmd3 = new SqlCommand(query, con);
                            query = "INSERT INTO PharmacyContact (mobile, email) " +
                               "VALUES (@mobile, @email)";
                            cmd3 = new SqlCommand(query, con);
                            cmd3.Parameters.Add(new SqlParameter("@mobile", pharmacy.Mobile));
                            cmd3.Parameters.Add(new SqlParameter("@email", pharmacy.Email));
                            cmd3.ExecuteNonQuery();

                            SqlCommand cmd4 = new SqlCommand(query, con);
                            query = "INSERT INTO PharmacyCertification (licence) " +
                               "VALUES (@licence)";
                            cmd4 = new SqlCommand(query, con);
                            cmd4.Parameters.Add(new SqlParameter("@licence", pharmacy.Licence));
                            cmd4.ExecuteNonQuery();

                            query = "SELECT TOP 1 * from PharmacyInfo order by pinfoid desc";
                            SqlCommand cmd5 = new SqlCommand(query, con);
                            SqlDataReader reader = cmd5.ExecuteReader();
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
                            query = "SELECT TOP 1 * from PharmacyAddress order by paddid desc";
                            SqlCommand cmd6 = new SqlCommand(query, con);
                            reader = cmd6.ExecuteReader();
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
                            query = "SELECT TOP 1 * from PharmacyContact order by pcontactid desc";
                            SqlCommand cmd7 = new SqlCommand(query, con);
                            reader = cmd7.ExecuteReader();
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
                            query = "SELECT TOP 1 * from PharmacyCertification order by pcertid desc";
                            SqlCommand cmd8 = new SqlCommand(query, con);
                            reader = cmd8.ExecuteReader();
                            if (reader != null)
                            {
                                if (reader.HasRows)
                                {
                                    if (reader.Read())
                                    {
                                        certid = int.Parse(reader["pcertid"].ToString());
                                    }
                                    reader.Close();
                                }
                            }
                            SqlCommand cmd9 = new SqlCommand(query, con);
                            query = "INSERT INTO PharmacyMaster (pinfoid, paddid, pcontactid, pcertid) " +
                                    "VALUES (@pinfoid, @paddid, @pcontactid, @pcertid)";
                            cmd9 = new SqlCommand(query, con);
                            cmd9.Parameters.Add(new SqlParameter("@pinfoid", infoid));
                            cmd9.Parameters.Add(new SqlParameter("@paddid", addid));
                            cmd9.Parameters.Add(new SqlParameter("@pcontactid", contactid));
                            cmd9.Parameters.Add(new SqlParameter("@pcertid", certid));
                            cmd9.ExecuteNonQuery();
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

        public static bool ValidateUser(string username, string password)
        {
            bool status = false;
            using (SqlConnection con = new SqlConnection(conString))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string Query = "select * from PharmacyInfo where username=@username and password=@password";
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

        public static List<Prescription> GetAll()
        {
            List<Prescription> prescriptions = new List<Prescription>();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT DoctorInfo.firstname,DoctorInfo.lastname,PrescriptionMaster.appointmentid,PrescriptionMaster.date,PrescriptionMaster.timeslot,PrescriptionMaster.details,PatientInfo.firstname,PatientInfo.lastname FROM ((DoctorInfo INNER JOIN PrescriptionMaster ON DoctorInfo.dinfoid=PrescriptionMaster.dinfoid) INNER JOIN PatientInfo ON PatientInfo.pinfoid=PrescriptionMaster.pinfoid)";
                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Prescription prescription = new Prescription()
                                {
                                    Pfirstname=reader["firstname"].ToString(),
                                    Plastname=reader["lastname"].ToString(),
                                    Dfirstname=reader["firstname"].ToString(),
                                    Dlastname = reader["lastname"].ToString(),
                                    Appointmentid=int.Parse(reader["appointmentid"].ToString()),
                                    Dinfoid=int.Parse(reader["dinfoid"].ToString()),
                                    Pinfoid=int.Parse(reader["pinfoid"].ToString()),
                                    Date=reader["date"].ToString(),
                                    Timeslot=reader["timeslot"].ToString(),
                                    Details=reader["details"].ToString()
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
