using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqwang.SDK.EntityFramework.TestCase
{
    /// <summary>
    /// 实体类 tb_account_category, 此类请勿动，以方便表字段更改时重新生成覆盖
    /// </summary>
    [Serializable]
    [Table("tb_account_category")]
    public sealed class AccountCategoryEntity : BaseEntity
    {
        #region 实体属性

        /// <summary>
        /// 经营类别标识
        /// </summary>
        [Column("CategoryId")]
        [Key]
        public long CategoryId { get; set; }

        /// <summary>
        /// 经营类别标识
        /// </summary>
        [Column("Name")]
        public string Name { get; set; }

        /// <summary>
        /// 父类别标识
        /// </summary>
        [Column("ParentCategoryId")]
        public long ParentCategoryId { get; set; }

        #endregion
    }
}
