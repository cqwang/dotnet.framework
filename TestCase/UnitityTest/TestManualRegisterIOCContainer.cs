using Cqwang.BackEnd.CSharp.Unity.IOC;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqwang.BackEnd.CSharp.Unity.TestCase
{
    class TestManualRegisterIOCContainer
    {
        /// <summary>
        /// 依赖注入，在IOC容器中手工注册类型映射
        /// </summary>
        public static void Test()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IMediaFile, MP4MediaFile>();
            container.RegisterType<IPlayer, QQPlayer>();
            //container.RegisterType<IMediaFile, MP4MediaFile>("first MP4MediaFile");
            //container.RegisterType<IMediaFile, MP4MediaFile>("Second MP4MediaFile");

            //var mediaFiles = container.ResolveAll<IMediaFile>();
            //var firstMediaFile = container.Resolve<IMediaFile>("first MP4MediaFile");
            var player = container.Resolve<IPlayer>();
            player.Play();


            ////将类型注册为具体实现类型，并在配置文件中声明为单例
            //container.RegisterType<IPlayer, QQPlayer>(new ContainerControlledLifetimeManager());
            ////将类型注册为单例
            //container.RegisterType<QQPlayer>(new ContainerControlledLifetimeManager());

            ////将对象注册到IOC容器中，并在配置文件中声明为单例
            //var player = new QQPlayerPropertyInjection();
            //container.RegisterInstance<IPlayer>(player);
        }
    }
}
