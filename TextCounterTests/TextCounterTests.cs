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
            webCounter.CountWordsFromWeb("");
        }

        [TestMethod, ExpectedException(typeof(UnableToConnectWebAddressException))]
        public void IsDodgyWebAddressValid()
        {
            var webCounter = new TextCounter();
            var count = webCounter.CountWordsFromWeb("http://bla.123.rx");
        }

        [TestMethod]
        public void CanLoadLoyalBooks()
        {
            var loyalAddress = @"http://www.loyalbooks.com/download/text/Railway-Children-by-E-Nesbit.txt";
            var webCounter = new TextCounter();
            var result = webCounter.CountWordsFromWeb(loyalAddress);
            Assert.IsNotNull(result);            
        }

        [TestMethod]
        public void CanCountTextFromFile()
        {
            var fileName = @"./Files/ArtOfWar.txt";
            var counter = new TextCounter();
            var result = counter.CountWordsFromFile(fileName);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CanCountTextFromString()
        {
            var str = "Take up one idea. Make that one idea your life - think of it, dream of it, live on that idea. Let the brain, muscles, nerves, every part of your body, be full of that idea, and just leave every other idea alone. This is the way to success.";
            var counter = new TextCounter();
            var result = counter.CountWordsFromString(str);
            Assert.IsNotNull(result);
        }

        [TestMethod, ExpectedException(typeof(EmptyStringException))]
        public void CannotCountTextFromEmptyString()
        {
            var str = "";
            var counter = new TextCounter();
            var result = counter.CountWordsFromString(str);            
        }


    }
}
