using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Threading;

namespace Utils.ServNetProtocol.Model
{
    /// <summary>
    /// 使用流方式设置消息体的发送消息信息
    /// </summary>
    public class StreamSendMessageInfo:SendMessgeInfo
    {
        //消息体字节数组
        private byte[] m_MessageArray;
        //消息体内存流
        private Stream MessageBodyStream;
        //读取时是否可用当前字节数组的缓存
        private bool IsCanUseCache = false;
        #region constructor
        public StreamSendMessageInfo(IPAddress serverAddress, string messageVersion):base(serverAddress,messageVersion)
        {
            this.MessageBodyStream = new MemoryStream();
        }
        #endregion
        /// <summary>
        /// 获取要发送消息的字节数组
        /// </summary>
        public override byte[] MessageArray
        {
            get
            {
                lock (this)
                {
                    if (!IsCanUseCache)
                    {
                        MemoryStream ms = MessageBodyStream as MemoryStream;
                        m_MessageArray = new byte[ms.Length + 10];
                        //写入负载
                        int streamLen = MessageBodyStream.Read(m_MessageArray, 10, m_MessageArray.Length);
                        if (streamLen == m_MessageArray.Length)
                        {
                            string header = streamLen.ToString() + "\r\n";
                            byte[] headerBytes = Encoding.UTF8.GetBytes(header);
                            if (headerBytes.Length == 10)
                            {
                                headerBytes.CopyTo(m_MessageArray, 0);
                                //重新读取后下次写入之前可以访问上一次的缓存数据
                                IsCanUseCache = true;
                            }
                            else
                            {
                                throw new Exception("获取消息体字节流时出现异常");
                            }
                        }
                        else
                        {
                            throw new Exception("获取消息体字节流时出现异常");
                        }
                    }
                    return m_MessageArray;
                }
            }
        }

        /// <summary>
        /// 将指定的字节数组写入到消息体中
        /// </summary>
        public void WriteMessageByte(byte[] bytes)
        {
            WriteMessageBytes(bytes, 0, bytes.Length);
        }
        /// <summary>
        /// 将指定字节数组中的指定部分写入到消息体中
        /// </summary>
        public void WriteMessageBytes(byte[] bytes, int offset, int count)
        {
            MessageBodyStream.Write(bytes, offset, count);
            IsCanUseCache = false;
        }

        //析构
        ~StreamSendMessageInfo()
        {
            MessageBodyStream.Close();
        }
    }
}
