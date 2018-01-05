using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Utils.ServNetProtocol.Model
{
    /// <summary>
    /// 与服务器交互信息时发送消息的的数据包
    /// </summary>
    public class SendMessgeInfo:MessageInfo
    {
        /// <summary>
        /// 使用指定的消息版本信息和服务器IP地址信息初始化一个发送消息体
        /// </summary>
        /// <param name="serverAddressInfo">要发往的服务器IP地址信息</param>
        /// <param name="messageVersion">消息体使用的格式版本信息</param>

        public SendMessgeInfo(IPAddress serverAddressInfo, string messageVersion):base(messageVersion)
        {
            this.ServerAddressInfo = serverAddressInfo;
        }
        /// <summary>
        /// 获取该消息要发往的服务器的IP地址信息
        /// </summary>
        public virtual IPAddress ServerAddressInfo { get; private set; }
    }
}
