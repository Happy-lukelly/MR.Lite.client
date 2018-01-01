using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.ServNetProtocol.ProtocolImpl
{
    /// <summary>
    /// 消息接收器
    /// </summary>
    public class MessageReciver : IMessageReciver
    {
        private string m_Version;
        private IMessageReciveReslover m_Reslover;

        public string GetReciverVersion()
        {
            return m_Version;
        }

        #region Constructor
        public MessageReciver(IMessageReciveReslover reslover)
        {
            this.m_Reslover = reslover;
        }
        #endregion
    }
}
