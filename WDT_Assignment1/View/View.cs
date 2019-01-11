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

        public void ListRooms(IEnumerable<string> rooms)
        {
            Console.WriteLine("--- List Rooms ---");
            foreach(string room in rooms)
            {
                Console.WriteLine(room);
            }
        }

        public void ListSlots(IEnumerable<Slot> slots)
        {
            //TODO: Fix formatting
            Console.WriteLine("--- List Slots ---");
            Console.WriteLine("Room name       Start time        Staff ID        Student ID");

            foreach (Slot slot in slots)
            {
                Console.WriteLine($"{slot.RoomName}    {slot.StartTime}    {slot.StaffId}    {slot.StudentId}");
            }
        }

        public void ShowPrompt(string prompt)
        {
            Console.WriteLine(prompt);
        }

        public void ListPeople(bool isStaff, IEnumerable<Person> people)
        {
            //TODO: Fix formatting
            Console.WriteLine("--- List Staff ---");
            Console.WriteLine("ID       Name        Email");
            foreach(Person p in people)
            {
                Console.WriteLine(p.Id + "      " + p.Name + "      " + p.Email);
            }
        }

        public void StaffAvailability(List<StaffAvailability> staffAvailabilities)
        {
            //TODO: Fix formatting
            Console.WriteLine("Room name       Start time        End time");

            foreach (StaffAvailability availability in staffAvailabilities)
            {
                Console.WriteLine(availability.RoomName + "    " + availability.StartTime + "   " + availability.EndTime);
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
