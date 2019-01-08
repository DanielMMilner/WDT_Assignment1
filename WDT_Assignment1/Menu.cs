using System.Collections.Generic;

namespace WDT_Assignment1
{
    abstract class Menu
    {
        public string menuName;
        public List<string> options;

        protected Model model;
        protected View view;
        protected Controller controller;

        public Menu(Model model, View view, Controller controller)
        {
            this.model = model;
            this.view = view;
            this.controller = controller;
        }
       
        public abstract bool ProcessMenu(string input);
    }
}
