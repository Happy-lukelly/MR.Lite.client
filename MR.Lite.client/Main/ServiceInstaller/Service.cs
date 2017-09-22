using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.ServiceInstaller
{
    public class Service
    {
        #region
        /// <summary>
        /// 服务名称
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 服务的描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 服务程序路径(执行字符串)
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// 启动类型
        /// </summary>
        public StartType StartType { get; set; }
        /// <summary>
        /// 服务程序类型
        /// </summary>
        public ServiceType ServiceType { get; set; }

        #endregion public property

        #region private filed
        //登录账户
        public readonly string ObjectName = "LocalSystem";

        //错误控制
        public readonly int ErrorControl = 1;
        #endregion
    }

    /// <summary>
    /// 启动方式 DWORD
    /// </summary>
    public enum StartType
    {
        //自动运行(延时)DelayedAutostart为 dword 1 
        /// <summary>
        /// //自动运行(延时)
        /// </summary>
        AutoWithDelay = 1,
        /// <summary>
        /// 自动运行
        /// </summary>
        Auto = 2,
        /// <summary>
        /// 手动执行
        /// </summary>
        Handle = 3,
        /// <summary>
        /// 禁止
        /// </summary>
        Forbiden = 4
    }

    /// <summary>
    /// 服务程序类型
    /// </summary>
    public enum ServiceType
    {
        /// <summary>
        /// 应用程序
        /// </summary>
        Application = 1,
        /// <summary>
        /// 其他
        /// </summary>
        Other = 2
    }
}
