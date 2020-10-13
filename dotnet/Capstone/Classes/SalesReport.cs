using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class SalesReport
    {
        public SalesReport()
        {

        }

        public void IncreaseSales(string userSelection, decimal itemPrice)
        {
            
        }

        public void WriteSalesReport()
        {
            string directory = Environment.CurrentDirectory;
            string fileName = "salesreport.txt";
            string fullPath = Path.Combine(directory, fileName);

            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {

                

                sw.WriteLine("**TOTAL SALES** ");
                Console.WriteLine("**TOTAL SALES** ");
            }
        }
    }
}
