﻿using System.Collections.Generic;

namespace WDT_Assignment1
{
    class StaffMenu : Menu
    {
        public StaffMenu(View view, Controller controller) : base(view, controller)
        {
            MenuName = "Staff";

            Options = new List<string>
            {
                "List staff",
                "List booked slots",
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
                case "1":   // List staff.
                    ListStaff();
                    return false;
                case "2":   // List booked slots.
                    ListBookedSlots();
                    return false;
                case "3":   // Room availability.
                    RoomAvailability();
                    return false;
                case "4":   // Create slot.
                    CreateSlot();
                    return false;
                case "5":   // Remove slot.
                    RemoveSlot();
                    return false;
                case "6":   // Return to Main Menu.
                    controller.ChangeCurrentMenu(new MainMenu(view, controller));
                    return false;
                default:
                    view.ErrorMessage("Invalid Input");
                    return false;
            }
        }

        private void ListBookedSlots()
        {
            var id = userInput.GetStaffId();

            view.ListSlots(Model.Instance.GetBookedSlots(id));
        }

        private void ListStaff()
        {
            view.ListPeople(Model.Instance.GetStaff());
        }

        private void RoomAvailability()
        {
            var date = userInput.GetDate();
            
            view.ListRooms(Model.Instance.GetAvaliableRooms(date));
        }

        private void CreateSlot()
        {
            var roomName = userInput.GetRoomName();

            var bookingDate = userInput.GetDate();

            var time = userInput.GetTime();

            // Join the booking date with the time enterd to form a new datetime.
            bookingDate = bookingDate.Date + time;

            var id = userInput.GetStaffId();

            var res = Model.Instance.CreateSlot(roomName, bookingDate, id);

            if (res.Success)
            {
                view.ShowPrompt($"Slot in room {roomName} on {bookingDate.ToString("dd-MM-yyyy")} at {bookingDate.ToString("hh:mm tt")} with {id} successfully created.");
            }
            else
            {
                view.ShowPrompt($"Failed to create slot: {res.ErrorMsg}");
            }
        }

        private void RemoveSlot()
        {
            var roomName = userInput.GetRoomName();

            var bookingDate = userInput.GetDate();

            var time = userInput.GetTime();

            // Join the booking date with the time entered to form a new datetime.
            bookingDate = bookingDate.Date + time;
            
            var res = Model.Instance.RemoveSlot(roomName, bookingDate);

            if (res.Success)
            {
                view.ShowPrompt($"Slot in room {roomName} on {bookingDate.ToString("dd-MM-yyyy")} at {bookingDate.ToString("hh:mm tt")} successfully removed.");
            }
            else
            {
                view.ShowPrompt($"Failed to remove slot: {res.ErrorMsg}");
            }
        }
    }
}
