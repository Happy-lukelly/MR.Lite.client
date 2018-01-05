using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Utils.ServNetProtocol.Model
{
    /// <summary>
    /// 使用流方式设置消息体的发送消息信息
    /// </summary>
    public class StreamSendMessageInfo:SendMessgeInfo
    {
        public Stream MessageBodyStream { get; private set; }
        #region constructor
        public StreamSendMessageInfo(IPAddress serverAddress, string messageVersion):base(serverAddress,messageVersion)
        {
            this.MessageBodyStream = new MemoryStream();
        }
        #endregion
    }
}
