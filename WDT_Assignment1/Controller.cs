﻿using System;
using System.Collections.Generic;

namespace WDT_Assignment1
{
    class Controller
    {
        private View view;
        private Model model;
        private bool exit = false;
        private readonly List<Menu> menus;        
        private Menu currentMenu;

        public Controller()
        {
            view = new View();
            model = new Model();

            menus = new List<Menu>
            {
                new MainMenu(model, view, this),
                new StaffMenu(model, view, this),
                new StudentMenu(model, view, this)
            };

            currentMenu = menus[0];
        }

        public void Run()
        {
            while (!exit)
            {
                view.PrintMenu(currentMenu.menuName, currentMenu.options);
                var input = Console.ReadLine();
                exit = currentMenu.ProcessMenu(input);
            }
        }

        public void ChangeCurrentMenu(string menuName)
        {
            foreach(Menu menu in menus)
            {
                if(menu.menuName == menuName)
                {
                    currentMenu = menu;
                    return;
                }
            }
            view.ErrorMessage("Menu not found");
        }
    }
}
