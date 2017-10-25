using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Util;
using log4net.Core;

namespace Utils
{
    /// <summary>
    /// 日志工厂
    /// </summary>
    class LogFactory
    {
        static Dictionary<string, LogImpl> nameLogRep = new Dictionary<string, LogImpl>();
        static Dictionary<Type, LogImpl> typeLogRep = new Dictionary<Type, LogImpl>();

        static object o = new object();
        static object to = new object();
        /// <summary>
        /// 返回指定名称的logger
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static LogImpl getLoger(string name)
        {
            lock (o)
            {
                if (nameLogRep.ContainsKey(name))
                {
                    return nameLogRep[name];
                }
                else
                {
                    //根据仓库名称和名称获取Logger
                    LogImpl log = (LogImpl)LogManager.GetLogger(name, name);
                    nameLogRep.Add(name, log);
                    return log;
                }
            }
        }

        /// <summary>
        /// 返回指定类型的logger
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static LogImpl getLoger(Type type)
        {
            lock (to)
            {
                if (typeLogRep.ContainsKey(type))
                {
                    return typeLogRep[type];
                }
                else
                {
                    //根据仓库名称和名称获取Logger
                    LogImpl log = (LogImpl)LogManager.GetLogger(type.ToString(), type);
                    typeLogRep.Add(type, log);
                    return log;
                }
            }
        }

        /// <summary>
        /// 判断logger是否已缓存
        /// </summary>
        /// <param name="loggerName"></param>
        /// <returns></returns>
        public static bool IsLoggerExists(string loggerName)
        {
            return nameLogRep.ContainsKey(loggerName);
        }

        /// <summary>
        /// 判断logger是否已缓存
        /// </summary>
        /// <param name="loggerType"></param>
        /// <returns></returns>
        public static bool IsLoggerExists(Type loggerType)
        {
            return typeLogRep.ContainsKey(loggerType);
        }
    }
}
