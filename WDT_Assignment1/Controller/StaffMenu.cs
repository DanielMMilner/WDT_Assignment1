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
                    view.ShowPrompt("Enter room name:");
                    var roomName = Console.ReadLine();
                    view.ShowPrompt("Enter date for slot (dd-mm-yyyy):");
                    var bookingDate = Console.ReadLine();
                    view.ShowPrompt("Enter time for slot (hh:mm):");
                    var time = Console.ReadLine();
                    view.ShowPrompt("Enter staff ID:");
                    var iD = Console.ReadLine();

                    bool success = model.CreateSlot(roomName, bookingDate, time, iD);

                    if (success)
                    {
                        view.ShowPrompt("Slot created successfully");
                    }
                    else
                    {
                        view.ShowPrompt("Failed to create slot");
                    }
                    return false;
                case "4":   //Remove slot
                    view.ShowPrompt("Enter room name:");
                    var roomNameRemove = Console.ReadLine();
                    view.ShowPrompt("Enter date for slot (dd-mm-yyyy):");
                    var bookingDateRemove = Console.ReadLine();
                    view.ShowPrompt("Enter time for slot (hh:mm):");
                    var timeRemove = Console.ReadLine();

                    bool suc = model.RemoveSlot(roomNameRemove, bookingDateRemove, timeRemove);

                    if (suc)
                    {
                        view.ShowPrompt("Slot removed successfully");
                    }
                    else
                    {
                        view.ShowPrompt("Failed to remove slot");
                    }
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
