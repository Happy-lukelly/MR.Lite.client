
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Model;
using System.Net.Sockets;
using System.Net;

namespace Client.Protocol
{
    public class ServerNetSessionContext
    {
        private ServerInfo m_ServerInfo;

        private ServerNetRawDataReciver m_RawDataReciver;

        private ServerNetRawDataSender m_RawDataSender;

        private bool m_ConnectStatus;

        private Socket m_Socket;

        /// <summary>
        /// 获取远程服务器信息
        /// </summary>
        public ServerInfo ServerInfo { get { return m_ServerInfo; } }
        /// <summary>
        /// 获取与服务器的链接状态是否为正常连接
        /// </summary>
        public bool ConnectStatus { get { return m_ConnectStatus; } }

        #region constructor
        public ServerNetSessionContext(ServerInfo remoteServerInfo)
        {
            this.m_ServerInfo = remoteServerInfo;
        }
        #endregion
        /// <summary>
        /// 连接远程服务器
        /// </summary>
        /// <returns></returns>
        public bool ConnectServer()
        {
            bool result = false;

            if (ConnectStatus)
            {
                return true;
            }
            //连接controller
            if (m_ServerInfo != null && m_ServerInfo.GetServerType() == "controller")
            {
                IPAddress IP;
                //获取IP地址
                bool parseIpResult = IPAddress.TryParse(m_ServerInfo.RemoteDomain, out IP);
                if (!parseIpResult)
                {
                    IPAddress[] addressArray = Dns.GetHostAddresses(m_ServerInfo.RemoteDomain);
                    if (addressArray != null && addressArray.Length > 0)
                    {
                        IP = addressArray[0];
                    }
                    else
                    {
                        throw new Exception("指定的远程服务器IP地址或域名有误。请确认 ！！");
                    }
                }

                m_Socket.Connect(new IPEndPoint(IP, m_ServerInfo.RemotePort));
                result = m_ConnectStatus = true;
            }
            return result;
        }

        public bool DisConnectServer()
        {
            bool result = false;
            if (ConnectStatus)
            {
                throw new Exception("当前与服务器没有连接");
            }
            return result;
        }
    }
}
