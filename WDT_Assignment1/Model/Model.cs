using System;
using System.Collections.Generic;

namespace WDT_Assignment1
{
    class Model
    {
        public Model()
        {
            
        }

        public String GetRooms()
        {
            return "Rooms";
        }

        public String GetSlots()
        {
            return "Slots";
        }

        public List<Person> GetPersons(bool getStaffMembers)
        {
            List<Person> people = new List<Person>();

            //Talk to database and get the all the staff/students
            //conver each staff member into person object an place in list
            if (getStaffMembers)
            {
                //get staff
            }
            else
            {
                //get students
            }

            return people;
        }
    }
}
