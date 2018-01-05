using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils;
using Client.Model;
using System.Collections.Generic;

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
            Client.BLL.VersionService checkupdate = new Client.BLL.VersionService();
            checkupdate.UpdateClientVersionConfig(new MainClientVersion());
            MainClientVersion versionNow = checkupdate.GetNowClientVersion();
        }

        [TestMethod]
        public void KMPTest()
        {
            string mainString = @"第四个大国——日不落帝国的英国，英国通过光荣革命，逐步建立起君主立宪制，完成了向现代社会的转型。 工业革命的蓬勃发展，让英国迅速崛起，在1588年与西班牙无敌舰队的海战中大获全胜，就此逐步登上世界舞台。

19世纪中后期开始，殖民地日益成为英帝国的负担，而自由市场经济的弊端也逐渐显现，英国的发展开始减慢，最终丧失了世界霸主的地位。
　　英国的大国标志——水晶宫。
　　
　　第五个世界大国——法兰西，两次皇朝三次共和，启蒙思想打破了欧洲中世纪的神学枷锁，开启了理性的大门。
　　拿破仑一世以大革命之子的形象出现，用征服欧洲的方式再次将法国带向巅峰。然而，武力扩张并不能长久维持大国地位。
　　法国的大国标志——《人权与公民权宣言》。
　　
　　第六个世界大国——德国，铁血宰相俾斯麦则在欧洲列强环伺的夹缝中求生存，在外交上作足准备后，最终以三场对外的战争，在1871年完成了德国统一。
　　一直以来高度重视教育、科技的德意志，迅速站在了第二次工业革命的前沿，用30多年的时间超过英国，成为欧洲第一、世界第二大经济强国。但是，随后德国却很快成为两次世界大战的策源地。
　　德国的大国标志——第二次世界大战。
　　
　　第七个世界大国——日本，百年维新，大久保利通以拿来主义的方式推进殖产兴业、文明开化，开办大量官营工厂，并大力扶持民营企业。日本现代企业之父涩泽荣一弃官经商的传奇经历成为那个时代的主角。
　　大久保的继任者伊藤博文则顺应国内自由民权运动的呼声，制定了巩固维新成果的日本第一部宪法。但是，同时写进《大日本帝国宪法》的天皇制埋下了日本军国主义抬头的隐患。原子弹爆炸的蘑菇云结束了日本军国主义的迷梦。
　　日本的世界大国标志——小男孩，胖子。
　　
　　第八个世界大国——苏联，1697年，俄国沙皇彼得一世前往欧洲各国游历和学习。归来后，他用强硬手段推行了一场社会变革。从穿衣、吃饭，到科学教育、商业活动、军队建设，彼得用野蛮的方式推进了俄罗斯的文明进程，他甚至亲自审讯反对改革的太子。
　　继承彼得改革的女皇叶卡捷琳娜二世引进欧洲的启蒙思想，重视教育，并试图起草法律，但改革无法触动农奴制。女皇的业绩最终只能表现在领土扩张上，在18世纪后期，俄罗斯成为地跨欧亚美的大国，并成为欧洲事务中的重要角色。
　　1917年，苏维埃政权在十月革命后诞生。斯大林决定加快工业化进程，开始实施计划经济，优先发展重工业。随着两个五年计划的完成，苏联一跃成为工业强国，令当时正处于经济危机中的欧美各国惊叹不已。工业化成就的光芒掩盖了苏联高度集中的指令性计划经济模式的弊端。";
            string patternString = "成为工业强国";
            KMPScan scan = new KMPScan();
            int res = scan.IndexOfStr(mainString, patternString);
            int[] resArr = scan.AllIndexOfStr(mainString, patternString);
        }
    }

    public class KMPScan
    {
        /// <summary>
        /// 查询模式串在主串中的位置
        /// </summary>
        /// <param name="mainString"></param>
        /// <param name="patternString"></param>
        /// <returns></returns>
        public int IndexOfStr(string mainString, string patternString)
        {
            int[] nextArr = GetNextArr(patternString);
            int i = 0, mainStringlength = mainString.Length,patternStringLength = patternString.Length;
            int loopCount = mainString.Length - patternStringLength;
            int result = -1;
            //遍历
            while (i < loopCount)
            {
                int patternPoint = 0;
                //对比
                for (; patternPoint < patternStringLength; patternPoint++)
                {
                    //模式匹配错误
                    if (mainString[i + patternPoint] != patternString[patternPoint])
                    {
                        break;
                    }
                }
                //查找完成
                if (patternPoint == patternStringLength)
                {
                    result = i;
                    break;
                }
                else
                //重新计算i位置
                {
                    int offset = 0;
                    offset = patternPoint - nextArr[patternPoint];
                    i += offset;
                }
            }
            return result;
        }

        public int[] AllIndexOfStr(string mainString, string patternString)
        {
            int[] nextArr = GetNextArr(patternString);
            int i = 0, mainStringlength = mainString.Length, patternStringLength = patternString.Length;
            int loopCount = mainString.Length - patternStringLength;
            List<int> resultList = new List<int>();
            //遍历
            while (i < loopCount)
            {
                int patternPoint = 0;
                //对比
                for (; patternPoint < patternStringLength; patternPoint++)
                {
                    //模式匹配错误
                    if (mainString[i + patternPoint] != patternString[patternPoint])
                    {
                        break;
                    }
                }
                //查找完成
                if (patternPoint == patternStringLength)
                {
                    resultList.Add(i);
                    i += patternStringLength;
                }
                else
                //重新计算i位置
                {
                    int offset = 0;
                    offset = patternPoint - nextArr[patternPoint];
                    i += offset;
                }
            }
            return resultList.ToArray();
        }
        /// <summary>
        /// 获取next数组
        /// </summary>
        /// <param name="patternString"></param>
        /// <returns></returns>
        private int[] GetNextArr(string patternString)
        {
            int length = patternString.Length;
            int[] result = new int[length];
            result[0] = -1;
            int i = 0, j = -1;
            while (i < length-1)
            {
                if (j == -1 || patternString[i] == patternString[j])
                {
                    result[++i] = ++j;
                }
                else
                {
                    j = result[j];        //回溯j指针
                }
            }
            return result;
        }
    }
}
