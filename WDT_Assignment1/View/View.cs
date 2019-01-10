using System;
using System.Collections.Generic;

namespace WDT_Assignment1
{
    public class View
    {
        public View() { }

        public void PrintMenu(string menuName, List<string> menuOptions)
        {
            Console.WriteLine(menuName + " Menu:");
            var optionNum = 1;
            foreach(string option in menuOptions)
            {
                Console.WriteLine("    " + optionNum + ". " + option);
                optionNum++;
            }
        }

        public void ListRooms(string rooms)
        {
            Console.WriteLine("--- List Rooms ---");
            Console.WriteLine(rooms);
        }

        public void ListSlots(string slots)
        {
            Console.WriteLine("--- List Slots ---");
            Console.WriteLine("Room name       Start time        End time       Staff ID        Bookings");

            Console.WriteLine(slots);
        }

        public void ListPeople(bool isStaff, List<Person> people)
        {
            Console.WriteLine("--- List Staff ---");
            Console.WriteLine("ID       Name        Email");
            foreach(Person p in people)
            {
                Console.WriteLine(p.Id + "      " + p.Name + "      " + p.Email);
            }
        }

        public void ErrorMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void Exit()
        {
            Console.WriteLine("Now exiting...");
        }
    }
}
