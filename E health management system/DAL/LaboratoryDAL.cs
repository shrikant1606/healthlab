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
    public class LaboratoryDAL
    {
        private static string conString = string.Empty;
        static LaboratoryDAL()
        {
            conString = ConfigurationManager.ConnectionStrings["e_health_db"].ConnectionString;
        }
        public static bool Insert(Laboratory laboratory)
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

                    string query = "SELECT username from LaboratoryInfo where username = @username";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@username", laboratory.Username));
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
                            query = "INSERT INTO LaboratoryInfo (username, password, laboratoryname, inchargename) " +
                            "VALUES (@username, @password, @laboratoryname, @inchargename)";
                            SqlCommand cmd1 = new SqlCommand(query, con);
                            cmd1.Parameters.Add(new SqlParameter("@username", laboratory.Username));
                            cmd1.Parameters.Add(new SqlParameter("@password", laboratory.Password));
                            cmd1.Parameters.Add(new SqlParameter("@laboratoryname", laboratory.Laboratoryname));
                            cmd1.Parameters.Add(new SqlParameter("@inchargename", laboratory.Inchargename));
                            cmd1.ExecuteNonQuery();

                            SqlCommand cmd2 = new SqlCommand(query, con);
                            query = "INSERT INTO LaboratoryAddress (address, city, state, pincode) " +
                               "VALUES (@address, @city, @state, @pincode)";
                            cmd2 = new SqlCommand(query, con);
                            cmd2.Parameters.Add(new SqlParameter("@address", laboratory.Address));
                            cmd2.Parameters.Add(new SqlParameter("@city", laboratory.City));
                            cmd2.Parameters.Add(new SqlParameter("@state", laboratory.State));
                            cmd2.Parameters.Add(new SqlParameter("@pincode", laboratory.Pincode));
                            cmd2.ExecuteNonQuery();

                            SqlCommand cmd3 = new SqlCommand(query, con);
                            query = "INSERT INTO LaboratoryContact (mobile, email) " +
                               "VALUES (@mobile, @email)";
                            cmd3 = new SqlCommand(query, con);
                            cmd3.Parameters.Add(new SqlParameter("@mobile", laboratory.Mobile));
                            cmd3.Parameters.Add(new SqlParameter("@email", laboratory.Email));
                            cmd3.ExecuteNonQuery();

                            SqlCommand cmd4 = new SqlCommand(query, con);
                            query = "INSERT INTO LaboratoryCertification (licence) " +
                               "VALUES (@licence)";
                            cmd4 = new SqlCommand(query, con);
                            cmd4.Parameters.Add(new SqlParameter("@licence", laboratory.Licence));
                            cmd4.ExecuteNonQuery();

                            query = "SELECT TOP 1 * from LaboratoryInfo order by linfoid desc";
                            SqlCommand cmd5 = new SqlCommand(query, con);
                            SqlDataReader reader = cmd5.ExecuteReader();
                            if (reader != null)
                            {
                                if (reader.HasRows)
                                {
                                    if (reader.Read())
                                    {
                                        infoid = int.Parse(reader["linfoid"].ToString());
                                    }
                                    reader.Close();
                                }
                            }
                            query = "SELECT TOP 1 * from LaboratoryAddress order by laddid desc";
                            SqlCommand cmd6 = new SqlCommand(query, con);
                            reader = cmd6.ExecuteReader();
                            if (reader != null)
                            {
                                if (reader.HasRows)
                                {
                                    if (reader.Read())
                                    {
                                        addid = int.Parse(reader["laddid"].ToString());
                                    }
                                    reader.Close();
                                }
                            }
                            query = "SELECT TOP 1 * from LaboratoryContact order by lcontactid desc";
                            SqlCommand cmd7 = new SqlCommand(query, con);
                            reader = cmd7.ExecuteReader();
                            if (reader != null)
                            {
                                if (reader.HasRows)
                                {
                                    if (reader.Read())
                                    {
                                        contactid = int.Parse(reader["lcontactid"].ToString());
                                    }
                                    reader.Close();
                                }
                            }
                            query = "SELECT TOP 1 * from LaboratoryCertification order by lcertid desc";
                            SqlCommand cmd8 = new SqlCommand(query, con);
                            reader = cmd8.ExecuteReader();
                            if (reader != null)
                            {
                                if (reader.HasRows)
                                {
                                    if (reader.Read())
                                    {
                                        certid = int.Parse(reader["lcertid"].ToString());
                                    }
                                    reader.Close();
                                }
                            }
                            SqlCommand cmd9 = new SqlCommand(query, con);
                            query = "INSERT INTO LaboratoryMaster (linfoid, laddid, lcontactid, lcertid) " +
                                    "VALUES (@linfoid, @laddid, @lcontactid, @lcertid)";
                            cmd9 = new SqlCommand(query, con);
                            cmd9.Parameters.Add(new SqlParameter("@linfoid", infoid));
                            cmd9.Parameters.Add(new SqlParameter("@laddid", addid));
                            cmd9.Parameters.Add(new SqlParameter("@lcontactid", contactid));
                            cmd9.Parameters.Add(new SqlParameter("@lcertid", certid));
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
                string Query = "select * from LaboratoryInfo where username=@username and password=@password";
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
    }
}
