using System;
using GehirnJogging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GehirnjoggingTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Player.getInstance().playerName = "Manfred";

        }
    }
}
