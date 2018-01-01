using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.ServNetProtocol
{
    /// <summary>
    /// 消息接收解析器(此接口定义具有丰富逻辑语义的上层协议处理)
    /// </summary>
    public interface IMessageReciveReslover
    {
        /// <summary>
        /// 返回当前解析器的版本信息
        /// </summary>
        /// <returns></returns>
        string GetResloverVersion();
    }
}
