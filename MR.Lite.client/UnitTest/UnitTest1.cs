using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Main.ServiceInstaller;
using System.Diagnostics;
using System.Reflection;
using Microsoft.Win32;

namespace UnitTest
{
    public delegate void TestDele();
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        //测试 查找系统中注册的指定名称的服务 pass
        public void TestMethod1()
        {
            ServiceHelper helper = new ServiceHelper();
            helper.GetService("WSearch");
        }
        [TestMethod]
        //测试 反射缓存性能提升
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


            Action action2 = System.Delegate.CreateDelegate(typeof(Action), test, method2) as Action;
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

        [TestMethod]
        //测试 服务是否存在方法单元测试  pass 
        public void TestServiceExist()
        {
            string serviceName = "MySQL";
            ServiceHelper helper = new ServiceHelper();
            bool result = helper.IsServiceExist(serviceName);
        }

        [TestMethod]
        //测试 修改指定服务指定值名称的值 pass
        public void TestChangeKeyValue()
        {
            ServiceHelper helper = new ServiceHelper();
            Service MySQLService = helper.GetService("MySQL");
            if (MySQLService != null)
            {
                try
                {
                    Service newService = helper.ChangeServiceValue(MySQLService, "DisplayName", RegistryValueKind.String, "MySQL");
                }
                catch (Exception e)
                {

                }
            }
        }

        [TestMethod]
        //测试 添加到指定服务中指定的值 pass
        public void TestAddKeyToService()
        {
            ServiceHelper helper = new ServiceHelper();
            Service mysqlService = helper.GetService("MySQL");
            if (mysqlService != null)
            {
                try
                {
                    Service newService = helper.AddKeyToService(mysqlService, new Service.RegistryKeyInfo() { Name = "test", Value = "tttt", KeyKind = RegistryValueKind.String });

                }
                catch (Exception e)
                {

                }
            }
        }
    }

    public class TestClass
    {
        public void TestMethod()
        {
        }
    }
}
