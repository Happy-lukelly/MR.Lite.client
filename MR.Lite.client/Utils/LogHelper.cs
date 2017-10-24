using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;


[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
namespace Utils
{
    public abstract class LogHelper
    {
        public abstract void LogInfo(string message);
        public abstract void LogError(string message);
        public abstract void LogWarn(string message);
        public virtual void LogInfo(Exception e)
        {
            this.LogInfo(e.StackTrace);
        }
        public virtual void LogError(Exception e)
        {
            this.LogError(e.StackTrace);
        }
        public virtual void LogWarn(Exception e)
        {
            this.LogWarn(e.StackTrace);
        }

    }
}
