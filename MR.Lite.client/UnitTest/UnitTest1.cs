using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Main.ServiceInstaller;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ServiceHelper helper = new ServiceHelper();
            helper.GetService("test");
        }
    }
}
