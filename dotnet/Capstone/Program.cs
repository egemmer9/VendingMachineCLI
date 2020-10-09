using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.IO;

namespace Capstone
{
    class Program
    {        
        string itemSelection;
        int intItemSelect = 0;
        decimal itemPrice = 0;
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

                while (true) //rn this is an infinite loop. You'll need a 'finished' option and then you'll break after that option is selected
                {
                    String selection = (string)ui.PromptForSelection(MAIN_MENU_OPTIONS);
                    if (selection == MAIN_MENU_OPTION_DISPLAY_ITEMS)
                    {
                        //display the vending machine items (probably should call a method to do this)
                        Console.WriteLine();
                        Console.WriteLine(" *Please select an item*");
                        Display();
                        ItemSlotSelection();
                    }
                    else if (selection == MAIN_MENU_OPTION_PURCHASE)
                    {
                        //do the purchase (probably should call a method to do this too)
                        Purchase();                        
                    }
                    else if (selection == MAIN_MENU_OPTION_FEED_MONEY)
                    {
                        Console.WriteLine(" *Enter dollar amount to add*");
                        decimal feedMoney = decimal.Parse(Console.ReadLine());
                        if (!(feedMoney % 1 == 0))
                        {
                            Console.WriteLine(" *Must enter a whole dollar amount*");
                        }
                        else
                        {
                            balance.addMoney(feedMoney);
                            Console.WriteLine("Current Balance: {0:C}", balance.currentBalance);
                        }
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
                Console.WriteLine(" *Invalid Input*");
            }
        }

        public void Display()
        {
            for (int i = 0; i < vendingMachine.InventoryList.Count; i++)
            {
                //int itemNumber = i + 1;
                if (vendingMachine.InventoryList[i].InventoryCount > 0)
                {
                    Console.WriteLine(vendingMachine.InventoryList[i].Slot + " " + vendingMachine.InventoryList[i].Name + " " + vendingMachine.InventoryList[i].Price + " " + vendingMachine.InventoryList[i].Type);
                }
                else
                {
                    Console.WriteLine(vendingMachine.InventoryList[i].Slot + " " + vendingMachine.InventoryList[i].Name + " " + vendingMachine.InventoryList[i].Price + " " + vendingMachine.InventoryList[i].Type + " ** SOLD OUT **");
                }
            }
        }
        public void Purchase ()
        {
            if (vendingMachine.InventoryList[intItemSelect].InventoryCount > 0)
            {
                if ((balance.currentBalance - itemPrice) >= 0)
                {
                    balance.Purchase(itemPrice);
                    vendingMachine.InventoryList[intItemSelect].InventoryCount--;
                    Console.WriteLine("Vending Item");
                    if (vendingMachine.InventoryList[intItemSelect].Type == "Chip")
                    {
                        Console.WriteLine("Crunch Crunch, Yum!");
                    }
                    else if (vendingMachine.InventoryList[intItemSelect].Type == "Candy")
                    {
                        Console.WriteLine("Munch Munch, Yum!");
                    }
                    else if (vendingMachine.InventoryList[intItemSelect].Type == "Drink")
                    {
                        Console.WriteLine("Glug Glug, Yum!");
                    }
                    else if (vendingMachine.InventoryList[intItemSelect].Type == "Gum")
                    {
                        Console.WriteLine("Chew Chew, Yum!");
                    }
                    Console.WriteLine("Current Balance: {0:C}", balance.currentBalance);
                }
                else
                {
                    Console.WriteLine("Insufficient Funds!");
                }
            }
            else
            {
                Console.WriteLine(" *Out of stock*");
            }
        }
        public void ItemSlotSelection ()
        {
            if (balance.currentBalance > 0)
            {
                itemSelection = Console.ReadLine();
                if (itemSelection == "A1")
                {
                    intItemSelect = 0;              
                }
                else if (itemSelection == "A2")
                {
                    intItemSelect = 1;
                }
                else if (itemSelection == "A3")
                {
                    intItemSelect = 2;
                }
                else if (itemSelection == "A4")
                {
                    intItemSelect = 3;
                }
                else if (itemSelection == "B1")
                {
                    intItemSelect = 4;
                }
                else if (itemSelection == "B2")
                {
                    intItemSelect = 5;
                }
                else if (itemSelection == "B3")
                {
                    intItemSelect = 6;
                }
                else if (itemSelection == "B4")
                {
                    intItemSelect = 7;
                }
                else if (itemSelection == "C1")
                {
                    intItemSelect = 8;
                }
                else if (itemSelection == "C2")
                {
                    intItemSelect = 9;
                }
                else if (itemSelection == "C3")
                {
                    intItemSelect = 10;
                }
                else if (itemSelection == "C4")
                {
                    intItemSelect = 11;
                }
                else if (itemSelection == "D1")
                {
                    intItemSelect = 12;
                }
                else if (itemSelection == "D2")
                {
                    intItemSelect = 13;
                }
                else if (itemSelection == "D3")
                {
                    intItemSelect = 14;
                }
                else if (itemSelection == "D4")
                {
                    intItemSelect = 15;
                }

                    itemPrice = vendingMachine.InventoryList[intItemSelect].Price;
            }else
            {
                Console.WriteLine("*Item selection requires a balance greater than zero*");
            }
        }
    }
}
