using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public abstract class Task : IClientTask
    {
        public abstract event Func<int> ReportProgress;

        public abstract void Run();
        /// <summary>
        /// 任务的Id
        /// </summary>
        public Guid TaskId { get; set; }

        /// <summary>
        /// 任务的描述信息
        /// </summary>
        public string Decription { get; set; }
        /// <summary>
        /// 任务的版本信息
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 任务的语言类型
        /// </summary>
        public TaskType Type { get; set; }
    }
}
