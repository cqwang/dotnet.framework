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
    /// 实体类 tb_account, 此类请勿动，以方便表字段更改时重新生成覆盖
    /// </summary>
    [Serializable]
    [Table("tb_account")]
    public sealed class AccountEntity : BaseEntity
    {
        #region 实体属性

        /// <summary>
        /// 店铺标识
        /// </summary>
        [Column("AccountId")]
        [Key]
        public long AccountId { get; set; }

        /// <summary>
        /// 店铺名称
        /// </summary>
        [Column("Name")]
        public string Name { get; set; }

        /// <summary>
        /// 数据来源
        /// </summary>
        [Column("Source")]
        public string Source { get; set; }

        /// <summary>
        /// 店铺地址标识
        /// </summary>
        [Column("AddressId")]
        public long? AddressId { get; set; }

        /// <summary>
        /// 经营类别标识
        /// </summary>
        [Column("CategoryId")]
        public long? CategoryId { get; set; }

        /// <summary>
        /// 店铺描述标识
        /// </summary>
        [Column("DescriptionId")]
        public long? DescriptionId { get; set; }

        /// <summary>
        /// 联系人标识
        /// </summary>
        [Column("ContactId")]
        public long? ContactId { get; set; }

        /// <summary>
        /// 店铺状态：0-入库，1-激活，4-注册，5-付费
        /// </summary>
        [Column("Status")]
        public byte Status { get; set; }

        #endregion
    }
}
