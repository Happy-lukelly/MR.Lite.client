using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Reflection;

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
            if (!string.IsNullOrWhiteSpace(serviceName))
            {
                Service result = null;
                RegistryKey rk = Registry.LocalMachine;
                rk = rk.OpenSubKey("SYSTEM\\CurrentControlSet\\services", true);
                RegistryKey serviceKey = rk.OpenSubKey(serviceName);
                if (serviceKey != null)
                {
                    result = GetServiceByRegistryKey(serviceKey);
                }
                return result;
            }
            else
            {
                throw new Exception("Servcie Name Illegal");
            }
        }

        /// <summary>
        /// 根据指定的服务的注册表键获取服务信息
        /// </summary>
        /// <param name="key">服务对应的</param>
        /// <returns></returns>
        private Service GetServiceByRegistryKey(RegistryKey key)
        {
            Service service = null;
            service = new Service();
            Type serviceType = service.GetType();
            PropertyInfo[] properties = serviceType.GetProperties();
            string[] valueNames = key.GetValueNames();
            //判断是否是存在子键
            if (valueNames != null && valueNames.Length > 0)
            {
                List<Service.RegistryKeyInfo> allSubKeyInfos = new List<Service.RegistryKeyInfo>();
                //获取到所有的子健的信息
                foreach (string subKeyName in valueNames)
                {
                    RegistryValueKind kindType = key.GetValueKind(subKeyName);
                    object value = key.GetValue(subKeyName);
                    allSubKeyInfos.Add(new Service.RegistryKeyInfo() { Name = subKeyName, KeyKind = kindType, Value = value });
                }
                //轮询子键信息集合根据特性描述赋值
                foreach (Service.RegistryKeyInfo k in allSubKeyInfos)
                {
                    /*Service.RegistryKeyInfo keyInfo = (from Info in allSubKeyInfos
                                                       join property in properties
                                                       on 1 equals 1
                                                       //应要短路不然会NRE
                                                       where 
                                                       ((property.GetCustomAttributes(typeof(ValueTypeAttribute)).FirstOrDefault() as ValueTypeAttribute) != null 
                                                       && 
                                                       Info.KeyKind == (property.GetCustomAttributes(typeof(ValueTypeAttribute)).FirstOrDefault() as ValueTypeAttribute).ValueType)
                                                       && 
                                                       ((property.GetCustomAttributes(typeof(KeyNameAttribute)).FirstOrDefault() as KeyNameAttribute)!=null   
                                                       &&
                                                       Info.Name == (property.GetCustomAttributes(typeof(KeyNameAttribute)).FirstOrDefault() as KeyNameAttribute).KeyName)
                                                       select Info).FirstOrDefault();*/
                    PropertyInfo property = (from pro in properties
                                            where ((pro.GetCustomAttributes(typeof(KeyNameAttribute)).FirstOrDefault() as KeyNameAttribute))!=null && (pro.GetCustomAttributes(typeof(KeyNameAttribute)).FirstOrDefault() as KeyNameAttribute).KeyName == k.Name
                                            select pro).FirstOrDefault();
                    if (property != null)
                    {
                        //属性是枚举类型
                        if (property.GetType().IsEnum)
                        {
                            int intValue = int.Parse(k.Value.ToString());
                            object enumValue = Enum.Parse(property.GetType(), intValue.ToString(), true);
                            property.SetValue(service, enumValue);
                        }
                        else
                        {
                            property.SetValue(service, k.Value);
                        }
                    }
                    else
                    {
                        service.AnotherKeys.Add(k);
                    }
                    /*
                    //与服务标准属性匹配成功
                    if (keyInfo != null)
                    {
                        PropertyInfo property = (from pro in properties
                                                 where (pro.GetCustomAttribute(typeof(KeyNameAttribute)) as KeyNameAttribute).KeyName == keyInfo.Name
                                                 select pro).FirstOrDefault();
                        //属性是枚举类型
                        if (property.GetType().IsEnum)
                        {
                            int intValue = int.Parse(keyInfo.Value.ToString());
                            object enumValue = Enum.Parse(property.GetType(), intValue.ToString(), true);
                            property.SetValue(service, enumValue);
                        }
                        else
                        {
                            property.SetValue(service, keyInfo.Value);
                        }
                    }
                    //不是Model中预定义的标准服务的键名称
                    else
                    {
                        service.AnotherKeys.Add(keyInfo);
                    }*/
                }
            }
            return service;
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
