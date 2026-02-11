using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet.framework.IMQ
{
    public class DisasterMessageModel : MessageModel<string>
    {
        public string QueueName { get; set; }

        /// <summary>
        /// 消息生成的时间戳
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TimeSpan LifeTime { get; set; }

        public bool IsSendAble()
        {
            if (DelayMillionSeconds.HasValue)
            {
                return (DateTime.Now - Timestamp).TotalMilliseconds >= DelayMillionSeconds.Value;
            }
            return true;
        }
    }
}
