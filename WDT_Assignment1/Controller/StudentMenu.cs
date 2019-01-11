using System;
using System.Collections.Generic;
using System.Linq;

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
                    ListStudents();
                    return false;
                case "2":   //Staff availability
                    StaffAvailability();
                    return false;
                case "3":   //Make booking
                    MakeBooking();
                    return false;
                case "4":   //Cancel booking
                    CancelBooking();
                    return false;
                case "5":   //Return to Main Menu
                    controller.ChangeCurrentMenu(new MainMenu(model, view, controller));
                    return false;
                default:
                    view.ErrorMessage("Invalid Input");
                    return false;
            }
        }

        private void ListStudents()
        {
            var students = model.Users.Where(x => !x.IsStaff);
            view.ListPeople(false, students);
        }

        private void StaffAvailability()
        {
            view.ShowPrompt("Enter date for staff availability (dd-mm-yyyy):");
            var date = Console.ReadLine();
            //TODO: check date format is correct

            view.ShowPrompt("Enter staff ID:");
            var staffId = Console.ReadLine();
            //TODO: check staff ID format is correct

            view.ShowPrompt("Staff " + staffId + " availability on " + date);

            var availability = model.GetStaffAvailability(date, staffId);
            view.StaffAvailability(availability);
        }

        private void MakeBooking()
        {
            view.ShowPrompt("Enter room name:");
            var roomName = Console.ReadLine();
            view.ShowPrompt("Enter date for booking (dd-mm-yyyy):");
            var bookingDate = Console.ReadLine();
            view.ShowPrompt("Enter time for booking (hh:mm):");
            var time = Console.ReadLine();
            view.ShowPrompt("Enter student ID:");
            var iD = Console.ReadLine();


            bool success = model.MakeBooking(roomName, bookingDate, time, iD);

            if (success)
            {
                view.ShowPrompt("Slot booked successfully");
            }
            else
            {
                view.ShowPrompt("Slot booking failed");
            }
        }

        private void CancelBooking()
        {
            view.ShowPrompt("Enter room name:");
            var roomName = Console.ReadLine();
            view.ShowPrompt("Enter date for slot (dd-mm-yyyy):");
            var bookingDate = Console.ReadLine();
            view.ShowPrompt("Enter time for slot (hh:mm):");
            var time = Console.ReadLine();

            bool success = model.CancelBooking(roomName, bookingDate, time);

            if (success)
            {
                view.ShowPrompt("Slot cancelled successfully");
            }
            else
            {
                view.ShowPrompt("Could not cancel booking");
            }
        }
    }
}
