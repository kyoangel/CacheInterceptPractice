using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CacheInterceptPractice.Tests
{
    [TestClass()]
    public class LongWorkTests
    {
        [TestMethod()]
        public void DoWorkTest()
        {
            var longWork = new LongWork();
            var result = longWork.DoWork();
            Console.WriteLine(result);
        }
    }
}