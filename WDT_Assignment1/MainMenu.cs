using System;
using System.Collections.Generic;

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
                    var rooms = model.GetRooms();
                    view.ListRooms(rooms);
                    return false;
                case "2":   //List Slots
                    var slots = model.GetSlots();
                    view.ListSlots(slots);
                    return false;
                case "3":   //Staff menu
                    controller.ChangeCurrentMenu("Staff");
                    return false;
                case "4":   //Student menu
                    controller.ChangeCurrentMenu("Student");
                    return false;
                case "5":   //Exit
                    view.Exit();
                    return true;
                default:
                    view.ErrorMessage("Invalid Input");
                    return false;
            }
        }
    }
}
