using System.Collections.Generic;

namespace WDT_Assignment1
{
    class MainMenu : Menu
    {
        public MainMenu(View view, Controller controller) : base(view, controller)
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
                case "1":   // List Rooms.
                    ListRooms();
                    return false;
                case "2":   // List Slots.
                    ListSlots();
                    return false;
                case "3":   // Staff menu.
                    controller.ChangeCurrentMenu(new StaffMenu(view,controller));
                    return false;
                case "4":   // Student menu.
                    controller.ChangeCurrentMenu(new StudentMenu(view, controller));
                    return false;
                case "5":   // Exit.
                    view.ShowPrompt("Now exiting...");
                    return true;
                default:
                    view.ShowPrompt("Invalid Input");
                    return false;
            }
        }

        private void ListRooms()
        {
            view.ListRooms(Model.Instance.Rooms);
        }

        private void ListSlots()
        {
            var date = userInput.GetDate();
            
            view.ListSlots(Model.Instance.GetSlotsOnDate(date));
        }
    }
}
