
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Utils.ServNetProtocol.Model
{
    /// <summary>
    /// 会话信息类
    /// </summary>
    public class SessionInfo
    {
        /// <summary>
        /// 会话Guid
        /// </summary>
        public Guid SessionGuid { get; set; }
        /// <summary>
        /// 会话开始时间
        /// </summary>
        public DateTime SessionStart { get; set; }
        /// <summary>
        /// 会话使用的token信息
        /// </summary>
        public string Token { get; set; }
    }
}
