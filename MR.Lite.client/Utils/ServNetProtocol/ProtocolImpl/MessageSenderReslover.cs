using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.ServNetProtocol.ProtocolImpl
{
    /// <summary>
    /// 消息发送解析器
    /// </summary>
    public class MessageSenderReslover : IMessageSendReslover
    {
        private string m_Version;
        public string GetResloverVersion()
        {
            return m_Version;
        }
    }
}
