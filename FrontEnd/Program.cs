﻿using BusinessLogic;

namespace FrontEnd
{
    public class Program
    {
        static LoginPage session = new LoginPage();
        public static void Main(string[] args)
        {
            bool loginStatus = false;
            bool running = true;

            while (running)
            {
                //login
                if (loginStatus == false)
                {
                    Console.WriteLine("Press 1 to Login.\nPress 2 to exit.");
                    int loginChoice = 0;
                    int.TryParse(Console.ReadLine(), out loginChoice);
                    Console.Clear();
                    if (loginChoice == 1)
                    {
                        loginStatus = session.login();
                    }
                    else if (loginChoice == 2)
                    {
                        running = false;
                        Console.Clear();
                    }

                }
                //Home page+
                while (loginStatus)
                {
                    int choice = 0;
                    Console.WriteLine("press 1 to view doctorDetails\npress 5 to logout.");
                    int.TryParse(Console.ReadLine(), out choice);
                    Console.Clear();
                    switch (choice)
                    {
                        case 1:
                            List<string> list = new List<string>();
                            list = Doctors.DoctorsList();
                            foreach (var item in list)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        case 5:
                            loginStatus = false;
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Enter a valid choice.");
                            break;
                    }
                }
            }
        }
    }
}