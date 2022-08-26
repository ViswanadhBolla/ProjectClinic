using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataBase
    {
        public static SqlConnection con;
        public static SqlCommand cmd;

        private static SqlConnection getCon()
        {
            con = new SqlConnection("Data Source=.;Initial Catalog=clinic;Integrated Security=true");
            con.Open();
            return con;
        }

        public SqlDataReader getUserDetails(string username, string password)
        {
            con = getCon();
            cmd = new SqlCommand("select * from UserInfo where username = @username and userpassword= @password", con);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            SqlDataReader DR = cmd.ExecuteReader();
            return DR;
        }

        public SqlDataReader getDocotrDetails()
        {
            con = getCon();
            cmd = new SqlCommand("select * from DoctorInfo", con);
            SqlDataReader DR = cmd.ExecuteReader();
            return DR;
        }

        public SqlDataReader getDocotrDetailsSpecialization(string specialization)
        {
            con = getCon();
            cmd = new SqlCommand("select * from DoctorInfo where specialization = @specialization", con);
            cmd.Parameters.AddWithValue("@specialization", specialization);
            SqlDataReader DR = cmd.ExecuteReader();
            return DR;
        }

        public SqlDataReader getDoctorAppointments(int docID, DateOnly visitdate)
        {
            con = getCon();
            cmd = new SqlCommand("select convert(time,appointTime) from appointments where doctorID = @docID and convert(date,appointTime) = @visitdate", con);
            cmd.Parameters.AddWithValue("@docID", docID);
            cmd.Parameters.AddWithValue("@visitdate", visitdate.ToDateTime(TimeOnly.Parse("00:00:00")));

            SqlDataReader DR = cmd.ExecuteReader();
            return DR;
        }

        public int addPatientDetails(string firstname, string lastname, string gender, int age, DateTime dob)
        {
            con = getCon();
            cmd = new SqlCommand("insertPatientData");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@firstname", firstname);
            cmd.Parameters.AddWithValue("@lastname", lastname);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@age", age);
            cmd.Parameters.AddWithValue("@dob", dob);
            cmd.Connection = con;
            int i = cmd.ExecuteNonQuery();
            return i;
        }

        public SqlDataReader getPatientDetails(int ID)
        {
            con = getCon();
            cmd = new SqlCommand("select * from patientInfo where patientID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", ID);
            SqlDataReader DR = cmd.ExecuteReader();
            return DR;
        }

        public int insertAppointment(int patientID, int docID, DateTime appointtime)
        {
            con = getCon();
            cmd = new SqlCommand("insert into appointments values(@patientID,@docID,@appointtime)", con);
            cmd.Parameters.AddWithValue("@patientID", patientID);
            cmd.Parameters.AddWithValue("@docID", docID);
            cmd.Parameters.AddWithValue("@appointtime", appointtime);
            int i = cmd.ExecuteNonQuery();
            return i;
        }
    }
}
