using System;
using System.Collections.Generic;

namespace WDT_Assignment1
{
    public class View
    {
        public View() { }

        public void PrintMenu(List<string> menuOptions)
        {
            var optionNum = 0;
            foreach(string option in menuOptions)
            {
                if (optionNum == 0)
                {
                    Console.WriteLine(option);
                }
                else
                {
                    Console.WriteLine("    " + optionNum + ". " + option);
                }
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
    }
}
