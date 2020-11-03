using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class TestVendingItem
    {
        [TestMethod]
        public void TestMakeNoise()
        {
            VendingItem vendingItem = new VendingItem("A1", "Test Item", 1.50M, "Chip");
            VendingItem vendingItem2 = new VendingItem("A1", "Test Item", 1.50M, "Candy");
            VendingItem vendingItem3 = new VendingItem("A1", "Test Item", 1.50M, "Drink");
            VendingItem vendingItem4 = new VendingItem("A1", "Test Item", 1.50M, "Gum");

            string result = vendingItem.MakeNoise();
            string result2 = vendingItem2.MakeNoise();
            string result3 = vendingItem3.MakeNoise();
            string result4 = vendingItem4.MakeNoise();

            Assert.AreEqual(" *Crunch Crunch, Yum!*", result);
            Assert.AreEqual(" *Munch Munch, Yum!*", result2);
            Assert.AreEqual(" *Glug Glug, Yum!*", result3);
            Assert.AreEqual(" *Chew Chew, Yum!*", result4);
        }
    }
}
