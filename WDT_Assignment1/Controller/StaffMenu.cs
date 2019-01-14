﻿using System;
using System.Collections.Generic;
using System.Linq;

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
                    ListStaff();
                    return false;
                case "2":   //Room availability
                    RoomAvailability();
                    return false;
                case "3":   //Create slot
                    CreateSlot();
                    return false;
                case "4":   //Remove slot
                    RemoveSlot();
                    return false;
                case "5":   //Return to Main Menu
                    controller.ChangeCurrentMenu(new MainMenu(model, view, controller));
                    return false;
                default:
                    view.ErrorMessage("Invalid Input");
                    return false;
            }
        }

        private void ListStaff()
        {
            view.ListPeople(true, model.GetStaff());
        }

        private void RoomAvailability()
        {
            var date = userInput.GetDate();
            
            view.ListRooms(model.GetAvaliableRooms(date));
        }

        private void CreateSlot()
        {
            var roomName = userInput.GetRoomName();

            var bookingDate = userInput.GetDate();

            var time = userInput.GetTime();

            // Join the booking date with the time enterd to form a new datetime
            bookingDate = bookingDate.Date + time;

            var id = userInput.GetStaffId();

            bool success = model.CreateSlot(roomName, bookingDate, id);

            if (success)
            {
                view.ShowPrompt($"Slot in room {roomName} on {bookingDate.ToString("dd-MM-yyyy")} at {bookingDate.ToString("hh:mm tt")} with {id} successfully created.");
            }
            else
            {
                view.ShowPrompt("Failed to create slot");
            }
        }

        private void RemoveSlot()
        {
            var roomName = userInput.GetRoomName();

            var bookingDate = userInput.GetDate();

            var time = userInput.GetTime();

            // Join the booking date with the time enterd to form a new datetime
            bookingDate = bookingDate.Date + time;
            
            bool success = model.RemoveSlot(roomName, bookingDate);

            if (success)
            {
                view.ShowPrompt($"Slot in room {roomName} on {bookingDate.ToString("dd-MM-yyyy")} at {bookingDate.ToString("hh:mm tt")} successfully removed.");
            }
            else
            {
                view.ShowPrompt("Failed to remove slot");
            }
        }
    }
}
