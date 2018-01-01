using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.ServNetProtocol.ProtocolImpl;

namespace Utils.ServNetProtocol
{
    /// <summary>
    /// 获取MessageReciver的工厂类
    /// </summary>
    public class MessageReciverFactory
    {
        /// <summary>
        /// 获取MessageReciver的工厂方法
        /// </summary>
        /// <param name="parm">创建MessageReciver时需要使用的参数</param>
        /// <returns></returns>
        public virtual IMessageReciver GetMessageReciver(object parm)
        {
            IMessageReciveReslover reslover = new MessageReciverReslover();
            return new MessageReciver(reslover);
        }
    }
}
