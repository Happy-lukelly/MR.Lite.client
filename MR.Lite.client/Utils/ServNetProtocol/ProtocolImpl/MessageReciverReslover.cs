using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.ServNetProtocol.ProtocolImpl
{
    /// <summary>
    /// 消息接收解析器
    /// </summary>
    public class MessageReciverReslover : IMessageReciveReslover
    {
        private string m_Version;
        public string GetResloverVersion()
        {
            return m_Version;
        }
    }
}
