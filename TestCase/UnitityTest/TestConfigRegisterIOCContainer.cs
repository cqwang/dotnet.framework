using Cqwang.BackEnd.CSharp.Unity.IOC;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqwang.BackEnd.CSharp.Unity.TestCase
{
    class TestConfigRegisterIOCContainer
    {
        /// <summary>
        /// 依赖注入，通过配置文件在IOC容器中注册类型映射，推荐
        /// </summary>
        public static void Test()
        {
            var section = ConfigurationManager.GetSection(UnityConfigurationSection.SectionName) as UnityConfigurationSection;
            IUnityContainer container = new UnityContainer();
            section.Configure(container, "defaultContainer");

            //var mediaFiles = container.ResolveAll<IMediaFile>();
            //var firstMediaFile = container.Resolve<IMediaFile>("first MP4MediaFile");
            var player = container.Resolve<IPlayer>();
            player.Play();
        }
    }
}
