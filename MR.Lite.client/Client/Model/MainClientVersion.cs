using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    /// <summary>
    /// 客户端主程序的版本信息
    /// </summary>
    class MainClientVersion
    {
        /// <summary>
        /// 版本签名
        /// </summary>
        public static Guid VersionSignature { get; set;}

        /// <summary>
        /// 版本号
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 版本更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 是否为当前使用版本
        /// </summary>
        public bool IsNowUseVersion { get; set; }
    }
}
