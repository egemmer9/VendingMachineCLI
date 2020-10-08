using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class VendingItem
    {
        public string Name { get; private set; }

        public decimal Price { get; private set; }

        public string Type { get; private set; }

        public int InventoryCount { get; set; }

        public string Slot { get; private set; }

        public VendingItem(string slot, string name, decimal price, string type)
        {
            Name = name;
            Price = price;
            Type = type;
            InventoryCount = 5;
            Slot = slot;
        }

    }
}
