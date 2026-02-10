using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using log4net;

namespace dotnet.common.Log.File
{
    public class Logger
    {
        private static readonly ILog infoLogger = LogManager.GetLogger("logInfo");
        private static readonly ILog errorLogger = LogManager.GetLogger("logError");

        /// <summary>
        /// 初始化log4net的配置
        /// </summary>
        /// <param name="configFile"></param>
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

        internal static void Write(string info)
        {
            if (infoLogger.IsInfoEnabled)
            {
                infoLogger.Info(info);
            }
        }

        internal static void Write(string info, Exception e)
        {
            if (errorLogger.IsErrorEnabled)
            {
                errorLogger.Error(info, e);
            }
        }
    }
}
