using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
    }
}
