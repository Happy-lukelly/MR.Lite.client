using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    /// <summary>
    /// 远程服务器信息
    /// </summary>
    public abstract class ServerInfo
    {
        //远程服务器(Controller的域名或IP地址)
        private string m_RemoteDomain;
        //远程服务器提供服务的通讯端口
        private int m_RemotePort;
        /// <summary>
        /// 设置或获取远程服务器的Domain
        /// </summary>
        public string RemoteDomain { get { return m_RemoteDomain; } set { m_RemoteDomain = value; } }

        /// <summary>
        /// 获取或设置远程服务器的服务Port
        /// </summary>
        public int RemotePort { get { return m_RemotePort; } set { m_RemotePort = value; } }
        /// <summary>
        /// 获取远程服务器的服务器类型(controller或manager)
        /// 此处为预留的扩展点，为以后 client与manager直接交互留下扩展空间
        /// </summary>
        /// <returns></returns>
        public abstract string GetServerType();
    }
}
