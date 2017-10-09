using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Service.ServiceInstaller
{
    /// <summary>
    /// 服务键值对集合中键的名称
    /// </summary>
    [AttributeUsage(validOn:AttributeTargets.All)]
    public class KeyNameAttribute : Attribute
    {
        public string KeyName;
    }
    /// <summary>
    /// 服务键值对集合中值的类型
    /// </summary>
    [AttributeUsage(validOn:AttributeTargets.All)]
    public class ValueTypeAttribute : Attribute
    {
        public RegistryValueKind ValueType;
    }
}
