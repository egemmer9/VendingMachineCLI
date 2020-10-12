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
        private int potatoCrispsCount = 0;
        private int stackersCount = 0;
        private int grainWavesCount = 0;
        private int cloudPopcornCount = 0;
        private int moonpieCount = 0;
        private int cowtalesCount = 0;
        private int wonkaBarCount = 0;
        private int crunchieCount = 0;
        private int colaCount = 0;
        private int drSaltCount = 0;
        private int mountainMelterCount = 0;
        private int heavyCount = 0;
        private int uChewsCount = 0;
        private int littleLeagueChewCount = 0;
        private int chicletsCount = 0;
        private int tripleMintCount = 0;

        /*public Dictionary<string, int> SRDictionary { get; set; } = new Dictionary<string, int>
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
        */

        public void IncreaseSales(string userSelection, decimal itemPrice)
        {
            total += itemPrice;

            if (userSelection == "Potato Crisps")
            {
                potatoCrispsCount++;
            }
            else if (userSelection == "Stackers")
            {
                stackersCount++;
            }
            else if (userSelection == "Grain Waves")
            {
                grainWavesCount++;
            }
            else if (userSelection == "Cloud Popcorn")
            {
                cloudPopcornCount++;
            }
            else if (userSelection == "Moonpie")
            {
                moonpieCount++;
            }
            else if (userSelection == "Cowtales")
            {
                cowtalesCount++;
            }
            else if (userSelection == "Wonka Bar")
            {
                wonkaBarCount++;
            }
            else if (userSelection == "Crunchie")
            {
                crunchieCount++;
            }
            else if (userSelection == "Cola")
            {
                colaCount++;
            }
            else if (userSelection == "Dr. Salt")
            {
                drSaltCount++;
            }
            else if (userSelection == "Mountain Melter")
            {
                mountainMelterCount++;
            }
            else if (userSelection == "Heavy")
            {
                heavyCount++;
            }
            else if (userSelection == "U-Chews")
            {
                uChewsCount++;
            }
            else if (userSelection == "Little League Chew")
            {
                littleLeagueChewCount++;
            }
            else if (userSelection == "Chiclets")
            {
                chicletsCount++;
            }
            else if (userSelection == "Triplemint")
            {
                tripleMintCount++;
            }
            
            /*foreach (KeyValuePair<string, int> item in SRDictionary)
            {
                if (userSelection == item.Key)
                {
                    SRDictionary[item.Key]++;
                }
            }*/
        }

        public void WriteSalesReport()
        {
            string directory = Environment.CurrentDirectory;
            string fileName = "salesreport.txt";
            string fullPath = Path.Combine(directory, fileName);

            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {

                /*foreach (KeyValuePair<string, int> item in SRDictionary)
                {
                    sw.WriteLine(item.Key + " | " + item.Value);
                    Console.WriteLine(item.Key + " | " + item.Value);
                }*/
                sw.WriteLine("Potato Crisps | " + potatoCrispsCount);
                Console.WriteLine("Potato Crisps | " + potatoCrispsCount);

                sw.WriteLine("Stackers | " + stackersCount);
                Console.WriteLine("Stackers | " + stackersCount);

                sw.WriteLine("Grain Waves | " + grainWavesCount);
                Console.WriteLine("Grain Waves | " + grainWavesCount);

                sw.WriteLine("Cloud Popcorn | " + cloudPopcornCount);
                Console.WriteLine("Cloud Popcorn | " + cloudPopcornCount);

                sw.WriteLine("Moonpie | " + moonpieCount);
                Console.WriteLine("Moonpie | " + moonpieCount);

                sw.WriteLine("Cowtales | " + cowtalesCount);
                Console.WriteLine("Cowtales | " + cowtalesCount);

                sw.WriteLine("Wonka Bar | " + wonkaBarCount);
                Console.WriteLine("Wonka Bar | " + wonkaBarCount);

                sw.WriteLine("Crunchie | " + crunchieCount);
                Console.WriteLine("Crunchie | " + crunchieCount);

                sw.WriteLine("Cola | " + colaCount);
                Console.WriteLine("Cola | " + colaCount);

                sw.WriteLine("Dr. Salt | " + drSaltCount);
                Console.WriteLine("Dr. Salt | " + drSaltCount);

                sw.WriteLine("Mountain Melter | " + mountainMelterCount);
                Console.WriteLine("Mountain Melter | " + mountainMelterCount);

                sw.WriteLine("Heavy | " + heavyCount);
                Console.WriteLine("Heavy | " + heavyCount);

                sw.WriteLine("U-Chews | " + uChewsCount);
                Console.WriteLine("U-Chews | " + uChewsCount);

                sw.WriteLine("Little League Chew | " + littleLeagueChewCount);
                Console.WriteLine("Little League Chew | " + littleLeagueChewCount);

                sw.WriteLine("Chiclets | " + chicletsCount);
                Console.WriteLine("Chiclets | " + chicletsCount);

                sw.WriteLine("Triplemint | " + tripleMintCount);
                Console.WriteLine("Triplemint | " + tripleMintCount);

                sw.WriteLine("**TOTAL SALES** "+ total);
                Console.WriteLine("**TOTAL SALES** " + total);
            }
        }
    }
}
