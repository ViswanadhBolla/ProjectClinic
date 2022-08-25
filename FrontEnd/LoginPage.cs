using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace FrontEnd
{
    internal class LoginPage
    {
        string username = "", password = "";
        static DataBase db = new DataAccess.DataBase();
        static SqlDataReader DR;


        public string Username
        {
            get { return username; }
            set
            {
                if (value.Length <= 10 && value != "")
                {
                    username = value;
                }
                else
                {
                    Console.WriteLine("Invalid Username.");
                    usernameInput();
                }
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (value.Length <= 15 && value != "")
                {
                    password = value;
                }
                else
                {
                    Console.WriteLine("Invalid Password.");
                    passwordInput();
                }
            }
        }

        public void usernameInput()
        {
            Console.Write("Enter username: ");
            Username = Console.ReadLine();
        }
        public void passwordInput()
        {
            Console.Write("Enter Password: ");
            Password = Console.ReadLine();
        }
        public bool login()
        {
            bool retVal = false;
            usernameInput();
            passwordInput();
            DR = db.getUserDetails(Username, Password);

            Console.Clear();
            while (DR.Read())
            {
                retVal = true;
                Console.WriteLine("Welcome " + DR[1] + " " + DR[2]);
            }
            if (retVal == false)
            {

                Console.WriteLine("User not Found");
            }
            return retVal;
        }

        public void printDetails()
        {
            Console.WriteLine("Username :" + Username + " Password : " + Password);
        }
    }
}
