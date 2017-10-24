using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientExt.Model
{
    /// <summary>
    /// 客户端主程序扩展dll版本信息(此类字段均为静态字段用来记录客户端扩展dll的版本信息)
    /// </summary>
    public class ClientExtVersion
    {
        /// <summary>
        /// 版本签名
        /// </summary>
        public static Guid VersionSignature { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public static string Version { get; set; }

        /// <summary>
        /// 版本更新时间
        /// </summary>
        public static DateTime UpdateTime { get; set; }
    }
}
