using System;
using System.Collections.Generic;

namespace WDT_Assignment1
{
    class Controller
    {
        private View view;
        private Model model;

        private bool exit = false;
        private readonly List<string> mainMenuOptions;
        private readonly List<string> staffMenuOptions;
        private readonly List<string> studentMenuOptions;

        private List<string> currentMenu;

        public Controller()
        {
            mainMenuOptions = new List<string>
            {
                "Main menu:",
                "List rooms",
                "List slots",
                "Staff menu",
                "Student menu",
                "Exit"
            };

            staffMenuOptions = new List<string>
            {
                "Staff menu:",
                "List staff",
                "Room availability",
                "Create slot",
                "Remove slot",
                "Exit"
            };

            studentMenuOptions = new List<string>
            {
                "Student menu:",
                "Staff availability",
                "Make booking",
                "Cancel booking",
                "Exit"
            };

            view = new View();
            model = new Model();
        }

        public void Run()
        {
            currentMenu = mainMenuOptions;

            view.PrintMenu(currentMenu);

            while (!exit)
            {
                var input = Console.ReadLine();
                ProcessMenuOption(input);
                view.PrintMenu(currentMenu);
            }
        }

        private void ProcessMenuOption(string input)
        {
            if(currentMenu == mainMenuOptions)
            {
                ProcessMainMenuOption(input);
            }
            else if(currentMenu == staffMenuOptions)
            {
                ProcessStaffMenuOption(input);
            }
            else if(currentMenu == studentMenuOptions)
            {
                ProcessStudentMenuOption(input);
            }
        }

        private void ProcessMainMenuOption(string input)
        {
            switch (input)
            {
                case "1":
                    var rooms = model.GetRooms();
                    view.ListRooms(rooms);
                    break;
                case "2":
                    var slots = model.GetSlots();
                    view.ListSlots(slots);
                    break;
                case "3":                    
                    currentMenu = staffMenuOptions;   //change to staff menu
                    break;
                case "4":
                    currentMenu = studentMenuOptions; //change to student menu
                    break;
                case "5":
                    exit = true;
                    break;
            }
        }

        private void ProcessStaffMenuOption(string input)
        {
            switch (input)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    exit = true;
                    break;
            }
        }

        private void ProcessStudentMenuOption(string input)
        {
            switch (input)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    exit = true;
                    break;
            }
        }
    }
}
