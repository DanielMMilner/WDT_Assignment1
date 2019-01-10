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
            Console.WriteLine(rooms);
        }

        public void ListSlots(string slots)
        {
            Console.WriteLine(slots);
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
