using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqwang.SDK.EntityFramework.TestCase
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreateTime = DateTime.Now;
            LastUpdateTime = DateTime.Now;
            IsDelete = 0;
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("CreateTime")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最近更新时间
        /// </summary>
        [Column("LastUpdateTime")]
        public DateTime LastUpdateTime { get; set; }

        /// <summary>
        /// 删除状态：0-未删除，1-已删除
        /// </summary>
        [Column("IsDelete")]
        public byte IsDelete { get; set; }
    }
}
