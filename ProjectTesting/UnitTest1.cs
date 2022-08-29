using System.Data.SqlClient;
using System.Reflection;
using DataAccess;
namespace ProjectTesting
{
    public class Tests
    {
        public static DataBase db;
        public static SqlDataReader dr;
        [SetUp]
        public void Setup()
        {
            db = new DataBase();
        }

        [Test]
        public void Test1()
        {
            dr = db.getUserDetails("user1001", "userpass@1001");

            Assert.AreEqual(dr.HasRows.ToString(), true.ToString());
        }

        [Test]
        public void Test2()
        {
            int i = db.addPatientDetails("john", "doe", "male", 10, new DateTime(2012, 1, 1, 8, 30, 52));
            int expi = 1;
            Assert.AreEqual(expi, i);
        }
    }
}