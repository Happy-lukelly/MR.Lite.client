using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    /// <summary>
    /// 客户端主程序的版本信息(此类字段均为静态字段用来记录客户端主程序的版本信息)
    /// </summary>
    public class MainClientVersion
    {
        private readonly Guid m_VersionSignature;
        private readonly string m_Version;
        private readonly DateTime m_UpdateTime;
        private readonly Guid m_MachineSignature;

        /// <summary>
        /// 版本签名
        /// </summary>
        public Guid VersionSignature { get { return m_VersionSignature; } }

        /// <summary>
        /// 版本号
        /// </summary>
        public string Version { get { return m_Version; } }

        /// <summary>
        /// 版本更新时间
        /// </summary>
        public DateTime UpdateTime { get { return m_UpdateTime; } }

        /// <summary>
        /// Client的机器唯一签名
        /// </summary>
        public Guid MachineSignature { get { return m_MachineSignature; } }

        public MainClientVersion()
        {
            this.m_VersionSignature = new Guid();
            this.m_Version = "version";
            this.m_UpdateTime = DateTime.Now;
        }
    }
}
