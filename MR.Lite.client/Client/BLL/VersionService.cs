using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Model;
using Utils;
using System.IO;

namespace Client.BLL
{
    /// <summary>
    /// 检查客户端主程升级的业务类
    /// </summary>
    public class VersionService
    {
        /// <summary>
        /// 获取配置文件中当前主程的版本信息
        /// </summary>
        /// <returns></returns>
        public MainClientVersion GetNowClientVersion()
        {
            MainClientVersion result=null;
            string currentDirec = Environment.CurrentDirectory;
            string versionConfigFilePath = System.IO.Path.Combine(currentDirec, "version.config");
            StreamReader reader = new StreamReader(versionConfigFilePath, Encoding.UTF8);
            string configString = reader.ReadToEnd();
            result = JsonHelper.DeserializeJsonToObject<MainClientVersion>(configString);
            return result;
        }

        /// <summary>
        /// 更新配置文件中当前主程的版本信息
        /// </summary>
        /// <param name="newVersion"></param>
        /// <returns></returns>
        public  bool UpdateClientVersionConfig(MainClientVersion newVersion)
        {
            bool result = false;
            string newConfigString =JsonHelper.SerializeObject(newVersion);
            string currentDirec = Environment.CurrentDirectory;
            string versionConfigFilePath = System.IO.Path.Combine(currentDirec, "version.config");
            FileStream fs = new FileStream(versionConfigFilePath, FileMode.Create,FileAccess.ReadWrite);
            byte[] newConfigBytes= Encoding.UTF8.GetBytes(newConfigString);
            fs.Write(newConfigBytes, 0, newConfigBytes.Length);
            fs.Close();
            result = true;
            return result;
        }

    }
}
