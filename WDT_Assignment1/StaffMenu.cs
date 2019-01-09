using System;
using System.Collections.Generic;

namespace WDT_Assignment1
{
    class StaffMenu : Menu
    {
        public StaffMenu(Model model, View view, Controller controller) : base(model, view, controller)
        {
            MenuName = "Staff";

            Options = new List<string>
            {
                "List staff",
                "Room availability",
                "Create slot",
                "Remove slot",
                "Exit"
            };
        }

        public override bool ProcessMenu(string input)
        {
            switch (input)
            {
                case "1":   //List staff
                    return false;
                case "2":   //Room availability
                    return false;
                case "3":   //Create slot
                    return false;
                case "4":   //Remove slot
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
