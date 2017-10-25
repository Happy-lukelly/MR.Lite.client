using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils;
using Client.Model;

namespace UnitTest
{
    [TestClass]
    public class UtilTest
    {
        [TestMethod]
        public void JsonTest()
        {
            MainClientVersion version = new MainClientVersion();

            string result =JsonHelper.SerializeObject(version);

            MainClientVersion v = JsonHelper.DeserializeJsonToObject<MainClientVersion>(result);
        }

        [TestMethod]
        public void JsonAnymous()
        {
            var t = new {
                a = 4,
                b = "123456",
                c = new
                {
                    f = 6,
                    c = DateTime.Now
                }
            };

            string res = JsonHelper.SerializeObject(t);

            object o = JsonHelper.DeserializeAnonymousType(res, t);
        }

        [TestMethod]
        public void LogTest()
        {
            string baseDic = AppDomain.CurrentDomain.BaseDirectory;
            string Name = System.IO.Path.Combine(baseDic, "log\\name\\name.txt");
            string Type = System.IO.Path.Combine(baseDic, "log\\type\\name.txt");
            FileLogHelper logger = new NameLogger("test",Name);
            logger.LogError("error");
            FileLogHelper logger2 = new NameLogger("test", Name);
            logger2.LogInfo("info");
            FileLogHelper typeLogger = new TypeLogger(this.GetType(),Type);
            typeLogger.LogInfo("ffff");
        }

        [TestMethod]
        public void ConfigTest()
        {
            Client.BLL.CheckUpdate checkupdate = new Client.BLL.CheckUpdate();
            checkupdate.UpdateClientVersionConfig(new MainClientVersion());
            MainClientVersion versionNow = checkupdate.GetNowClientVersion();
        }
    }
}
