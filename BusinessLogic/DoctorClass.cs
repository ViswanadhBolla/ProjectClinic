using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class DoctorClass
    {
        public int DocID { get; set; }
        string firstname;
        string lastname;
        string Gender;
        string specialization;
        TimeOnly startTime;
        TimeOnly endTime;
        public List<TimeOnly> slots = new List<TimeOnly>();
        public DoctorClass() { }

        public DoctorClass(int docID, string firstname, string lastname, string gender, string specialization, TimeOnly startTime, TimeOnly endTime)
        {
            DocID = docID;
            this.firstname = firstname;
            this.lastname = lastname;
            Gender = gender;
            this.specialization = specialization;
            this.startTime = startTime;
            this.endTime = endTime;

            while (startTime < endTime)
            {
                slots.Add(startTime);
                startTime = startTime.AddHours(1);
            }

        }

        public string PrintDetails()
        {
            string str = DocID + " " + firstname + " " + lastname+" "+Gender+" "+specialization+" "+startTime.ToString()+" "+endTime.ToString() ;
            return str;
        }

        public string slotsAvailability()
        {
            string str = "";
            if(slots.Count > 0)
            {
                foreach (var slot in slots)
                {
                    str += slot.ToString() + " ";
                }
            }
            else
            {
                str = "Slot unavailable";

            }

            return (firstname + " " + lastname +" "+ str);
        }
    }
}
