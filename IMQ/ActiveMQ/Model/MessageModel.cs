using Apache.NMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet.framework.IMQ
{
    public class MessageModel<T>
    {
        /// <summary>
        /// 消息内容
        /// </summary>
        public T Body { get; set; }

        /// <summary>
        /// 消息优先级
        /// </summary>
        public MsgPriority Piority { get; set; }

        /// <summary>
        /// 延迟发送时间（毫秒）
        /// </summary>
        public long? DelayMillionSeconds { get; set; }
    }
}
