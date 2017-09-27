using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Main.ServiceInstaller;
using System.Diagnostics;
using System.Reflection;

namespace UnitTest
{
    public delegate void TestDele();
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ServiceHelper helper = new ServiceHelper();
            helper.GetService("WSearch");
        }
        [TestMethod]
        public void TestRefl()
        {
            TestClass test = new TestClass();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                test.TestMethod();
            }
            sw.Stop();
            long R1 = sw.ElapsedMilliseconds;



            sw.Start();
            Type type2 = typeof(TestClass);
            MethodInfo method2 = type2.GetMethod("TestMethod");
            for (int i = 0; i < 1000000; i++)
            {
                method2.Invoke(test, null);
            }
            sw.Stop();

            long R2 = sw.ElapsedMilliseconds;


            Action action2 = System.Delegate.CreateDelegate(typeof(Action),test, method2) as Action;
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                action2();
            }
            sw.Stop();
            long R5 = sw.ElapsedMilliseconds;

            Action action = new Action(test.TestMethod);
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                action();
            }
            sw.Stop();
            long R4 = sw.ElapsedMilliseconds;

            Debug.Print(R4.ToString());

            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                Type type = typeof(TestClass);
                MethodInfo method = type.GetMethod("TestMethod");
                method.Invoke(test, null);
            }
            sw.Stop();

            long R3 = sw.ElapsedMilliseconds;
        }
    }

    public class TestClass
    {
        public void TestMethod()
        {

        }
    }
}
