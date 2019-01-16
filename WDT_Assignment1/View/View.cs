using System;
using System.Collections.Generic;

namespace WDT_Assignment1
{
    public class View
    {
        public View() { }

        public void PrintMenu(string menuName, List<string> menuOptions)
        {
            Console.WriteLine($"\n{menuName} Menu:");
            var optionNum = 1;
            foreach(var option in menuOptions)
            {
                Console.WriteLine($"    {optionNum}.  {option}");
                optionNum++;
            }
        }

        public void ListRooms(List<string> rooms)
        {
            Console.WriteLine("--- List Rooms ---");
            foreach (var room in rooms)
            {
                Console.WriteLine($"\t{room}");
            }
        }

        public void ListSlots(List<Slot> slots)
        {
            Console.WriteLine("--- List Slots ---");
            Console.WriteLine("\tRoom name\tDate\t\tStart time\tStaff ID\tStudent ID");

            foreach (var slot in slots)
            {
                Console.WriteLine($"\t{slot.RoomName, -15}\t{slot.StartTime.ToString("dd/MM/yyyy"),-15}\t{slot.StartTime.ToString("h:mm tt"),-15}\t{slot.StaffId, -15}\t{slot.StudentId,-15}");
            }
        }

        public void ShowPrompt(string prompt)
        {
            Console.WriteLine(prompt);
        }

        public void ListPeople(List<Person> people)
        {
            if(people.Count > 0)
            {
                if (people[0].IsStaff)
                {
                    Console.WriteLine("--- List Staff ---");
                }
                else
                {
                    Console.WriteLine("--- List Students ---");
                }
            }

            Console.WriteLine("\tID\t\tName\t\tEmail");
            foreach(var p in people)
            {
                if (p.IsStaff)
                {
                    Console.WriteLine($"\t{p.Id}\t\t{p.Name}\t\t{p.Email}");
                }
                else
                {
                    Console.WriteLine($"\t{p.Id}\t{p.Name}\t\t{p.Email}");
                }
            }
        }

        public void StaffAvailability(List<Slot> staffAvailabilities)
        {
            Console.WriteLine("\tRoom name\tStart time\tEnd time");

            foreach (var availability in staffAvailabilities)
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
