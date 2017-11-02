using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextCounterService;
using TextCounterService.Common;
using TextCounterService.Helpers;

namespace WebTextCounterTest
{
    [TestClass]
    public class TextCounterTests
    {
        [TestMethod, ExpectedException(typeof(InvalidWebAddressException))]                
        public void IsEmptyWebAddressValid()
        {
            var webCounter = new TextCounter();
            webCounter.CountWords<Web>("");
        }

        [TestMethod, ExpectedException(typeof(UnableToConnectWebAddressException))]
        public void IsDodgyWebAddressValid()
        {
            var webCounter = new TextCounter();
            var count = webCounter.CountWords<Web>("http://bla.123.rx");
        }

        [TestMethod]
        public void CanLoadLoyalBooks()
        {
            var loyalAddress = @"http://www.loyalbooks.com/download/text/Railway-Children-by-E-Nesbit.txt";
            var webCounter = new TextCounter();
            var result = webCounter.CountWords<Web>(loyalAddress);
            Assert.IsNotNull(result);            
        }

        [TestMethod]
        public void CanLoadFromFile()
        {
            var filename = @"./FIles/ArtOfWar.txt";
            var FileCounter = new TextCounter();
            var result = FileCounter.CountWords<FileHelper>(filename);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CanLoadFromString()
        {
            var text = "Take up one idea. Make that one idea your life - think of it, dream of it, live on that idea. Let the brain, muscles, nerves, every part of your body, be full of that idea, and just leave every other idea alone. This is the way to success.";
            var stringCounter = new TextCounter();
            var result = stringCounter.CountWords<Text>(text);
            Assert.IsNotNull(result);
        }

        [TestMethod, ExpectedException(typeof(EmptyStringException))]
        public void CannotLoadEmptyString()
        {
            var location = "";
            var stringCounter = new TextCounter();
            var result = stringCounter.CountWords<Text>(location);
            Assert.IsNotNull(result);
        }        
    }
}
