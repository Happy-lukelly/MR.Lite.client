using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Utils
{
    /// <summary>
    /// 网络服务类
    /// </summary>
    public class NetHelper
    {
        /// <summary>
        /// 将指定的IP地址或域名转换为IPAddresss
        /// </summary>
        /// <param name="hostOrIP">要转换的地址或域名</param>
        /// <returns></returns>
        public IPAddress GetAddress(string hostOrIP)
        {
            IPAddress result;
            if (IPAddress.TryParse(hostOrIP, out result))
            {
                return result;
            }
            else
            {
                IPAddress[] res = Dns.GetHostAddresses(hostOrIP);
                if (res.Length > 0)
                {
                    return res[0];
                }
                else
                {
                    throw new Exception("无法获取"+hostOrIP+"对应的IP地址");
                }
            }
        }
    }
}
