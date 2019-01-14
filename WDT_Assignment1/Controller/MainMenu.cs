using System;
using System.Collections.Generic;
using System.Linq;

namespace WDT_Assignment1
{
    class MainMenu : Menu
    {
        public MainMenu(Model model, View view, Controller controller) : base(model, view, controller)
        {
            MenuName = "Main";

            Options = new List<string>
            {
                "List rooms",
                "List slots",
                "Staff menu",
                "Student menu",
                "Exit"
            };
        }

        public override bool ProcessMenu(string input)
        {
            switch (input)
            {
                case "1":   //List Rooms
                    ListRooms();
                    return false;
                case "2":   //List Slots
                    ListSlots();
                    return false;
                case "3":   //Staff menu
                    controller.ChangeCurrentMenu(new StaffMenu(model,view,controller));
                    return false;
                case "4":   //Student menu
                    controller.ChangeCurrentMenu(new StudentMenu(model, view, controller));
                    return false;
                case "5":   //Exit
                    view.ShowPrompt("Now exiting...");
                    return true;
                default:
                    view.ShowPrompt("Invalid Input");
                    return false;
            }
        }

        private void ListRooms()
        {
            view.ListRooms(model.Rooms);
        }

        private void ListSlots()
        {
            var date = userInput.GetDate();
            
            view.ListSlots(model.GetSlotsOnDate(date));
        }
    }
}
