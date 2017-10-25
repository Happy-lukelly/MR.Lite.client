using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public abstract class AbstractFileLogHelper : IConfigAppender
    {
        private string m_FileDic;

        public string FileDic { get { return m_FileDic; } }
        public AbstractFileLogHelper(string fileDic)
        {
            m_FileDic = fileDic;
        }

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

        public abstract void ConfigContextAppender();
    }
}
