using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using log4net;
using log4net.Config;

namespace dotnet.framework.Log.Db
{
    public class Logger
    {
        private static ILog _log;
        private static object logLocker = new object();

        public static ILog log
        {
            get
            {
                if (_log == null)
                {
                    lock (logLocker)
                    {
                        if (_log == null)
                        {
                            var repository = LogManager.GetRepository();
                            var appenderName = string.Concat("mongoDBPoolAppender_", DateTime.Now.Ticks);
                            var appender = new MongoDBPoolAppender(appenderName);
                            BasicConfigurator.Configure(appender);
                            appender.ActivateOptions();
                            _log = LogManager.GetLogger(appender.Name);
                        }
                    }
                }
                return _log;
            }
        }

        public static void Info(string title, string message, string index, Exception ex = null)
        {
            var method = new StackFrame(1).GetMethod();
            var logMessage = new LogMessage
            {
                Title = title,
                Index = index,
                ClientMessage = message,
                Method = string.Join(".", method.DeclaringType.FullName, method.Name),
                APPID = "",
                ServerIP = "",
                Group = ""
            };
            log.Info(logMessage, ex);;
        }


        public static void Warn(string title, string message, string index, Exception ex = null)
        {
            var method = new StackFrame(1).GetMethod();
            var logMessage = new LogMessage
            {
                Title = title,
                Index = index,
                ClientMessage = message,
                Method = string.Join(".", method.DeclaringType.FullName, method.Name),
                APPID = "",
                ServerIP = "",
                Group = ""
            };
            log.Warn(logMessage, ex);
        }

        public static void Error(string title, string message, string index, Exception ex = null)
        {
            var method = new StackFrame(1).GetMethod();
            var logMessage = new LogMessage
            {
                Title = title,
                Index = index,
                ClientMessage = message,
                Method = string.Join(".", method.DeclaringType.FullName, method.Name),
                APPID = "",
                ServerIP = "",
                Group = ""
            };
            log.Error(logMessage, ex);
        }

        public static void SetConfig(string configFile = null)
        {
            if (string.IsNullOrEmpty(configFile) || !File.Exists(configFile))
            {
                log4net.Config.XmlConfigurator.Configure();//从项目默认的.config文件中读取并初始化
            }
            else
            {
                var fileInfo = new FileInfo(configFile);
                log4net.Config.XmlConfigurator.Configure(fileInfo);
            }
        }
    }
}
