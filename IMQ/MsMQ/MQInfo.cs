using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Messaging;

namespace dotnet.framework.IMQ.MsMQ
{
    public class MQInfo
    {
        /// <summary>
        /// 消息队列路径
        /// </summary>
        public string PathName { get; set; }
        /// <summary>
        /// 序列化方式
        /// </summary>
        public IMessageFormatter Formatter { get; set; }
    }
}
