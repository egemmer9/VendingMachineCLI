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

        private decimal total = 0;

        public Dictionary<string, int> SRDictionary { get; set; } = new Dictionary<string, int>
        {
                    {"Potato Crisps", 0 },
                    {"Stackers", 0 },
                    {"Grain Waves", 0 },
                    {"Cloud Popcorn", 0 },
                    {"Moonpie", 0 },
                    {"Cowtails", 0 },
                    {"Wonka Bar", 0 },
                    {"Crunchie", 0 },
                    {"Cola", 0 },
                    {"Dr. Salt", 0},
                    {"Mountain Melter", 0 },
                    {"Heavy", 0 },
                    {"U-Chews", 0 },
                    {"Little League Chew", 0 },
                    {"Chiclets", 0 },
                    {"Triplemint", 0 }
                };

        public void IncreaseSales(string userSelection, decimal itemPrice)
        {
            
            total += itemPrice;
            foreach (KeyValuePair<string, int> item in SRDictionary)
            {
                if (userSelection == item.Key)
                {
                    SRDictionary[item.Key]++;
                }
            }
        }
        
        public void WriteSalesReport()
        {
            string directory = Environment.CurrentDirectory;
            string fileName = "salesreport.txt";
            string fullPath = Path.Combine(directory, fileName);

            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {

                foreach (KeyValuePair<string, int> item in SRDictionary)
                {
                    sw.WriteLine(item.Key + " | " + item.Value);
                    Console.WriteLine(item.Key + " | " + item.Value);
                }
                sw.WriteLine("**TOTAL SALES** "+ total);
                Console.WriteLine("**TOTAL SALES** " + total);

                /*
                int potatoCrispsCount = 0;
                int stackersCount = 0;
                int grainWavesCount = 0;
                int cloudPopcornCount = 0;
                int moonpieCount = 0;
                int cowtailsCount = 0;
                int wonkaBarCount = 0;
                int crunchieCount = 0;
                int colaCount = 0;
                int drSaltCount = 0;
                int mountainMelterCount = 0;
                int heavyCount = 0;
                int uChewsCount = 0;
                int littleLeagueChew = 0;
                int chicletsCount = 0;
                int tripleMintCount = 0;
                */


            }
        }
    }
}
