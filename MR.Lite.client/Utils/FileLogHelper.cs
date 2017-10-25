using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using System.IO;

namespace Utils
{
    /// <summary>
    /// 文件Logger基类(此类实现了Log4net上下文的配置部分)
    /// </summary>
    public abstract class FileLogHelper : AbstractFileLogHelper
    {
        private string m_LoggerName;
        public FileLogHelper(string loggerName,string fileDic):base(fileDic)
        {
            this.m_LoggerName = loggerName;
            if (!LogFactory.IsLoggerExists(loggerName))
            {
                ConfigContextAppender();
            }
        }
        /// <summary>
        /// 配置文件信息
        /// </summary>
        public sealed override void ConfigContextAppender()
        {
            ConfigContextAppender(FileDic);
        }
        /// <summary>
        /// 配置文件日志Logger上下文
        /// </summary>
        /// <param name="dicPath">日志文件路径</param>
        private void ConfigContextAppender(string dicPath)
        {
            if (!File.Exists(dicPath))
            {
                string pathWithoutFileName = dicPath.Substring(0, dicPath.IndexOf(Path.GetFileName(dicPath)));
                if (!Directory.Exists(pathWithoutFileName))
                {
                    Directory.CreateDirectory(pathWithoutFileName);
                }
                File.Create(dicPath);
            }
            else
            {
                log4net.Repository.Hierarchy.Hierarchy hier = log4net.LogManager.GetRepository() as log4net.Repository.Hierarchy.Hierarchy;
                //配置appender
                log4net.Appender.FileAppender fileAppender = new log4net.Appender.FileAppender();
                fileAppender.Name = m_LoggerName;
                fileAppender.File = dicPath;
                fileAppender.AppendToFile = true;
                //配置layout
                log4net.Layout.PatternLayout layout = new log4net.Layout.PatternLayout();
                layout.ConversionPattern = "%date [%t] %-5p %c - %m%n";
                layout.ActivateOptions();
                fileAppender.Layout = layout;

                fileAppender.Encoding = Encoding.UTF8;
                fileAppender.ActivateOptions();
                log4net.Repository.ILoggerRepository repository = log4net.LogManager.CreateRepository(m_LoggerName);
                BasicConfigurator.Configure(repository, fileAppender);
            }
        }
    }
}
