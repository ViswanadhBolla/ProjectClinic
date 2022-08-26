using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessLogic
{
    public class Patient
    {
        static DataBase DB = new DataBase();
        string firstname, lastname, gender;
        int age;
        DateTime dob;

        public string Firstname
        {
            get { return firstname; }
            set
            {
                if (Regex.IsMatch(value, @"^[a-zA-Z]+$") && value != null)
                {
                    firstname = value;
                }
                else
                {
                    Console.WriteLine("FirstName not valid enter again.");
                    getFN();
                }
            }
        }

        public string Lastname
        {
            get { return lastname; }
            set
            {
                if (Regex.IsMatch(value, @"^[a-zA-Z]+$") && value != null)
                {
                    lastname = value;
                }
                else
                {
                    Console.WriteLine("LastName not valid enter again.");
                    getLN();
                }
            }
        }

        public string Gender
        {
            get { return gender; }
            set
            {
                if (Regex.IsMatch(value, @"^[a-zA-Z]+$") && value != null)
                {
                    gender = value;
                }
                else
                {
                    Console.WriteLine("Gender is empty enter again.");
                    getGender();
                }
            }
        }

        public DateTime Dob
        {
            get { return dob; }
            set
            {
                if (DateTime.Today.Year - value.Year >= 0)
                {
                    dob = value;
                    age = DateTime.Today.Year - value.Year;
                }
                else
                {
                    Console.WriteLine("date not valid enter again.");
                    getDOB();
                }
            }
        }

        public void getFN()
        {
            Console.Write("Enter patient's firstname: ");
            Firstname = Console.ReadLine();
        }

        public void getLN()
        {
            Console.Write("Enter patient's lastname: ");
            Lastname = Console.ReadLine();
        }

        public void getGender()
        {
            Console.Write("Enter patient's gender: ");
            Gender = Console.ReadLine();
        }

        public void getDOB()
        {
            Console.Write("Enter patient's birth date: ");
            try
            {
                Dob = Convert.ToDateTime(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Enter a valid Date: ");
                getDOB();
            }
        }

        public int AddPatientData()
        {
            getFN();
            getLN();
            getGender();
            getDOB();

            int i = DB.addPatientDetails(Firstname, Lastname, Gender, age, Dob);
            return i;
        }



    }
}
