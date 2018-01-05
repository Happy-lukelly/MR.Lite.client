using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.ServNetProtocol.Model;

namespace Utils.ServNetProtocol
{
    ///一次与服务器交互的会话上下文
    public class SessionContext
    {
        protected IMessageReciver m_MessageReciver;

        protected IMessageSender m_MessageSender;

        protected MessageReciverFactory m_ReciverFactory;

        protected MessageSenderFactory m_SenderFactory;

        SessionInfo SessionInfo;

        #region Constructor
        public SessionContext(MessageReciverFactory reciveFactory, MessageSenderFactory senderFactory)
        {
            this.m_SenderFactory = senderFactory;
            this.m_ReciverFactory = reciveFactory;
        }
        
        #endregion

    }
}
