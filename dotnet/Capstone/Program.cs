using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.IO;

namespace Capstone
{
    class Program
    {        
        private VendingMachine vendingMachine = new VendingMachine();
        private SalesReport salesReport = new SalesReport();
        private const string MAIN_MENU_OPTION_DISPLAY_ITEMS = "Display Vending Machine Items";
        private const string MAIN_MENU_OPTION_PURCHASE = "Purchase";
        private const string MAIN_MENU_OPTION_EXIT = "Exit";
        //private const string MAIN_MENU_OPTION_SALES_REPORT = "";
        private const string PURCHASE_MENU_OPTION_FEED_MONEY = "Feed Money";
        private const string PURCHASE_MENU_OPTION_FINISH_TRANSACTION = "Finish Transaction";
        private const string PURCHASE_MENU_OPTION_SELECT_PRODUCT = "Select Product";
        private readonly string[] MAIN_MENU_OPTIONS = {MAIN_MENU_OPTION_DISPLAY_ITEMS, MAIN_MENU_OPTION_PURCHASE, MAIN_MENU_OPTION_EXIT}; //const has to be known at compile time, the array initializer is not const in C#
        private readonly string[] PURCHASE_MENU_OPTIONS = {PURCHASE_MENU_OPTION_FEED_MONEY, PURCHASE_MENU_OPTION_SELECT_PRODUCT, PURCHASE_MENU_OPTION_FINISH_TRANSACTION };

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
                        vendingMachine.Display();
                    }
                    else if (selection == MAIN_MENU_OPTION_PURCHASE)
                    {
                        while (true)
                        {
                            String purchaseMenuSelection = (string)ui.PromptForSelection(PURCHASE_MENU_OPTIONS);
                            if (purchaseMenuSelection == PURCHASE_MENU_OPTION_FEED_MONEY)
                            {
                                vendingMachine.addMoney();
                            }
                            else if (purchaseMenuSelection == PURCHASE_MENU_OPTION_SELECT_PRODUCT)
                            {
                                //do the purchase (probably should call a method to do this too)
                                vendingMachine.ItemSlotSelection();
                                //salesReport.IncreaseSales(vendingMachine.InventoryList[intItemSelect].Name, itemPrice);
                            }
                            else if (purchaseMenuSelection == PURCHASE_MENU_OPTION_FINISH_TRANSACTION)
                            {
                                vendingMachine.LogFinishTransaction();
                                Console.WriteLine(vendingMachine.FinishTransaction());
                                Console.WriteLine("Current balance: {0:C}", vendingMachine.currentBalance);
                                break;
                            }
                        }
                    }
                    else if (selection == MAIN_MENU_OPTION_EXIT)
                    {
                        break;
                    }
                    //else if (itemSelection == "A4 B4 C4 D4")
                    //{
                    //    salesReport.WriteSalesReport();
                    //}
                }
            }
            catch (Exception)
            {
                Console.WriteLine(" *Invalid Input*");
            }
        }
    }
}
