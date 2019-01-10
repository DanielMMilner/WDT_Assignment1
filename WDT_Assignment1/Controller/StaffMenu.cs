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
                "Return to Main Menu"
            };
        }

        public override bool ProcessMenu(string input)
        {
            switch (input)
            {
                case "1":   //List staff
                    var staff = model.GetPersons(true);
                    view.ListPeople(true, staff);
                    return false;
                case "2":   //Room availability
                    view.ShowPrompt("Enter date for room availability (dd-mm-yyyy):");
                    var date = Console.ReadLine();
                    //TODO: check date format is correct

                    var rooms = model.GetRoomsOnDate(date);

                    view.ListRooms(rooms);

                    return false;
                case "3":   //Create slot
                    return false;
                case "4":   //Remove slot
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
