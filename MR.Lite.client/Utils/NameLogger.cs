using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Utils
{
    /// <summary>
    /// 指定名称的文件方式记录的Logger
    /// </summary>
    public class NameLogger : FileLogHelper
    {
        private string m_Name;
        public string Name { get { return m_Name; } }
        private ILog logger;

        #region Constructor
        /// <summary>
        /// 初始化指定名称和路径的logger
        /// </summary>
        /// <param name="name">logger 的名称</param>
        /// <param name="fileDic">logger的路径</param>
        public NameLogger(string name,string fileDic):base(name,fileDic)
        {
            this.m_Name = name;
            this.logger = LogFactory.getLoger(name);
        }
        #endregion
        public override void LogError(string message)
        {
            logger.Error(message);
        }

        public override void LogInfo(string message)
        {
            logger.Info(message);
        }

        public override void LogWarn(string message)
        {
            logger.Warn(message);
        }
    }
}
