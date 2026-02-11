using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet.framework.IMQ
{
    [Serializable]
    public class SyncData
    {
        public string DB { get; set; }

        public string Table { get; set; }

        public int ID { get; set; }

        /// <summary>
        /// -1: 删除
        ///  0：更新
        ///  1: 增加
        /// </summary>
        public int Operate { get; set; }
    }
}
