using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Capstone.Classes;
using System.Dynamic;

namespace Capstone
{
    public class VendingMachine
    {
        public List<VendingItem> InventoryList { get; private set; } = new List<VendingItem>();
        public Dictionary<string, int> SalesReportDictionary { get; private set; } = new Dictionary<string, int>();
        public decimal currentBalance { get; private set; }

        private int intItemSelect = 0;
        private decimal itemPrice = 0;
        private bool isValid = false;
        private decimal totalSales = 0;

        public VendingMachine()
        {
            currentBalance = 0;
        }

        public void ReadInventoryFile()
        {
                string directory = Environment.CurrentDirectory;
                string inputFile = "Inventory.txt";
                string fullPath = Path.Combine(directory, inputFile);

                using (StreamReader sr = new StreamReader(fullPath))


                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] inventoryArray = line.Split("|");
                        VendingItem newItem = new VendingItem(inventoryArray[0], inventoryArray[1], decimal.Parse(inventoryArray[2]), inventoryArray[3]);
                        InventoryList.Add(newItem);
                        SalesReportDictionary[inventoryArray[1]] = 0;
                    }

                }


        }

        public void Display()
        {
            for (int i = 0; i < InventoryList.Count; i++)
            {
                if (InventoryList[i].InventoryCount > 0)
                {
                    Console.WriteLine(InventoryList[i].Slot + " " + InventoryList[i].Name + " {0:C} " + InventoryList[i].Type, InventoryList[i].Price);
                }
                else
                {
                    Console.WriteLine(InventoryList[i].Slot + " " + InventoryList[i].Name + " {0:C} " + InventoryList[i].Type + " ** SOLD OUT **", InventoryList[i].Price);
                }
            }
        }

        public void addMoney()
        {
            Console.WriteLine(" *Enter dollar amount to add*");
            decimal feedMoney;
            bool validInput = decimal.TryParse(Console.ReadLine(), out feedMoney);
            if (validInput && feedMoney > 0)
            {
                if (!(feedMoney % 1 == 0))
                {
                    Console.WriteLine(" *Must enter a whole dollar amount*");
                }
                else
                {
                    currentBalance = currentBalance + feedMoney;
                    Console.WriteLine("Current Balance: {0:C}", currentBalance);
                    LogFeedMoney(feedMoney);
                }
            }
            else
            {
                Console.WriteLine(" *Please enter a positive whole number*");
            }
        }

        public void ItemSlotSelection()
        {
            if (this.currentBalance > 0)
            {
                Console.WriteLine(" *Please select an item*");
                string itemSelection = Console.ReadLine();
                for (int i = 0; i < InventoryList.Count; i++)
                {
                    if (itemSelection.ToUpper() == InventoryList[i].Slot)
                    {
                        intItemSelect = i;
                        itemPrice = InventoryList[i].Price;
                        isValid = true;
                    }
                }
                if (isValid)
                {
                    Purchase(itemSelection.ToUpper());
                    LogPurchase();
                    isValid = false;
                }
                else
                {
                    Console.WriteLine(" *Please select a valid item slot*");
                }
            }
            else
            {
                Console.WriteLine(" *Item selection requires a balance greater than zero*");
            }
        }

        public void Purchase(string itemSelection)
        {
            if (InventoryList[intItemSelect].InventoryCount > 0)
            {
                if ((currentBalance - itemPrice) >= 0 && currentBalance > 0)
                {
                    currentBalance = currentBalance - itemPrice;
                    InventoryList[intItemSelect].InventoryCount--;
                    Console.WriteLine(" *Vending Item*");
                    Console.WriteLine(InventoryList[intItemSelect].MakeNoise());
                    Console.WriteLine("Current Balance: {0:C}", currentBalance);
                    IncreaseSales(itemSelection, itemPrice);
                }
                else
                {
                    Console.WriteLine(" *Insufficient Funds!*");
                }
            }
            else
            {
                Console.WriteLine(" *Out of stock*");
            }
        }

        public string FinishTransaction()
        {
            decimal nickels = 0;
            decimal dimes = 0;
            decimal quarters = 0;

            decimal change = currentBalance * 100;

            do
            {
                if (change >= 25 && change <= (change + 1))
                {
                    change = change - 25;
                    quarters++;
                }
                else if (change <= 24 && change > 9)
                {
                    change = change - 10;
                    dimes++;
                }
                else if (change == 5)
                {
                    change = change - 5;
                    nickels++;
                }
            } while (change > 0);

            currentBalance = 0;

            return "Change due: " + quarters + " quarters, " + dimes + " dimes, and " + nickels + " nickels.";
        }

        //Audit Log methods
        public void LogFeedMoney(decimal feedMoneyAmount)
        {
            string directory = Environment.CurrentDirectory;
            string fileName = "log.txt";
            string fullPath = Path.Combine(directory, fileName);

            DateTime now = DateTime.Now;

            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                sw.WriteLine(now.ToString() + " FEED MONEY: {0:C} {1:C}", feedMoneyAmount, currentBalance);
            }
        }
        public void LogPurchase()
        {
            string directory = Environment.CurrentDirectory;
            string fileName = "log.txt";
            string fullPath = Path.Combine(directory, fileName);

            DateTime now = DateTime.Now;

            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                sw.WriteLine(now.ToString() + " " + InventoryList[intItemSelect].Name + " " + InventoryList[intItemSelect].Slot + " {0:C} {1:C}", itemPrice, currentBalance);
            }
        }
        public void LogFinishTransaction()
        {
            string directory = Environment.CurrentDirectory;
            string fileName = "log.txt";
            string fullPath = Path.Combine(directory, fileName);

            DateTime now = DateTime.Now;

            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                sw.WriteLine(now.ToString() + " " + "GIVE CHANGE: " + "{0:C} $0.00", currentBalance);
            }
        }

        //Sales Report methods
        public void IncreaseSales(string userSelection, decimal selectionPrice)
        {
            string itemName = null;
            for (int i = 0; i < InventoryList.Count; i++)
            {
                if(InventoryList[i].Slot == userSelection)
                {
                    itemName = InventoryList[i].Name;
                }
            }
            if (SalesReportDictionary.ContainsKey(itemName))
            {
                SalesReportDictionary[itemName]++;
                totalSales += selectionPrice;
            }
        }

        public void WriteSalesReport()
        {
            string directory = Environment.CurrentDirectory;
            string fileName = "salesreport.txt";
            string fullPath = Path.Combine(directory, fileName);

            using (StreamWriter sw = new StreamWriter(fullPath, false))
            {
                foreach (KeyValuePair<string, int> item in SalesReportDictionary)
                {
                    sw.WriteLine(item.Key + " | " + item.Value);
                    Console.WriteLine(item.Key + " | " + item.Value);
                }
                sw.WriteLine();
                Console.WriteLine();
                sw.WriteLine("**TOTAL SALES** " + totalSales);
                Console.WriteLine("**TOTAL SALES** " + totalSales);
            }
        }
    }
}
