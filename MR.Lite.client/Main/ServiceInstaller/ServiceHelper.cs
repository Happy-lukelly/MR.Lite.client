﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Reflection;

namespace Service.ServiceInstaller
{
    public class ServiceHelper
    {
        #region  constructor
        public ServiceHelper()
        {
        }
        #endregion

        #region Public Method
        /// <summary>
        /// 返回指定名称的服务，或者返回null 若服务不存在
        /// </summary>
        /// <param name="serviceName">要查找的服务的名称</param>
        /// <returns></returns>
        public SystemService GetService(string serviceName)
        {
            if (!string.IsNullOrWhiteSpace(serviceName))
            {
                SystemService result = null;
                RegistryKey rk = Registry.LocalMachine;
                rk = rk.OpenSubKey("SYSTEM\\CurrentControlSet\\services", false);
                RegistryKey serviceKey = rk.OpenSubKey(serviceName);
                if (serviceKey != null)
                {
                    result = GetServiceByRegistryKey(serviceKey);
                    result.Name = serviceName;
                }
                return result;
            }
            else
            {
                throw new Exception("Servcie Name Illegal");
            }
        }

        /// <summary>
        /// 向系统中注册指定的服务
        /// </summary>
        /// <param name="service">要注册到系统中的服务</param>
        /// <returns></returns>
        public bool InstallService(SystemService service)
        {
            bool result = false;
            RegistryKey rk = Registry.LocalMachine;
            rk = rk.OpenSubKey("SYSTEM\\CurrentControlSet\\services", true);
            if (IsServiceExist(service.Name))
            {
                throw new Exception("specified service name are exist");
            }
            else
            {
                RegistryKey serviceKey = rk.CreateSubKey(service.Name);
                try
                {
                    InstallService(serviceKey, service);
                }
                finally
                {
                    rk.Close();
                    serviceKey.Close();
                }
                
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 查看指定服务名称是否存在
        /// </summary>
        /// <param name="ServiceName">要查看是否存在的服务名(PS:一定是SrerviceName而不是DisplayName)</param>
        /// <returns></returns>
        public bool IsServiceExist(string serviceName)
        {
            bool result = false;
            try
            {
                SystemService service = GetService(serviceName);
                if (service != null)
                {
                    result = true;
                }
            }
            catch (Exception e)
            {
                if (e.Message == "Servcie Name Illegal")
                {
                    result = false;
                }
            }
            return result;
        }

        /// <summary>
        /// 修改指定服务中指定键对应的值(自行确保值类型安全),并返回修改过的注册表中映射的service对象
        /// </summary>
        /// <param name="service">要修改的服务</param>
        /// <param name="valueName">要修改的键的名称</param>
        /// <param name="value">要修改的值</param>
        /// <returns></returns>
        public SystemService ChangeServiceValue(SystemService service, string valueName, RegistryValueKind valueKind, object value)
        {
            if (IsServiceExist(service.Name))
            {
                RegistryKey rk = Registry.LocalMachine;
                rk = rk.OpenSubKey("SYSTEM\\CurrentControlSet\\services", true);
                RegistryKey serviceKey = rk.OpenSubKey(service.Name, true);
                string[] valueNames = serviceKey.GetValueNames();
                if (valueNames.Contains(valueName))
                {
                    //刷新至系统
                    if (serviceKey.GetValueKind(valueName) == valueKind)
                    {
                        //做类型转换k
                        object writeToTableValue = value;
                        if (value.GetType().IsEnum)
                        {
                            writeToTableValue = (int)value;
                        }
                        try
                        {
                            serviceKey.SetValue(valueName, writeToTableValue, valueKind);
                        }
                        finally
                        {
                            rk.Close();
                            serviceKey.Close();
                        }
                    }
                    else
                    {
                        throw new Exception("specified value kind different with local system exist");
                    }
                    //修改要返回的对象
                    if (service.GetAllKeyName().Contains(valueName))
                    {
                        PropertyInfo property = (from pro in service.GetType().GetProperties()
                                                 where pro.GetCustomAttribute(typeof(KeyNameAttribute)) != null
                                                 && (pro.GetCustomAttribute(typeof(KeyNameAttribute)) as KeyNameAttribute).KeyName == valueName
                                                 select pro).FirstOrDefault();
                        if (property != null)
                        {
                            property.SetValue(service, value);
                        }
                    }
                    else
                    {
                        service.AnotherKeys.Add(new SystemService.RegistryKeyInfo() { Name = valueName, KeyKind = valueKind, Value = value });
                    }
                }
                else
                {
                    throw new Exception("KeyName Not Exisit,Please ensure the key added in specified service");
                }
            }
            else
            {
                throw new Exception("specified service not regisiter in the system");
            }
            return service;
        }

        /// <summary>
        /// 将指定的键值添加到服务中,并返回修改过的注册表中映射的service对象
        /// </summary>
        /// <param name="Service">要添加的服务</param>
        /// <param name="AddKeyInfo">添加的键值对</param>
        /// <returns></returns>
        public SystemService AddKeyToService(SystemService service, SystemService.RegistryKeyInfo addKeyInfo)
        {
            if (IsServiceExist(service.Name))
            {
                RegistryKey rk = Registry.LocalMachine;
                rk = rk.OpenSubKey("SYSTEM\\CurrentControlSet\\services", true);
                RegistryKey serviceKey = rk.OpenSubKey(service.Name, true);
                string[] valueNames = serviceKey.GetValueNames();
                var existKey = (from key in valueNames
                                where key == addKeyInfo.Name
                                select key).FirstOrDefault();
                if (existKey != null)
                {
                    throw new Exception("specified name key are exisit in service");
                }
                else
                {
                    //添加进系统注册表
                    try
                    {
                        serviceKey.SetValue(addKeyInfo.Name, addKeyInfo.Value, addKeyInfo.KeyKind);
                    }
                    finally
                    {
                        rk.Close();
                        serviceKey.Close();
                    }
                    //修改新添加的值
                    service = ChangeServiceValue(service, addKeyInfo.Name, addKeyInfo.KeyKind, addKeyInfo.Value);
                }
            }
            else
            {
                throw new Exception("specified service not regisiter in the system");
            }
            return service;
        }

        /// <summary>
        /// 删除指定名称的服务
        /// </summary>
        /// <param name="serviceName">要删除的服务名称</param>
        /// <exception cref="Exception">指定名称的服务不存在</exception>
        /// <returns></returns>
        public bool RemoveService(string serviceName)
        {
            bool result = false;
            SystemService existService = GetService(serviceName);
            if (existService == null)
            {
                throw new Exception("specified servcie name not exists in this system");
            }
            else
            {
                RegistryKey rk = Registry.LocalMachine;
                rk = rk.OpenSubKey("SYSTEM\\CurrentControlSet\\services", true);
                try
                {
                    rk.DeleteSubKeyTree(serviceName, true);
                    result = true;
                }
                finally
                {
                    rk.Close();
                }
            }
            return result;
        }
        #endregion

        #region Private Method
        /// <summary>
        /// 根据指定的服务的注册表键获取服务信息
        /// </summary>
        /// <param name="key">服务对应的</param>
        /// <returns></returns>
        private SystemService GetServiceByRegistryKey(RegistryKey key)
        {
            SystemService service = null;
            service = new SystemService();
            Type serviceType = service.GetType();
            PropertyInfo[] properties = serviceType.GetProperties();
            string[] valueNames = key.GetValueNames();
            //判断是否是存在子键
            if (valueNames != null && valueNames.Length > 0)
            {
                List<SystemService.RegistryKeyInfo> allSubKeyInfos = new List<SystemService.RegistryKeyInfo>();
                //获取到所有的子健的信息
                foreach (string subKeyName in valueNames)
                {
                    RegistryValueKind kindType = key.GetValueKind(subKeyName);
                    object value = key.GetValue(subKeyName);
                    allSubKeyInfos.Add(new SystemService.RegistryKeyInfo() { Name = subKeyName, KeyKind = kindType, Value = value });
                }
                //轮询子键信息集合根据特性描述赋值
                foreach (SystemService.RegistryKeyInfo k in allSubKeyInfos)
                {
                    PropertyInfo property = (from pro in properties
                                             where ((pro.GetCustomAttributes(typeof(KeyNameAttribute)).FirstOrDefault() as KeyNameAttribute)) != null && (pro.GetCustomAttributes(typeof(KeyNameAttribute)).FirstOrDefault() as KeyNameAttribute).KeyName == k.Name
                                             select pro).FirstOrDefault();
                    if (property != null)
                    {
                        //属性是枚举类型
                        if (property.PropertyType.IsEnum)
                        {
                            int intValue = int.Parse(k.Value.ToString());
                            object enumValue = Enum.Parse(property.PropertyType, intValue.ToString(), true);
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
                }
            }
            return service;
        }

        /// <summary>
        /// 安装服务
        /// </summary>
        /// <param name="serviceKey"></param>
        /// <param name="service"></param>
        private void InstallService(RegistryKey serviceKey, SystemService service)
        {
            PropertyInfo[] allProperty = service.GetType().GetProperties();

            var attributedProp = from prop in allProperty
                                 where prop.GetCustomAttribute(typeof(KeyNameAttribute)) != null
                                 select prop;
            List<SystemService.RegistryKeyInfo> allValueInfo = new List<SystemService.RegistryKeyInfo>();
            //取到所有value值信息
            allValueInfo.AddRange(service.AnotherKeys);
            foreach (var prop in attributedProp)
            {
                if (prop.GetValue(service) != null)
                {
                    object value = prop.GetValue(service);
                    string name = (prop.GetCustomAttribute(typeof(KeyNameAttribute)) as KeyNameAttribute).KeyName;
                    RegistryValueKind kind = (prop.GetCustomAttribute(typeof(ValueTypeAttribute)) as ValueTypeAttribute).ValueType;
                    allValueInfo.Add(new SystemService.RegistryKeyInfo() { Name = name, Value = value, KeyKind = kind });
                }
            }
            foreach (var valueInfo in allValueInfo)
            {
                AddKeyToService(service, valueInfo);
            }
        }
        #endregion

    }

}
