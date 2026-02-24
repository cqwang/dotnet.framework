using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqwang.BackEnd.CSharp.Unity.IOC
{
    /// <summary>
    /// MP4媒体文件
    /// </summary>
    public class MP4MediaFile : IMediaFile
    {
        public string FileDesc
        {
            get
            {
                return "MP4";
            }
        }
    }
}
