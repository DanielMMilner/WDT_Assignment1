using System;
using System.Collections.Generic;

namespace WDT_Assignment1
{
    class StudentMenu : Menu
    {
        public StudentMenu(Model model, View view, Controller controller) : base(model, view, controller)
        {
            menuName = "Student";

            options = new List<string>
            {
                "Staff availability",
                "Make booking",
                "Cancel booking",
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
                default:
                    view.ErrorMessage("Invalid Input");
                    break;
            }
        }
    }
}
