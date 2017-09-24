using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.ServiceInstaller
{
    public class ServiceHelper
    {
        #region  constructor
        public ServiceHelper()
        {
        }
        #endregion

        /// <summary>
        /// 返回指定名称的服务，或者返回null 若服务不存在
        /// </summary>
        /// <param name="serviceName">要查找的服务的名称</param>
        /// <returns></returns>
        public Service GetService(string serviceName)
        {
            Service result = null;
            return result;
        }

        /// <summary>
        /// 向系统中注册指定的服务
        /// </summary>
        /// <param name="service">要注册到系统中的服务</param>
        /// <returns></returns>
        public bool InstallService(Service service)
        {
            bool result = false;
            return result;
        }
    }

}
