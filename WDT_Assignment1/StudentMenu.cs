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

        public override bool ProcessMenu(string input)
        {
            switch (input)
            {
                case "1":   //Staff availability
                    return false;
                case "2":   //Make booking
                    return false;
                case "3":   //Cancel booking
                    return false;
                case "4":   //Exit
                    view.Exit();
                    return true;
                default:
                    view.ErrorMessage("Invalid Input");
                    return false;
            }
        }
    }
}
