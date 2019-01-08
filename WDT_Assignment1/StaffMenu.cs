using System;
using System.Collections.Generic;

namespace WDT_Assignment1
{
    class StaffMenu : Menu
    {
        public StaffMenu(Model model, View view, Controller controller) : base(model, view, controller)
        {
            menuName = "Staff";

            options = new List<string>
            {
                "List staff",
                "Room availability",
                "Create slot",
                "Remove slot",
                "Exit"
            };
        }

        public override void ProcessMenu(string input)
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
                    break;
                default:
                    view.ErrorMessage("Invalid Input");
                    break;
            }
        }
    }
}
