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
        private const string MAIN_MENU_OPTION_DISPLAY_ITEMS = "Display Vending Machine Items";
        private const string MAIN_MENU_OPTION_PURCHASE = "Purchase";
        private const string MAIN_MENU_OPTION_EXIT = "Exit";
        private const string MAIN_MENU_OPTION_SALES_REPORT = "Print Sales Report";
        private const string PURCHASE_MENU_OPTION_FEED_MONEY = "Feed Money";
        private const string PURCHASE_MENU_OPTION_FINISH_TRANSACTION = "Finish Transaction";
        private const string PURCHASE_MENU_OPTION_SELECT_PRODUCT = "Select Product";
        private readonly string[] MAIN_MENU_OPTIONS = {MAIN_MENU_OPTION_DISPLAY_ITEMS, MAIN_MENU_OPTION_PURCHASE, MAIN_MENU_OPTION_EXIT, MAIN_MENU_OPTION_SALES_REPORT}; //const has to be known at compile time, the array initializer is not const in C#
        private readonly string[] PURCHASE_MENU_OPTIONS = {PURCHASE_MENU_OPTION_FEED_MONEY, PURCHASE_MENU_OPTION_SELECT_PRODUCT, PURCHASE_MENU_OPTION_FINISH_TRANSACTION};

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
                vendingMachine.ReadInventoryFile();

                while (true)
                {
                    String selection = (string)ui.PromptForSelection(MAIN_MENU_OPTIONS);
                    if (selection == MAIN_MENU_OPTION_DISPLAY_ITEMS)
                    {
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
                                vendingMachine.ItemSlotSelection();
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
                    else if (selection == MAIN_MENU_OPTION_SALES_REPORT)
                    {
                        vendingMachine.WriteSalesReport();
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine(" *Invalid Input*");
            }
        }
    }
}
