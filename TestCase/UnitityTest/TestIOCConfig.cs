using Cqwang.BackEnd.CSharp.Unity.IOC;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cqwang.BackEnd.CSharp.Unity.TestCase
{
    class TestIOCConfig
    {
        /// <summary>
        /// 依赖注入，控制权交给配置文件
        /// </summary>
        public static void Test()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            string mediaName = ConfigurationManager.AppSettings["MediaName"];
            IMediaFile mediaFile = assembly.CreateInstance(mediaName) as IMediaFile;

            string playerName = ConfigurationManager.AppSettings["PlayerName"];
            IPlayer player = assembly.CreateInstance(playerName, false, BindingFlags.Instance | BindingFlags.Public, null, new object[] { mediaFile }, null, null) as IPlayer;
            player.Play();
        }
    }
}
