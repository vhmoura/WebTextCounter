using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextCounterService;

namespace TextCounterTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var webCounter = new TextCounter();
            webCounter.GetData("");
        }
    }
}
