using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.ServNetProtocol.Model;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace Utils.ServNetProtocol
{
    /// <summary>
    /// 服务器池
    /// </summary>
    public class ServerPool
    {
        static List<ServerInfoImpl> serverPoolInfo = new List<ServerInfoImpl>();
        static Thread scanThread;
        static TypeLogger logger = new TypeLogger(typeof(ServerPool), AppDomain.CurrentDomain.BaseDirectory + "\\log");
        static Dictionary<string, SessionContext> sessionDic = new Dictionary<string, SessionContext>(); 
        /// <summary>
        /// 获取一个与服务器交互的连接会话
        /// </summary>
        /// <returns></returns>
        public SessionContext GetSession()
        {

        }
        static ServerPool()
        {

        }
        #region Constructor
        public ServerPool(List<ServerInfo> serverInfo)
        {
            if (serverInfo != null && serverInfo.Count > 0)
            {
                foreach (ServerInfo server in serverInfo)
                {
                    serverPoolInfo.Add((ServerInfoImpl)server);
                }
            }
            else
            {
                throw new Exception("必须至少指定一个服务器信息");
            }
            InitPool();
        }
        #endregion
        /// <summary>
        /// 初始化池
        /// </summary>
        public void InitPool()
        {
            NetHelper helper = new NetHelper();
            foreach (ServerInfoImpl server in serverPoolInfo)
            {
                IPAddress address=null;
                try
                {
                    address = helper.GetAddress(server.ServerAddress);
                }
                catch (Exception e)
                {
                    logger.LogWarn("解析服务器地址失败" + e.Message);
                }
                try
                {
                    server.ServerSocket.BeginConnect(address, server.Port, (t) =>
                    {
                        logger.LogInfo("远程服务器" + server.ToString() + "连接成功");
                        server.IsConnected = true;
                    }, null);
                }
                catch (Exception e)
                {
                    logger.LogError("连接"+server+"失败!!错误信息为"+e);
                }
            }
            scanThread = new Thread(Scan);
            scanThread.Start();
        }
        /// <summary>
        /// 扫描线程
        /// </summary>
        public void Scan()
        {

        }

        private class ServerInfoImpl : ServerInfo
        {
            /// <summary>
            /// 当前是否连接
            /// </summary>
            public bool IsConnected { get; set; }
            /// <summary>
            /// 与服务器连接的Socket的信息
            /// </summary>
            public Socket ServerSocket { get; set; }

            public override string ToString()
            {
                return "服务器连接在" + ServerAddress + "端口" + Port + "上";
            }
        }
    }
}
