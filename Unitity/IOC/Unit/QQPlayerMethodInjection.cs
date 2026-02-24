using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqwang.BackEnd.CSharp.Unity.IOC
{
    /// <summary>
    /// QQ播放器 方法注入
    /// </summary>
    public class QQPlayerMethodInjection : IPlayer
    {
        private IMediaFile _mediaFile { get; set; }

        public void Play()
        {
            this.Play(_mediaFile);
        }

        [InjectionMethod]
        public void Play(IMediaFile mediaFile)
        {
            this._mediaFile = mediaFile;
        }
    }
}
