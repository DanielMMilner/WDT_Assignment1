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
                "Return to Main Menu"
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
                    view.ShowPrompt("Enter date for staff availability (dd-mm-yyyy):");
                    var date = Console.ReadLine();
                    //TODO: check date format is correct

                    view.ShowPrompt("Enter staff ID:");
                    var staffId = Console.ReadLine();
                    //TODO: check staff ID format is correct

                    view.ShowPrompt("Staff " + staffId + " availability on " + date);

                    var availability = model.GetStaffAvailability(date, staffId);
                    view.StaffAvailability(availability);

                    return false;
                case "3":   //Make booking
                    return false;
                case "4":   //Cancel booking
                    return false;
                case "5":   //Return to Main Menu
                    controller.ChangeCurrentMenu(new MainMenu(model, view, controller));
                    return false;
                default:
                    view.ErrorMessage("Invalid Input");
                    return false;
            }
        }
    }
}
