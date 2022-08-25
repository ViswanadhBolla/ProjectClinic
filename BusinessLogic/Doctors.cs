using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessLogic
{
    public class Doctors
    {
        static SqlDataReader DR;
        static DataBase DB = new DataBase();

        private static string drToString(SqlDataReader record)
        {
            string concat = "";
            for (int i = 0; i < DR.FieldCount; i++)
            {
                concat += DR[i] + " ";
            }
            return concat;
        }
        public static List<string> DoctorsList()
        {
            List<string> listOfDocotrs = new List<string>();
            DR = DB.getDocotrDetails();
            while (DR.Read())
            {
                listOfDocotrs.Add(drToString(DR));
            }
            return listOfDocotrs;
        }
    }
}
