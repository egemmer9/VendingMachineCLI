using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    class Balance
    {
        public decimal currentBalance { get; private set; }

        public Balance() { currentBalance = 0; }

        public void addMoney(decimal deposit)
        {
            currentBalance = currentBalance + deposit;
            Console.WriteLine("Current Balance : " + currentBalance);
        }

        public void Purchase(decimal itemCost)
        {
            if ((currentBalance - itemCost) >= 0)
            {
                currentBalance = currentBalance - itemCost;
                Console.WriteLine("Vending Item");
                Console.WriteLine("Current Balance : " + currentBalance);
            }
            else
            {
                Console.WriteLine("Insufficient Funds ! ");
            }
        }
    }
}
