using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dotnet.framework.IMQ.MsMQ
{
    public enum ReceiveMode
    {
        /// <summary>
        /// 同步接收消息
        /// </summary>
        Synchrouse,
        /// <summary>
        /// 异步接收消息
        /// </summary>
        Asynchronouse,
    }
}
