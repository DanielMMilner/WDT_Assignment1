using System;
using System.Collections.Generic;

namespace WDT_Assignment1
{
    class Model
    {
        public Model()
        {
            
        }

        public List<string> GetRooms()
        {
            List<string> rooms = new List<string>();

            //TODO: Talk to database and get the names of the rooms
            //add the rooms to the list
            rooms.Add("room1");
            rooms.Add("room2");
            rooms.Add("room3");

            return rooms;
        }

        public String GetSlots()
        {
            return "Slots";
        }

        public List<Person> GetPersons(bool getStaffMembers)
        {
            List<Person> people = new List<Person>();

            //TODO: Talk to database and get the all the staff/students
            //conver each staff member into person object an place in list
            if (getStaffMembers)
            {
                //get staff
                people.Add(new Person("1", "staff1", "email1"));
                people.Add(new Person("2", "staff2", "email2"));
                people.Add(new Person("3", "staff3", "email3"));
            }
            else
            {
                //get students
                people.Add(new Person("1", "student1", "email1"));
                people.Add(new Person("2", "student2", "email2"));
                people.Add(new Person("3", "student3", "email3"));
            }

            return people;
        }
    }
}
