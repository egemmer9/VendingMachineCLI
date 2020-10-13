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

            string result = vendingItem.MakeNoise();

            Assert.AreEqual(" *Crunch Crunch, Yum!*", result);
        }
    }
}
