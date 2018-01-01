using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.ServNetProtocol.ProtocolImpl;

namespace Utils.ServNetProtocol
{
    /// <summary>
    /// 获取MessageSender的工厂类
    /// </summary>
    public class MessageSenderFactory
    {
        /// <summary>
        /// 获取MessageSender 的工厂方法
        /// </summary>
        /// <param name="param">创建MessageSender时需要使用的参数</param>
        /// <returns></returns>
        public IMessageSender GetMessageSender(object param)
        {
            IMessageSendReslover reslover = new MessageSenderReslover();
            return new MessageSender(reslover);
        }
    }
}
