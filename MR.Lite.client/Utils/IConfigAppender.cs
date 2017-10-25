using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    /// <summary>
    /// 配置Log4Net的Appender接口
    /// </summary>
    interface IConfigAppender
    {
        void ConfigContextAppender();
    }
}
