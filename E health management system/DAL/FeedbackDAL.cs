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
    public class FeedbackDAL
    {
        private static string conString = string.Empty;
        static FeedbackDAL()
        {
            conString = ConfigurationManager.ConnectionStrings["e_health_db"].ConnectionString;
        }

        public static bool Feedback(Feedback feedback)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT pinfoid from PatientInfo where username=@username";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@username", feedback.Pusername));
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                {
                                    feedback.Pinfoid = int.Parse(reader["pinfoid"].ToString());
                                };
                            }
                            reader.Close();
                        }
                    }

                    query = "SELECT dinfoid from DoctorInfo where firstname=@firstname and lastname=@lastname";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@firstname", feedback.Dfirstname));
                    cmd.Parameters.Add(new SqlParameter("@lastname", feedback.Dlastname));
                    reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                {
                                    feedback.Dinfoid = int.Parse(reader["dinfoid"].ToString());
                                };
                            }
                            reader.Close();
                        }
                    }

                    query = "INSERT INTO FeedbackMaster (dinfoid, pinfoid, details, date) " +
                        "VALUES (@dinfoid, @pinfoid, @details, @date)";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@dinfoid", feedback.Dinfoid));
                    cmd.Parameters.Add(new SqlParameter("@pinfoid", feedback.Pinfoid));
                    cmd.Parameters.Add(new SqlParameter("@details", feedback.Details));
                    cmd.Parameters.Add(new SqlParameter("@date", feedback.Date));
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
