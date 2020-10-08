using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace Capstone
{
    class Program
    {
        private const string MAIN_MENU_OPTION_DISPLAY_ITEMS = "Display Vending Machine Items";
    	private const string MAIN_MENU_OPTION_PURCHASE = "Purchase";
	    private readonly string[] MAIN_MENU_OPTIONS = { MAIN_MENU_OPTION_DISPLAY_ITEMS, MAIN_MENU_OPTION_PURCHASE }; //const has to be known at compile time, the array initializer is not const in C#

        private readonly IBasicUserInterface ui = new MenuDrivenCLI();

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        public void Run()
        {
            while(true) //rn this is an infinite loop. You'll need a 'finished' option and then you'll break after that option is selected
            {
                String selection = (string)ui.PromptForSelection(MAIN_MENU_OPTIONS);
                if (selection==MAIN_MENU_OPTION_DISPLAY_ITEMS)
                {
                    //display the vending machine items (probably should call a method to do this)
                }
                else if (selection==MAIN_MENU_OPTION_PURCHASE)
                {
                    //do the purchase (probably should call a method to do this too)
                }

            }
        }


    }
}
