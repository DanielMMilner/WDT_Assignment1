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
