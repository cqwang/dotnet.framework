using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqwang.BackEnd.CSharp.Unity.IOC
{
    /// <summary>
    /// QQ播放器 属性注入
    /// </summary>
    public class QQPlayerPropertyInjection : IPlayer
    {
        [Dependency]
        public IMediaFile MediaFile { get; set; }

        public void Play()
        {
            Console.WriteLine(this.MediaFile.FileDesc);
        }
    }
}
