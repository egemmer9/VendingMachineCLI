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
        }

        public void Purchase(decimal itemCost)
        {
            currentBalance = currentBalance - itemCost;           
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
    }
}
