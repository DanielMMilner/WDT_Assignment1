using System;
using System.Collections.Generic;

namespace WDT_Assignment1
{
    class MainMenu : Menu
    {
        public MainMenu(Model model, View view, Controller controller) : base(model, view, controller)
        {
            menuName = "Main";

            options = new List<string>
            {
                "List rooms",
                "List slots",
                "Staff menu",
                "Student menu",
                "Exit"
            };
        }

        public override void ProcessMenu(string input)
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
                    controller.ChangeCurrentMenu("Staff");       //change to staff menu
                    break;
                case "4":
                    controller.ChangeCurrentMenu("Student");     //change to student menu
                    break;
                case "5":
                    break;
                default:
                    view.ErrorMessage("Invalid Input");
                    break;
            }
        }
    }
}
