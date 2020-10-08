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
        bool isOn = false;
        public List<VendingItem> InventoryList { get; private set; } = new List<VendingItem>();

        public VendingMachine()
        {

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
                }
            }
        }
    }
}
