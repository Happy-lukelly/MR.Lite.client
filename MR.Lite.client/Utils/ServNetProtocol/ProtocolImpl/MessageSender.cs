
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.ServNetProtocol.ProtocolImpl
{
    /// <summary>
    /// 消息发送器
    /// </summary>
    public class MessageSender : IMessageSender
    {
        private string m_Version;
        private IMessageSendReslover m_Reslover;
        public string GetSenderVersion()
        {
            return m_Version;
        }

        #region Constructor
        public MessageSender(IMessageSendReslover reslover)
        {
            this.m_Reslover = reslover;
        }
        #endregion
    }
}
