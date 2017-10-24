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
            LogHelper logger = new NameLogger("test");
            logger.LogError("error");
            LogHelper typeLogger = new TypeLogger(this.GetType());
            typeLogger.LogInfo("ffff");
        }
    }
}
