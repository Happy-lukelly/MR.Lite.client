using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.ServNetProtocol
{
    /// <summary>
    /// 消息发送器(此接口定义原始数据流PS:基于bytearray的协议处理)
    /// </summary>
    public interface IMessageSender
    {
        /// <summary>
        /// 获取当前发送器的版本信息
        /// </summary>
        /// <returns></returns>
        string GetSenderVersion();
    }
}
