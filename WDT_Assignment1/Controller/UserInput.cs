using System;
using System.Text.RegularExpressions;

namespace WDT_Assignment1
{
    public class UserInput
    {
        private View view;
        private string input;

        public UserInput(View view)
        {
            this.view = view;
        }

        public DateTime GetDate()
        {
            Regex rx = new Regex(@"^([0-9]|[0-2][0-9]|(3)[0-1])-((1)[0-2]|[1-9]|(0)[1-9])-\d{4}$");

            view.ShowPrompt("Enter date in format (dd-mm-yyyy):");

            while (!GetInput(rx))
            {
                view.ShowPrompt("Invalid date format. Dates much be in the format dd-mm-yyyy");
                view.ShowPrompt("Enter a date:");
            }

            return DateTime.Parse(input);
        }

        public TimeSpan GetTime()
        {
            Regex rx = new Regex(@"^(09|1[0-4]):00$");

            view.ShowPrompt("Note: Bookings can only be made at the start of the hour and during school working hours: 09:00-14:00");
            view.ShowPrompt("Enter time in format (hh:mm):");

            while (!GetInput(rx))
            {
                view.ShowPrompt("Invalid time format. Time must be in the format hh:mm and must be made at the top of the hour");
                view.ShowPrompt("Enter a time:");
            }

            return TimeSpan.Parse(input);
        }

        public string GetStaffId()
        {
            Regex rx = new Regex(@"^(e)\d{5}$");

            view.ShowPrompt("Enter staff ID:");

            while (!GetInput(rx))
            {
                view.ShowPrompt("Invalid Staff ID format. Staff IDs must start with an 'e' followed by 5 numbers");
                view.ShowPrompt("Enter a staff ID:");
            }

            return input;
        }

        public string GetStudentId()
        {
            Regex rx = new Regex(@"^(s)\d{7}$");

            view.ShowPrompt("Enter student ID:");

            while (!GetInput(rx))
            {
                view.ShowPrompt("Invalid Student ID format. Student IDs must start with an 's' followed by 7 numbers");
                view.ShowPrompt("Enter a Student ID:");
            }

            return input;
        }

        public string GetRoomName()
        {
            view.ShowPrompt("Enter room name:");

            return Console.ReadLine();
        }

        private bool GetInput(Regex rx)
        {
            MatchCollection matches;

            input = Console.ReadLine();
            matches = rx.Matches(input);

            return matches.Count > 0;
        }
    }
}
