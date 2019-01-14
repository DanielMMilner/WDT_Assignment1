using System.Collections.Generic;

namespace WDT_Assignment1
{
    abstract class Menu
    {
        public string MenuName { get; protected set; }
        public List<string> Options { get; protected set; }
        
        protected View view;
        protected Controller controller;
        protected UserInput userInput;

        public Menu(View view, Controller controller)
        {
            this.view = view;
            this.controller = controller;

            userInput = new UserInput (view);
        }
       
        public abstract bool ProcessMenu(string input);
    }
}
