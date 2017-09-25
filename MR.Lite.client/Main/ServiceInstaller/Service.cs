using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.ServiceInstaller
{
    /// <summary>
    /// 代表一个服务的类
    /// </summary>
    public class Service
    {
        #region
        /// <summary>
        /// 服务名称
        /// </summary>
        [KeyName(KeyName = "DisplayName")]
        [ValueType(ValueType = Microsoft.Win32.RegistryValueKind.String)]
        public string DisplayName { get; set; }

        /// <summary>
        /// 服务的描述
        /// </summary>
        [KeyName(KeyName = "Description")]
        [ValueType(ValueType = Microsoft.Win32.RegistryValueKind.String)]
        public string Description { get; set; }

        /// <summary>
        /// 服务程序路径(执行字符串)
        /// </summary>
        [KeyName(KeyName = "ImagePath")]
        [ValueType(ValueType = Microsoft.Win32.RegistryValueKind.MultiString)]
        public string ImagePath { get; set; }

        /// <summary>
        /// 启动类型
        /// </summary>
        [KeyName(KeyName = "Start")]
        [ValueType(ValueType = Microsoft.Win32.RegistryValueKind.DWord)]
        public StartType StartType { get; set; }
        /// <summary>
        /// 服务程序类型
        /// </summary>
        [KeyName(KeyName = "Type")]
        [ValueType(ValueType = Microsoft.Win32.RegistryValueKind.DWord)]
        public ServiceType ServiceType { get; set; }

        #endregion public property

        #region readonly filed
        //登录账户
        [KeyName(KeyName = "ObjectName")]
        [ValueType(ValueType = Microsoft.Win32.RegistryValueKind.String)]
        public string ObjectName { get; private set; }

        [KeyName()]
        //错误控制
        public ErrorControl ErrorControl { get; private set; }
        #endregion

        #region Constructor
        public Service() : this("LocalSystem", ErrorControl.Normal) { }
        public Service(string objectName, ErrorControl errorControl)
        {
            this.ObjectName = objectName;
            this.ErrorControl = ErrorControl;
        }
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

    /// <summary>
    /// 服务启动出错控制
    /// </summary>
    public enum ErrorControl
    {
        /// <summary>
        /// Ignore 启动程序会忽略报错信息
        /// </summary>
        Ignore = 0,
        /// <summary>
        /// Normal 启动程序会继续启动，但是会提示启动错误信息
        /// </summary>
        Normal = 1,
        /// <summary>
        /// Severe 系统会报告服务启动失败，同时尝试重新启动最后一次正确配置，若最后一次正确配置启动成功，启动进程将
        /// 继续执行后续的启动任务
        /// </summary>
        Severe = 2,
        /// <summary>
        /// Critical 系统报告服务启动失败，同时启动最后一次正确配置，若最后一次正确配置启动成功，
        /// 系统将停止后续的启动任务，同时系统将启动调试程序
        /// </summary>
        Critical = 3
    }
}
