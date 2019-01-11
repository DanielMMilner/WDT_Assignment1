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

        public string GetDate()
        {
            Regex rx = new Regex(@"^([0-9]|[0-2][0-9]|(3)[0-1])-((1)[0-2]|[1-9]|(0)[1-9])-\d{4}$");

            while (!GetInput(rx))
            {
                view.ShowPrompt("Invalid date format. Dates much be in the format dd-mm-yyyy");
                view.ShowPrompt("Enter a date:");
            }

            return input;
        }

        public string GetTime()
        {
            Regex rx = new Regex(@"^((2)[0-3]|(0|1)[0-9]):([0-5][0-9])$");

            while (!GetInput(rx))
            {
                view.ShowPrompt("Invalid time format. Time much be in the format hh:mm");
                view.ShowPrompt("Enter a time:");
            }

            return input;
        }

        public string GetStaffId()
        {
            Regex rx = new Regex(@"^(e)\d{5}$");

            while (!GetInput(rx))
            {
                view.ShowPrompt("Invalid Staff ID format. Staff IDs must start with an 'e' followed by 5 numbers");
                view.ShowPrompt("Enter a Staff ID:");
            }

            return input;
        }

        public string GetStudentId()
        {
            Regex rx = new Regex(@"^(s)\d{7}$");

            while (!GetInput(rx))
            {
                view.ShowPrompt("Invalid Student ID format. Student IDs must start with an 's' followed by 7 numbers");
                view.ShowPrompt("Enter a Student ID:");
            }

            return input;
        }

        public string GetRoomName()
        {
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
