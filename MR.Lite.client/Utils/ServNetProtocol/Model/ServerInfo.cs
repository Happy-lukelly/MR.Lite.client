using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.ServNetProtocol.Model
{
    /// <summary>
    /// 服务器信息类
    /// </summary>
    public class ServerInfo
    {
        public string ServerAddress { get; set; }

        public int Port { get; set; }
        public string ServerDiscription { get; set; }
    }
}
