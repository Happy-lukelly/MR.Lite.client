
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.ServNetProtocol.Model;

namespace Utils.ServNetProtocol.ProtocolImpl
{
    /// <summary>
    /// 消息发送器
    /// </summary>
    public class MessageSender : IMessageSender
    {
        private string m_Version="1.0";
        private IMessageSendReslover m_Reslover;
        public string GetSenderVersion()
        {
            return m_Version;
        }

        public void SendMessage(MessageInfo LoadBytes)
        {
            throw new NotImplementedException();
        }

        public void AsyncSendMessage(MessageInfo loadBytes, Action callback)
        {
            throw new NotImplementedException();
        }

        #region Constructor
        public MessageSender(IMessageSendReslover reslover)
        {
            this.m_Reslover = reslover;
        }
        #endregion
    }
}
