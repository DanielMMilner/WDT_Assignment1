using System;
using System.Collections.Generic;

namespace WDT_Assignment1
{
    class StudentMenu : Menu
    {
        public StudentMenu(Model model, View view, Controller controller) : base(model, view, controller)
        {
            MenuName = "Student";

            Options = new List<string>
            {
                "List students",
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
                case "1":   //List students
                    var students = model.GetPersons(false);
                    view.ListPeople(false, students);
                    return false;
                case "2":   //Staff availability
                    return false;
                case "3":   //Make booking
                    return false;
                case "4":   //Cancel booking
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
