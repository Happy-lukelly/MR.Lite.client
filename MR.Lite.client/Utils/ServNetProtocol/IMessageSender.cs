using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.ServNetProtocol.Model;

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

        /// <summary>
        /// 发送一条消息
        /// </summary>
        /// <param name="LoadBytes">消息的负载信息</param>
        void SendMessage(MessageInfo LoadBytes);

        /// <summary>
        /// 异步发送一条消息，并在消息发送完成后执行指定的回调方法
        /// </summary>
        /// <param name="loadBytes"></param>
        /// <param name="callback"></param>
        void AsyncSendMessage(MessageInfo loadBytes, Action callback);
    }
}
