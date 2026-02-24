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
    /// 实体类 tb_account_description, 此类请勿动，以方便表字段更改时重新生成覆盖
    /// </summary>
    [Serializable]
    [Table("tb_account_description")]
    public sealed class AccountDescriptionEntity : BaseEntity
    {
        #region 实体属性

        /// <summary>
        /// 表述标识
        /// </summary>
        [Column("DescriptionId")]
        [Key]
        public long DescriptionId { get; set; }

        /// <summary>
        /// 主营商品
        /// </summary>
        [Column("GoodsDescription")]
        public string GoodsDescription { get; set; }

        /// <summary>
        /// 贸易类型
        /// </summary>
        [Column("TradeType")]
        public string TradeType { get; set; }

        /// <summary>
        /// 店铺介绍
        /// </summary>
        [Column("AccountDescription")]
        public string AccountDescription { get; set; }

        /// <summary>
        /// 店铺主页
        /// </summary>
        [Column("PageUrl")]
        public string PageUrl { get; set; }

        /// <summary>
        /// 店铺评分
        /// </summary>
        [Column("Score")]
        public decimal Score { get; set; }

        /// <summary>
        /// 人均消费金额
        /// </summary>
        [Column("ConsumptionPerPerson")]
        public decimal ConsumptionPerPerson { get; set; }

        /// <summary>
        /// 营业时间
        /// </summary>
        [Column("BusinessHours")]
        public string BusinessHours { get; set; }

        #endregion
    }
}
