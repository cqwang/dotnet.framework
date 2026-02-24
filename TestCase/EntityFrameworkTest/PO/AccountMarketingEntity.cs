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
    /// 实体类 tb_account_marketing, 此类请勿动，以方便表字段更改时重新生成覆盖
    /// </summary>
    [Serializable]
    [Table("tb_account_marketing")]
    public sealed class AccountMarketingEntity : BaseEntity
    {
        #region 实体属性

        /// <summary>
        /// 营销标识
        /// </summary>
        [Column("MarketingId")]
        [Key]
        public long MarketingId { get; set; }

        /// <summary>
        /// 店铺标识
        /// </summary>
        [Column("AccountId")]
        public long AccountId { get; set; }

        /// <summary>
        /// 营销方式：0-未知，1-移动电话，2-固定电话，3-短信，4-微信，5-QQ,6-邮件
        /// </summary>
        [Column("NotifyMethod")]
        public byte NotifyMethod { get; set; }

        /// <summary>
        /// 营销反馈：0-未知，1-无效，2-拒绝，3-接收，4-注册，5-付费
        /// </summary>
        [Column("Feedback")]
        public byte Feedback { get; set; }

        #endregion
    }
}
