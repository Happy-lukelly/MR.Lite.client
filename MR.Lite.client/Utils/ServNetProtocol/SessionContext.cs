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
        /// <summary>
        /// 关闭会话事件
        /// </summary>
        internal event Action<SessionContext> OnClose;

        SessionInfo SessionInfo;

        public bool CanUse { get; private set; }

        #region Constructor
        internal SessionContext(MessageReciverFactory reciveFactory, MessageSenderFactory senderFactory)
        {
            this.m_SenderFactory = senderFactory;
            this.m_ReciverFactory = reciveFactory;
        }

        /// <summary>
        /// 关闭当前与服务器的会话
        /// </summary>
        public void Close()
        {
            CanUse = false;
            if (OnClose != null)
            {
                OnClose(this);
            }
        }
        #endregion

    }
}
