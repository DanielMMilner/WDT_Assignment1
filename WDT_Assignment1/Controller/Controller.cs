using System;

namespace WDT_Assignment1
{
    class Controller
    {
        private View view;
        private bool exit = false;
        private Menu currentMenu;

        public Controller()
        {
            view = new View();

            currentMenu = new MainMenu(view, this);
        }

        public void Run()
        {
            view.ShowPrompt("Loading data from DB");

            var res = Model.Instance.LoadDataFromDB();

            if (!res.Success)
            {
                view.ErrorMessage(res.ErrorMsg);
                // Exits program if database fails to initialise.
                Environment.Exit(0);
            }

            while (!exit)
            {
                // Prints current menu and sends users input to that menu for processing.
                view.PrintMenu(currentMenu.MenuName, currentMenu.Options);
                var input = Console.ReadLine();
                exit = currentMenu.ProcessMenu(input);
            }
        }

        public void ChangeCurrentMenu(Menu menu)
        {
            currentMenu = menu;
        }
    }
}
