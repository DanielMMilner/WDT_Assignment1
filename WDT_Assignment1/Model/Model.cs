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

        public List<Slot> GetSlots(string date)
        {
            List<Slot> slots = new List<Slot>();

            //TODO: Talk to database and get the slots
            //add the slots to the list
            slots.Add(new Slot("room A", "1pm", "2pm", "Staff1", "-"));
            slots.Add(new Slot("room A", "2pm", "3pm", "Staff1", "-"));
            slots.Add(new Slot("room B", "3pm", "4pm", "Staff2", "-"));
            slots.Add(new Slot("room B", "4pm", "5pm", "Staff2", "-"));
            slots.Add(new Slot("room C", "1pm", "2pm", "Staff3", "-"));

            return slots;
        }

        public List<Person> GetPersons(bool getStaffMembers)
        {
            List<Person> people = new List<Person>();

            //TODO: Talk to database and get the all the staff/students
            //convert each staff member into person object an place in list
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

        public List<StaffAvailability> GetStaffAvailability(string date, string staffId)
        {
            List<StaffAvailability> staffAvailabilities = new List<StaffAvailability>();

            //TODO: talk to database and get staff availabilities using date and staff Id
            //place availabilities in list

            staffAvailabilities.Add(new StaffAvailability("RoomA", "1pm", "2pm"));
            staffAvailabilities.Add(new StaffAvailability("RoomB", "2pm", "3pm"));
            staffAvailabilities.Add(new StaffAvailability("RoomC", "3pm", "5pm"));
            staffAvailabilities.Add(new StaffAvailability("RoomD", "10pm", "12am"));

            return staffAvailabilities;            
        }
    }
}
