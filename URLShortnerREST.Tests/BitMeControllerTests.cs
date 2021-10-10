using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using URLShortnerREST.Controllers;

using System;


namespace URLShortnerREST.Tests
{
    [TestClass]
    public class BitMeControllerTests
    {
        [TestMethod]
        public void ShortUrlTest()
        {
            BitMeController controller = new BitMeController(null);
            string result = controller.BitMeShorten("test");

            Assert.IsTrue(result == "test");
        }

        [TestMethod]
        public void LongUrlTest()
        {
            BitMeController controller = new BitMeController(null);
            string result = controller.BitMeShorten("https://en.wikipedia.org/wiki/Dependency_inversion_principle");

            Assert.IsTrue(result != "https://en.wikipedia.org/wiki/Dependency_inversion_principle");
        }

        [TestMethod]
        public void RedirectTest()
        {
            string testURL = "https://en.wikipedia.org/wiki/Dependency_inversion_principle";
            BitMeController controller = new BitMeController(null);
            string shortened = controller.BitMeShorten(testURL);

            RedirectResult result = controller.BitMe(shortened.Remove(0, 6)); //remove BitMe 

            Assert.IsTrue(result.Url == testURL);
        }
    }
}
