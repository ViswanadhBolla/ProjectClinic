using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessLogic
{
    public class Appointment
    {
        int patientID, doctorID;
        List<string> specializations = new List<string>() { "General Medicine", "InternalMedicine" };
        DateOnly visitDate;
        static SqlDataReader listOfDoctors, patientrecord;
        static DataBase db = new DataBase();
        List<DoctorClass> doctorObjects = new List<DoctorClass>() ;
        DateTime appointTime;


        public int PatientID
        {
            get { return patientID; }
            set
            {
                patientrecord = db.getPatientDetails(value);
                bool flag = false;
                while (patientrecord.Read())
                {
                    flag = true;
                }
                if (flag)
                {
                    patientID = value;
                }
                else
                {
                    Console.WriteLine("patient ID not found");
                    getpatientID();
                }
            }
        }

        public DateOnly VisitDate
        {
            get { return visitDate; }
            set
            {
                if (value > DateOnly.FromDateTime(DateTime.Now))
                {
                    visitDate = value;
                }
                else
                {
                    Console.WriteLine("enter a valid date.");
                    getAppointDate();
                }
            }
        }
        public void getpatientID()
        {
            Console.Write("Enter patient ID: ");
            PatientID = Convert.ToInt32(Console.ReadLine());
        }
        public void specializationReq()
        {
            Console.WriteLine("Enter the specialization required: ");
            for (int i = 0; i < specializations.Count; i++)
            {
                Console.WriteLine((i + 1) + " " + specializations[i]);
            }
            int choice = 0;
            int.TryParse(Console.ReadLine(), out choice);
            if (choice > 0 && choice < specializations.Count)
            {
                listOfDoctors = db.getDocotrDetailsSpecialization(specializations[choice - 1]);
            }
            else
            {
                Console.WriteLine("Choice not found.");
                specializationReq();
            }

        }

        public void getAppointDate()
        {
            Console.Write("Enter the date of apoointment: ");
            VisitDate = DateOnly.FromDateTime(Convert.ToDateTime(Console.ReadLine()));

        }

        public void createDocotorObj()
        {
            while (listOfDoctors.Read())
            {
                DoctorClass newdoc = new DoctorClass(
                    (int)listOfDoctors[0],
                    (string)listOfDoctors[1],
                    (string)listOfDoctors[2],
                    (string)listOfDoctors[3],
                    (string)listOfDoctors[4],
                    TimeOnly.Parse(listOfDoctors[5].ToString()),
                    TimeOnly.Parse(listOfDoctors[6].ToString()));
                doctorObjects.Add(newdoc);
            }

            foreach (DoctorClass doc in doctorObjects)
            {
                SqlDataReader booked = db.getDoctorAppointments(doc.DocID,visitDate);
                while (booked.Read())
                {
                    doc.slots.Remove(TimeOnly.Parse(booked[0].ToString()));
                }
            }


        }

        public void selectDoctor()
        {
            int i = 1;
            Console.WriteLine("Choose one of the doctrs:");
            foreach(DoctorClass doc in doctorObjects)
            {
                Console.WriteLine(i+" "+doc.slotsAvailability());
                i += 1;
            }
            int docChoice;
            int.TryParse(Console.ReadLine(),out docChoice);
            if(docChoice > 0 && docChoice < doctorObjects.Count)
            {
                doctorID = doctorObjects[docChoice-1].DocID;
                appointTime = visitDate.ToDateTime(doctorObjects[docChoice - 1].slots[0]);
            }

        }

        public void bookAppointment()
        {
            int i = db.insertAppointment(patientID,doctorID,appointTime);
            if (i > 0)
            {
                Console.WriteLine("appointment Booked");
            }
            else
            {
                Console.WriteLine("appointment not booked");
            }
        }


        public void createAppointment()
        {
            getpatientID();
            specializationReq();
            getAppointDate();
            createDocotorObj();
            selectDoctor();
            bookAppointment();

        }
    }
}
