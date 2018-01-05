using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.ServNetProtocol.Model
{
    public abstract class MessageInfo
    {
        /// <summary>
        /// 消息的负载信息
        /// </summary>
        public virtual byte[] MessageArray { get; protected set; }
        /// <summary>
        /// 消息的时间戳
        /// </summary>
        public virtual long MessageTimeStamp { get; private set; }
        /// <summary>
        /// 消息的格式版本
        /// </summary>
        public virtual string MessageVersion { get; private set; }
        #region constructor
        public MessageInfo(string messageVersion)
        {
            this.MessageVersion = messageVersion;
        }
        #endregion
    }
}
