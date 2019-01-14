
using System;
using System.Collections.Generic;

namespace WDT_Assignment1
{
    public class View
    {
        public View() { }

        public void PrintMenu(string menuName, List<string> menuOptions)
        {
            Console.WriteLine($"{menuName} Menu:");
            var optionNum = 1;
            foreach(string option in menuOptions)
            {
                Console.WriteLine($"    {optionNum}.  {option}");
                optionNum++;
            }
        }

        public void ListRooms(List<string> rooms)
        {
            Console.WriteLine("--- List Rooms ---");
            foreach (string room in rooms)
            {
                Console.WriteLine($"\t{room}");
            }
        }

        public void ListSlots(List<Slot> slots)
        {
            Console.WriteLine("--- List Slots ---");
            Console.WriteLine("\tRoom name\tStart time\tStaff ID\tStudent ID");

            foreach (Slot slot in slots)
            {
                Console.WriteLine($"\t{slot.RoomName, -15}\t{slot.StartTime.ToString("hh:mm tt"),-15}\t{slot.StaffId, -15}\t{slot.StudentId,-15}");
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
            Console.WriteLine("\tID\t\tName\t\tEmail");
            foreach(Person p in people)
            {
                Console.WriteLine($"\t{p.Id}\t\t{p.Name}\t\t{p.Email}");
            }
        }

        public void StaffAvailability(List<Slot> staffAvailabilities)
        {
            Console.WriteLine("\tRoom name\tStart time\tEnd time");

            foreach (Slot availability in staffAvailabilities)
            {
                Console.WriteLine($"\t{availability.RoomName,-10}\t{availability.StartTime.ToString("hh:mm tt")}" +
                    $"\t{availability.StartTime.AddHours(1).ToString("hh:mm tt")}");
            }
        }

        public void ErrorMessage(string msg)
        {
            Console.WriteLine($"An error has occured:\n{msg}");
        }
    }
}
