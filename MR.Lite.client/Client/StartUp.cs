using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Model;
using Client.BLL;
using ClientExt.Model;

namespace Client
{
    /// <summary>
    /// 客户端主程序第一次运行时首次加载进行操作判断的类
    /// </summary>
    class StartUp
    {
        /// <summary>
        /// 检查主程的升级事件
        /// </summary>
        public event Action<MainClientVersion> OnChechkMainProgUpdate;

        /// <summary>
        /// 检查主程扩展dll的升级事件
        /// </summary>
        public event Action<ClientExtVersion> OnCheckClientExtUpdate;

        #region Constructor
        public StartUp()
        {
        }
        #endregion
        public void StartService()
        {
            VersionService checkUpdate = new VersionService();
            MainClientVersion nowMainClientVersion = checkUpdate.GetNowClientVersion();
            OnChechkMainProgUpdate?.BeginInvoke(nowMainClientVersion,Isync =>{

            },null);
        }
    }
}
