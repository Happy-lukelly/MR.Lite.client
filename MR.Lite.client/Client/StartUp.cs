using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Model;

namespace Client
{
    /// <summary>
    /// 客户端主程序第一次运行时首次加载进行操作判断的类
    /// </summary>
    class StartUp
    {
        /// <summary>
        /// 是否是安装后的第一次运行
        /// </summary>
        public bool IsFirstRun { get; private set; }
        /// <summary>
        /// 当前主程序版本
        /// </summary>
        /// <returns></returns>
        public virtual MainClientVersion GetNowUserClientVersion()
        {
            MainClientVersion nowUsedVersion = new MainClientVersion();
            return nowUsedVersion;
        }


    }
}
