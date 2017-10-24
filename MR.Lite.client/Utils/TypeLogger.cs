using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Utils
{
    public class TypeLogger:LogHelper
    {
        private Type m_type;

        public Type Type { get { return m_type; } }
        private ILog logger;

        public TypeLogger(Type type)
        {
            this.m_type = type;
            this.logger = LogFactory.getLoger(type);
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
