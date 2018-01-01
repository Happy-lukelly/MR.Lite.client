using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.ServNetProtocol
{
    /// <summary>
    /// 消息发送解析器(此接口定义具有丰富逻辑语义的上层协议处理)
    /// </summary>
    public interface IMessageSendReslover
    {
        /// <summary>
        /// 返回当前解析器的版本信息
        /// </summary>
        /// <returns></returns>
        string GetResloverVersion();
    }
}
