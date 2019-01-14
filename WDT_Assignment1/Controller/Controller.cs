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
            var res = Model.Instance.LoadDataFromDB();

            if (!res)
            {
                view.ErrorMessage("There was a problem connecting to the database.\n Please check your internet connection and try again.");
            }

            while (!exit)
            {
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
