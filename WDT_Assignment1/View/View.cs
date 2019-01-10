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

        public void ListRooms(List<string> rooms)
        {
            Console.WriteLine("--- List Rooms ---");
            foreach(string room in rooms)
            {
                Console.WriteLine(room);
            }
        }

        public void ListSlots(List<Slot> slots)
        {
            //TODO: Fix formatting
            Console.WriteLine("--- List Slots ---");
            Console.WriteLine("Room name       Start time        End time       Staff ID        Bookings");

            foreach (Slot slot in slots)
            {
                Console.WriteLine(slot.RoomName + "    " + slot.StartTime + "   " + slot.EndTime + "    " + slot.StaffId + "    " + slot.Bookings);
            }
        }

        public void ShowPrompt(string prompt)
        {
            Console.WriteLine(prompt);
        }

        public void ListPeople(bool isStaff, List<Person> people)
        {
            //TODO: Fix formatting
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
