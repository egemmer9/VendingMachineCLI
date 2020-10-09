using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class AuditFile
    {
        public AuditFile()
        {

        }
        public void LogFeedMoney(decimal feedMoneyAmount, decimal currentBalance)
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
        public void LogPurchase(string itemName, string itemSlot, decimal itemPrice, decimal currentBalance)
        {
            string directory = Environment.CurrentDirectory;
            string fileName = "log.txt";
            string fullPath = Path.Combine(directory, fileName);

            DateTime now = DateTime.Now;

            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                sw.WriteLine(now.ToString() + " " + itemName + " " + itemSlot+ " {0:C} {1:C}", itemPrice, currentBalance);
            }
        }
        public void LogFinishTransaction(decimal currentBalance)
        {
            string directory = Environment.CurrentDirectory;
            string fileName = "log.txt";
            string fullPath = Path.Combine(directory, fileName);

            DateTime now = DateTime.Now;

            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                sw.WriteLine(now.ToString() + " " + "GIVE CHANGE: " + " {0:C} $0.00", currentBalance);
            }
        }
    }
}
