using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Boolean yo = true;
            Assert.AreEqual(yo, yo);
        }
    }
}
