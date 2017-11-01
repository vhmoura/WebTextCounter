using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TextCounter;
using WebTextCounter.Service;
using WebTextCounter.Common;

namespace WebTextCounterTest
{
    [TestClass]
    public class WebTextCounterTest
    {
        [TestMethod, ExpectedException(typeof(InvalidWebAddressException))]                
        public void IsEmptyWebAddressValid()
        {
            var webCounter = new WebTextCounterService();
            var count = webCounter.GetData("");
        }

        [TestMethod, ExpectedException(typeof(UnableToConnectWebAddressException))]
        public void IsDodgyWebAddressValid()
        {
            var webCounter = new WebTextCounterService();
            var count = webCounter.GetData("http://bla.123.rx");
        }

        [TestMethod]
        public void CanLoadLoyalBooks()
        {
            var loyalAddress = @"http://www.loyalbooks.com/download/text/Railway-Children-by-E-Nesbit.txt";
            var webCounter = new WebTextCounterService();
            var result = webCounter.GetData(loyalAddress);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

    }
}
