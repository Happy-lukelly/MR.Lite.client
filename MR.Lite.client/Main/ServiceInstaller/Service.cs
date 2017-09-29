using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Reflection;

namespace Main.ServiceInstaller
{
    /// <summary>
    /// 代表一个服务的类
    /// </summary>
    public class Service
    {
        #region Property
        /// <summary>
        /// 服务名称
        /// </summary>
        [KeyName(KeyName = "DisplayName")]
        [ValueType(ValueType = RegistryValueKind.String)]
        public string DisplayName { get; set; }

        /// <summary>
        /// 服务的描述
        /// </summary>
        [KeyName(KeyName = "Description")]
        [ValueType(ValueType = RegistryValueKind.ExpandString)]
        public string Description { get; set; }

        /// <summary>
        /// 服务程序路径(执行字符串)
        /// </summary>
        [KeyName(KeyName = "ImagePath")]
        [ValueType(ValueType = RegistryValueKind.ExpandString)]
        public string ImagePath { get; set; }

        /// <summary>
        /// 启动类型
        /// </summary>
        [KeyName(KeyName = "Start")]
        [ValueType(ValueType = RegistryValueKind.DWord)]
        public StartType StartType { get; set; }
        /// <summary>
        /// 服务程序类型
        /// </summary>
        [KeyName(KeyName = "Type")]
        [ValueType(ValueType = RegistryValueKind.DWord)]
        public ServiceType ServiceType { get; set; }

        /// <summary>
        /// 服务名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 标准键之外的键集合
        /// </summary>
        public List<RegistryKeyInfo> AnotherKeys { get; }
        #endregion public property

        #region readonly filed
        //登录账户
        [KeyName(KeyName = "ObjectName")]
        [ValueType(ValueType = RegistryValueKind.String)]
        public string ObjectName { get; private set; }

        [KeyName(KeyName = "ErrorControl")]
        [ValueType(ValueType = RegistryValueKind.DWord)]
        //错误控制
        public ErrorControl ErrorControl { get; private set; }
        #endregion

        #region Constructor
        public Service() : this("LocalSystem", ErrorControl.Normal) { }
        public Service(string objectName, ErrorControl errorControl)
        {
            this.ObjectName = objectName;
            this.ErrorControl = ErrorControl;
            this.AnotherKeys = new List<RegistryKeyInfo>();
        }
        #endregion

        #region Innner Class
        /// <summary>
        /// 抽象的一个代表注册表键的值的Model
        /// </summary>
        public class RegistryKeyInfo
        {
            /// <summary>
            /// 键对应的值
            /// </summary>
            public object Value { get; set; }
            /// <summary>
            /// 键名
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// 值类型
            /// </summary>
            public RegistryValueKind KeyKind { get; set; }
        }
        #endregion
                   
        /// <summary>
        /// 获取此服务声明的所有的键名
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllKeyName()
        {
            List<string> result = new List<string>();
            foreach (RegistryKeyInfo info in AnotherKeys)
            {
                result.Add(info.Name);
            }
            PropertyInfo[] allProperties = this.GetType().GetProperties();
            var customerAttrName = from property in allProperties
                                   where property.GetCustomAttribute(typeof(KeyNameAttribute)) != null
                                   select (property.GetCustomAttribute(typeof(KeyNameAttribute)) as KeyNameAttribute).KeyName;
            result.AddRange(customerAttrName);
            return result;
        }

        /// <summary>
        /// 查看指定服务中指定的键是否存在
        /// </summary>
        /// <param name="ServiceName">指定的服务名称</param>
        /// <param name="KeyName">指定的键的名称</param>
        /// <returns></returns>
        public bool IsServiceKeyExist(string serviceName, string keyName)
        {
            bool result = false;
            result =GetAllKeyName().Contains(keyName);
            return result;
        }
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
        Application = 0x10,
        /// <summary>
        /// 其他
        /// </summary>
        Other = 0x20
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
