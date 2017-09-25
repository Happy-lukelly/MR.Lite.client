using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Main.ServiceInstaller
{
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
}
