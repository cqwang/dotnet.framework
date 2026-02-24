using Cqwang.BackEnd.CSharp.Unity.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqwang.BackEnd.CSharp.Unity.TestCase
{
    class TestOrientedInterface
    {
        /// <summary>
        /// 面向接口编程方式
        /// </summary>
        public static void Test()
        {
            IMediaFile mediaFile = new MP4MediaFile();
            IPlayer player = new QQPlayer(mediaFile);
            player.Play();
        }
    }
}
