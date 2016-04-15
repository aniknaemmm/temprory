using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EngineVk;

namespace EngineVk.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var vks = new CoreVk();
            vks.Init("+375257307554","29730511");
           Assert.IsTrue(vks.authorize);
        }
    }
}
