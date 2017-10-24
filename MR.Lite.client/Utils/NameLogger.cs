using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Utils
{
    public class NameLogger : LogHelper
    {
        private string m_Name;
        public string Name { get { return m_Name; } }
        private ILog logger;
        public NameLogger(string name)
        {
            this.m_Name = name;
            this.logger = LogFactory.getLoger(name);
        }

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
