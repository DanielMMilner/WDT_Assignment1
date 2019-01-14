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
            view.ListPeople(false, model.GetStudents());
        }

        private void StaffAvailability()
        {
            var date = userInput.GetDate();

            var staffId = userInput.GetStaffId();

            view.ShowPrompt($"Staff member {staffId} availability on {date}");

            // Get this staff members bookings for the given day
            var staffBookingTimes = model.GetSlotsOnDate(date).Where(x => x.StaffId == staffId).ToList();
            
            view.StaffAvailability(staffBookingTimes);
        }

        private void MakeBooking()
        {
            var roomName = userInput.GetRoomName();

            var bookingDate = userInput.GetDate();

            var time = userInput.GetTime();

            var id = userInput.GetStudentId();

            bookingDate = bookingDate.Date + time;

            bool success = model.MakeBooking(roomName, bookingDate, id);

            if (success)
            {
                view.ShowPrompt($"Booking in room {roomName} on {bookingDate} at {time} by {id} successfully booked.");
            }
            else
            {
                view.ShowPrompt("Slot booking failed");
            }
        }

        private void CancelBooking()
        {
            var roomName = userInput.GetRoomName();

            var bookingDate = userInput.GetDate();

            var time = userInput.GetTime();

            bool success = model.CancelBooking(roomName, bookingDate);

            if (success)
            {
                view.ShowPrompt($"Booking in room {roomName} on {bookingDate} at {time} successfully cancelled.");
            }
            else
            {
                view.ShowPrompt("Could not cancel booking");
            }
        }
    }
}
