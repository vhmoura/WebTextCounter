using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TextCounter;
using WebTextCounter.Service;

namespace WebTextCounterTest
{
    [TestClass]
    public class WebTextCounterTest
    {
        [TestMethod, ExpectedException(typeof(Exception), "Invalid web address")]                
        public void IsEmptyWebAddressValid()
        {
            var webCounter = new WebTextCounterService("");
            var count = webCounter.Count();
        }

        [TestMethod, ExpectedException(typeof(Exception), "Invalid web address")]
        public void IsDodgyWebAddressValid()
        {
            var webCounter = new WebTextCounterService("http://bla.123.rx");
            var count = webCounter.Count();
        }

        [TestMethod]
        public void CanLoadLoyalBooks()
        {
            var loyalAddress = @"http://www.loyalbooks.com/download/text/Railway-Children-by-E-Nesbit.txt";
            var webCounter = new WebTextCounterService(loyalAddress);
            var result = webCounter.Count();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

    }
}
