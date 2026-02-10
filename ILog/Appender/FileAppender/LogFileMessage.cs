using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet.framework.Log.File
{
    public class LogFileMessage
    {
        public string MessageID { get; set; }

        public string MessageGroup { get; set; }

        public LogType MessageType { get; set; }

        public string MessageContent { get; set; }

        public DateTime Timestamp { get; set; }

        public Exception Ex { get; set; }

        public override string ToString()
        {
            return string.Join("\r\n", MessageID, MessageGroup, MessageContent, Timestamp.ToString());
        }
    }

    public enum LogType
    {
        Info,
        Error
    }
}
