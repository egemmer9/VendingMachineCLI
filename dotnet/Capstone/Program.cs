using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.IO;

namespace Capstone
{
    class Program
    {
        private Balance balance = new Balance();
        private VendingMachine vendingMachine = new VendingMachine();
        private const string MAIN_MENU_OPTION_DISPLAY_ITEMS = "Display Vending Machine Items";
    	private const string MAIN_MENU_OPTION_PURCHASE = "Purchase";
        private const string MAIN_MENU_OPTION_FEED_MONEY = "Feed Money";
        private const string MAIN_MENU_OPTION_FINISH_TRANSACTION = "Finish Transaction";
	    private readonly string[] MAIN_MENU_OPTIONS = {MAIN_MENU_OPTION_FEED_MONEY, MAIN_MENU_OPTION_DISPLAY_ITEMS, MAIN_MENU_OPTION_PURCHASE, MAIN_MENU_OPTION_FINISH_TRANSACTION}; //const has to be known at compile time, the array initializer is not const in C#

        private readonly IBasicUserInterface ui = new MenuDrivenCLI();

        static void Main(string[] args)
        {

            Program p = new Program();
            p.Run();

        }


        public void Run()
        {
            try
            {
                vendingMachine.turnOnMachine();
                vendingMachine.ReadInventoryFile();

                string itemSelection;
                int intItemSelect = 0;
                decimal itemPrice = 0;
                while (true) //rn this is an infinite loop. You'll need a 'finished' option and then you'll break after that option is selected
                {

                    String selection = (string)ui.PromptForSelection(MAIN_MENU_OPTIONS);
                    if (selection == MAIN_MENU_OPTION_DISPLAY_ITEMS)
                    {

                        //display the vending machine items (probably should call a method to do this)
                        vendingMachine.Display();
                        itemSelection = Console.ReadLine();
                        intItemSelect = int.Parse(itemSelection);
                        itemPrice = vendingMachine.InventoryList[intItemSelect - 1].Price;

                    }
                    else if (selection == MAIN_MENU_OPTION_PURCHASE)
                    {
                        //do the purchase (probably should call a method to do this too)
                        if (vendingMachine.InventoryList[intItemSelect - 1].InventoryCount > 0)
                        {
                            vendingMachine.InventoryList[intItemSelect - 1].InventoryCount--;
                            Console.WriteLine("Vending Item");
                            if(vendingMachine.InventoryList[intItemSelect - 1].Type == "Chip")
                            {
                                Console.WriteLine("Crunch Crunch, Yum!");
                            }
                            else if(vendingMachine.InventoryList[intItemSelect - 1].Type == "Candy")
                            {
                                Console.WriteLine("Munch Munch, Yum!");
                            }
                            else if (vendingMachine.InventoryList[intItemSelect - 1].Type == "Drink")
                            {
                                Console.WriteLine("Glug Glug, Yum!");
                            }
                            else if (vendingMachine.InventoryList[intItemSelect - 1].Type == "Gum")
                            {
                                Console.WriteLine("Chew Chew, Yum!");
                            }
                            balance.Purchase(itemPrice);
                            Console.WriteLine("Current Balance: {0:C}", balance.currentBalance);
                        }
                        else
                        {
                            Console.WriteLine("Out of stock");
                        }
                        
                        
                    }
                    else if (selection == MAIN_MENU_OPTION_FEED_MONEY)
                    {
                        Console.WriteLine("Enter amount to add.");
                        decimal feedMoney = decimal.Parse(Console.ReadLine());
                        balance.addMoney(feedMoney);
                        Console.WriteLine("Current Balance: {0:C}", balance.currentBalance);
                    }
                    else if (selection == MAIN_MENU_OPTION_FINISH_TRANSACTION)
                    {
                        Console.WriteLine(balance.FinishTransaction());
                        Console.WriteLine("Current balance: {0:C}", balance.currentBalance);
                    }

                }


            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Input");
            }

        }


    }
}
