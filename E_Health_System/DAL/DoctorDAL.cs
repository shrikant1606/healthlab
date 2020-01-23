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
    public class DoctorDAL
    {
        private static string conString = string.Empty;
        static DoctorDAL()
        {
            conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\PG-DAC\DAC\Project\E_Health_System\Database\e_health_db.mdf;Integrated Security=True";
        }
        public static bool Insert(Doctor doctor)
        {
            bool status = false;
            int infoid = 0;
            int addid = 0;
            int contactid = 0;
            int certid = 0;
            int timeid = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "INSERT INTO DoctorInfo (username, password, firstname, lastname, dob, gender) " +
                        "VALUES (@username, @password, @firstname, @lastname, @dob, @gender)";
                    SqlCommand cmd1 = new SqlCommand(query, con);
                    cmd1.Parameters.Add(new SqlParameter("@username", doctor.Username));
                    cmd1.Parameters.Add(new SqlParameter("@password", doctor.Password));
                    cmd1.Parameters.Add(new SqlParameter("@firstname", doctor.Firstname));
                    cmd1.Parameters.Add(new SqlParameter("@lastname", doctor.Lastname));
                    cmd1.Parameters.Add(new SqlParameter("@dob", doctor.Dob));
                    cmd1.Parameters.Add(new SqlParameter("@gender", doctor.Gender));
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand(query, con);
                    query = "INSERT INTO DoctorAddress (address, city, state, pincode) " +
                       "VALUES (@address, @city, @state, @pincode)";
                    cmd2 = new SqlCommand(query, con);
                    cmd2.Parameters.Add(new SqlParameter("@address", doctor.Address));
                    cmd2.Parameters.Add(new SqlParameter("@city", doctor.City));
                    cmd2.Parameters.Add(new SqlParameter("@state", doctor.State));
                    cmd2.Parameters.Add(new SqlParameter("@pincode", doctor.Pincode));
                    cmd2.ExecuteNonQuery();

                    SqlCommand cmd3 = new SqlCommand(query, con);
                    query = "INSERT INTO DoctorContact (mobile, email) " +
                       "VALUES (@mobile, @email)";
                    cmd3 = new SqlCommand(query, con);
                    cmd3.Parameters.Add(new SqlParameter("@mobile", doctor.Mobile));
                    cmd3.Parameters.Add(new SqlParameter("@email", doctor.Email));
                    cmd3.ExecuteNonQuery();

                    SqlCommand cmd4 = new SqlCommand(query, con);
                    query = "INSERT INTO DoctorCertification (licence, specialization, certification, fees, experience) " +
                       "VALUES (@licence, @specialization, @certification, @fees, @experience)";
                    cmd4 = new SqlCommand(query, con);
                    cmd4.Parameters.Add(new SqlParameter("@licence", doctor.Licence));
                    cmd4.Parameters.Add(new SqlParameter("@specialization", doctor.Specialization));
                    cmd4.Parameters.Add(new SqlParameter("@certification", doctor.Certification));
                    cmd4.Parameters.Add(new SqlParameter("@fees", doctor.Fees));
                    cmd4.Parameters.Add(new SqlParameter("@experience", doctor.Experience));
                    cmd4.ExecuteNonQuery();

                    SqlCommand cmd5 = new SqlCommand(query, con);
                    query = "INSERT INTO DoctorTimeSlot (checkin, checkout) " +
                            "VALUES (@checkin, @checkout)";
                    cmd5 = new SqlCommand(query, con);
                    cmd5.Parameters.Add(new SqlParameter("@checkin", doctor.Checkin));
                    cmd5.Parameters.Add(new SqlParameter("@checkout", doctor.Checkout));
                    cmd5.ExecuteNonQuery();

                    query = "SELECT TOP 1 * from DoctorInfo order by dinfoid desc";
                    SqlCommand cmd6 = new SqlCommand(query, con);
                    SqlDataReader reader = cmd6.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                infoid = int.Parse(reader["dinfoid"].ToString());
                            }
                            reader.Close();
                        }
                    }
                    query = "SELECT TOP 1 * from DoctorAddress order by daddid desc";
                    SqlCommand cmd7 = new SqlCommand(query, con);
                    reader = cmd7.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                addid = int.Parse(reader["daddid"].ToString());
                            }
                            reader.Close();
                        }
                    }
                    query = "SELECT TOP 1 * from DoctorContact order by dcontactid desc";
                    SqlCommand cmd8 = new SqlCommand(query, con);
                    reader = cmd8.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                contactid = int.Parse(reader["dcontactid"].ToString());
                            }
                            reader.Close();
                        }
                    }
                    query = "SELECT TOP 1 * from DoctorCertification order by dcertid desc";
                    SqlCommand cmd9 = new SqlCommand(query, con);
                    reader = cmd9.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                certid = int.Parse(reader["dcertid"].ToString());
                            }
                            reader.Close();
                        }
                    }
                    query = "SELECT TOP 1 * from DoctorTimeSlot order by dtimeid desc";
                    SqlCommand cmd10 = new SqlCommand(query, con);
                    reader = cmd10.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                timeid = int.Parse(reader["dtimeid"].ToString());
                            }
                            reader.Close();
                        }
                    }
                    SqlCommand cmd11 = new SqlCommand(query, con);
                    query = "INSERT INTO DoctorMaster (dinfoid, daddid, dcontactid, dcertid, dtimeid) " +
                            "VALUES (@dinfoid, @daddid, @dcontactid, @dcertid, @dtimeid)";
                    cmd11 = new SqlCommand(query, con);
                    cmd11.Parameters.Add(new SqlParameter("@dinfoid", infoid));
                    cmd11.Parameters.Add(new SqlParameter("@daddid", addid));
                    cmd11.Parameters.Add(new SqlParameter("@dcontactid", contactid));
                    cmd11.Parameters.Add(new SqlParameter("@dcertid", certid));
                    cmd11.Parameters.Add(new SqlParameter("@dtimeid", timeid));
                    cmd11.ExecuteNonQuery();
                    
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
                string Query = "select * from DoctorInfo where username=@username and password=@password";
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

        public static List<Doctor> GetAll()
        {
            List<Doctor> doctors = new List<Doctor>();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM DoctorInfo";
                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Doctor doctor = new Doctor()
                                {
                                    Firstname = reader["firstname"].ToString(),
                                    Lastname = reader["lastname"].ToString()
                                };
                                doctors.Add(doctor);
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
            return doctors;
        }

        public static Doctor Get(string firstname)
        {
            Doctor doctor = null;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT i.firstname, i.lastname, a.address, a.city, a.state, c.mobile, c.email, cert.specialization, cert.fees, cert.certification, t.checkin, t.checkout" +
                        "FROM DoctorInfo i " +
                        "INNER JOIN DoctorMaster dm on i.dinfoid=dm.dinfoid" +
                        "INNER JOIN DoctorAddress a on dm.daddid=a.daddid" +
                        "INNER JOIN DoctorContact c on dm.dcontactid=c.dcontactid" +
                        "INNER JOIN DoctorCertification cert on dm.dcertid=cert.dcertid" +
                        "INNER JOIN DoctorTimeSlot t on dm.dtimeid=t.dtimeid" +
                        "WHERE (i.firstname=@firstname)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@firstname", firstname));
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                doctor = new Doctor()
                                {
                                    Firstname = reader["firstname"].ToString(),
                                    Lastname = reader["lastname"].ToString(),
                                    Fees = int.Parse(reader["fees"].ToString()),
                                };
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
            return doctor;
        }

        public static bool Reset()
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "DBCC CHECKIDENT('DoctorMaster', reseed, 0)";
                    SqlCommand cmd12 = new SqlCommand(query, con);
                    cmd12 = new SqlCommand(query, con);
                    cmd12.ExecuteNonQuery();
                    query = "DBCC CHECKIDENT('DoctorInfo', reseed, 0)";
                    cmd12 = new SqlCommand(query, con);
                    cmd12 = new SqlCommand(query, con);
                    cmd12.ExecuteNonQuery();
                    query = "DBCC CHECKIDENT('DoctorAddress', reseed, 0)";
                    cmd12 = new SqlCommand(query, con);
                    cmd12 = new SqlCommand(query, con);
                    cmd12.ExecuteNonQuery();
                    query = "DBCC CHECKIDENT('DoctorContact', reseed, 0)";
                    cmd12 = new SqlCommand(query, con);
                    cmd12 = new SqlCommand(query, con);
                    cmd12.ExecuteNonQuery();
                    query = "DBCC CHECKIDENT('DoctorCertification', reseed, 0)";
                    cmd12 = new SqlCommand(query, con);
                    cmd12 = new SqlCommand(query, con);
                    cmd12.ExecuteNonQuery();
                    query = "DBCC CHECKIDENT('DoctorTimeSlot', reseed, 0)";
                    cmd12 = new SqlCommand(query, con);
                    cmd12 = new SqlCommand(query, con);
                    cmd12.ExecuteNonQuery();
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
