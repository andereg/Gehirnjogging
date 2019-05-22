using System;
using System.Collections.Generic;
using DB_GehirnJogging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DB_GehirnJogging.Repositories;


namespace GehirnjoggingTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            CharakterRepository ctx = new CharakterRepository(new GehirnjoggingEntities());
            ctx.createNewUser("Alfred");
            bool test1 = ctx.characternameExists("Alfred");
            Assert.AreEqual(test1, true);
        }

        [TestMethod]
        public void TestMethod2()
        {
            CharakterRepository ctx = new CharakterRepository(new GehirnjoggingEntities());
            bool test1 = ctx.characternameExists("adisjiajs4241125");
            Assert.AreEqual(test1, false);
        }

        [TestMethod]
        public void TestMethod3()
        {
            QuestionRepository ctx = new QuestionRepository(new GehirnjoggingEntities());
            int answerListLength = ctx.getAnswers().Count;
            int questionListLength = ctx.getAnswers().Count;
            Assert.AreEqual(answerListLength, questionListLength);
        }
    }
}
