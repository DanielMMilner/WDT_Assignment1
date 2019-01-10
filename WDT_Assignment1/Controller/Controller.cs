using System;
using System.Collections.Generic;

namespace WDT_Assignment1
{
    class Controller
    {
        private View view;
        private Model model;
        private bool exit = false;
        private Menu currentMenu;

        public Controller()
        {
            view = new View();
            model = new Model();
            
            currentMenu = new MainMenu(model, view, this);
        }

        public void Run()
        {
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
