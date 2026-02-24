using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqwang.BackEnd.CSharp.Unity.IOC
{
    /// <summary>
    /// QQ播放器
    /// </summary>
    public class QQPlayer : IPlayer
    {
        private IMediaFile _mediaFile;

        public QQPlayer(IMediaFile mediaFile)
        {
            this._mediaFile = mediaFile;
        }

        public void Play()
        {
            Console.WriteLine(this._mediaFile.FileDesc);
        }
    }
}
