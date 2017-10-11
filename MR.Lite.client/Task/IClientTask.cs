using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public interface IClientTask
    {
        /// <summary>
        /// 任务运行入口方法
        /// </summary>
        void Run();

        /// <summary>
        /// 任务报告进度的事件触发
        /// </summary>
        event Func<int> ReportProgress;
    }
}
