using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextCounterService;
using TextCounterService.Common;

namespace WebTextCounterTest
{
    [TestClass]
    public class TextCounterTests
    {
        [TestMethod, ExpectedException(typeof(InvalidWebAddressException))]                
        public void IsEmptyWebAddressValid()
        {
            var webCounter = new TextCounter();
            webCounter.GetData("");
        }

        [TestMethod, ExpectedException(typeof(UnableToConnectWebAddressException))]
        public void IsDodgyWebAddressValid()
        {
            var webCounter = new TextCounter();
            var count = webCounter.GetData("http://bla.123.rx");
        }

        [TestMethod]
        public void CanLoadLoyalBooks()
        {
            var loyalAddress = @"http://www.loyalbooks.com/download/text/Railway-Children-by-E-Nesbit.txt";
            var webCounter = new TextCounter();
            var result = webCounter.GetData(loyalAddress);
            Assert.IsNotNull(result);            
        }
    }
}
