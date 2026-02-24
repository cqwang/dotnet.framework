using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqwang.BackEnd.CSharp.MySQL.TestCase
{
    /// <summary>
    /// 实体类 productbase, 此类请勿动，以方便表字段更改时重新生成覆盖
    /// </summary>
    [Serializable]
    [Table("productbase", Schema = "ProductDB")]
    public partial class ProductBaseEntity
    {
        #region 实体属性

        /// <summary>
        /// 产品ID
        /// </summary>
        [Column("ProductID")]
        [Key]
        public int ProductID { get; set; }

        /// <summary>
        /// 关联 ProductType.ProductTypeID
        /// </summary>
        [Column("ProductTypeID")]
        public int ProductTypeID { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        [Column("ProductName")]
        public string ProductName { get; set; }

        /// <summary>
        /// 产品副标题
        /// </summary>
        [Column("SubName")]
        public string SubName { get; set; }

        /// <summary>
        /// 自定义标签逗号分隔
        /// </summary>
        [Column("Tag")]
        public string Tag { get; set; }

        /// <summary>
        /// 几天
        /// </summary>
        [Column("Days")]
        public int? Days { get; set; }

        /// <summary>
        /// 几夜
        /// </summary>
        [Column("Nights")]
        public int? Nights { get; set; }

        /// <summary>
        /// 目的地描述
        /// </summary>
        [Column("DestDesc")]
        public string DestDesc { get; set; }

        /// <summary>
        /// 推荐理由
        /// </summary>
        [Column("Recommended")]
        public string Recommended { get; set; }

        /// <summary>
        /// 预订限制
        /// </summary>
        [Column("BookingLimit")]
        public string BookingLimit { get; set; }

        /// <summary>
        /// 违约条款
        /// </summary>
        [Column("BreachClause")]
        public string BreachClause { get; set; }

        /// <summary>
        /// 签证说明
        /// </summary>
        [Column("VisaExplain")]
        public string VisaExplain { get; set; }

        /// <summary>
        /// 产品说明
        /// </summary>
        [Column("Remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 出行须知
        /// </summary>
        [Column("TravelInfo")]
        public string TravelInfo { get; set; }

        /// <summary>
        /// 支付信息
        /// </summary>
        [Column("PayInfo")]
        public string PayInfo { get; set; }

        /// <summary>
        /// 安全指南
        /// </summary>
        [Column("SecurityGuide")]
        public string SecurityGuide { get; set; }

        /// <summary>
        /// 是否上线(1：上线 用户可以查询到，2，编辑中，）
        /// </summary>
        [Column("OnlineStatus")]
        public int OnlineStatus { get; set; }

        /// <summary>
        /// 最后操作人
        /// </summary>
        [Column("LastUpdateBy")]
        public string LastUpdateBy { get; set; }

        /// <summary>
        /// 最后操作时间
        /// </summary>
        [Column("LastUpdateTime")]
        public DateTime LastUpdateTime { get; set; }

        /// <summary>
        /// 酒店id
        /// </summary>
        [Column("HotelId")]
        public int? HotelId { get; set; }

        /// <summary>
        /// 产品供应商
        /// </summary>
        [Column("Vendor")]
        public string Vendor { get; set; }

        /// <summary>
        /// 行程推荐
        /// </summary>
        [Column("TravelRecommend")]
        public string TravelRecommend { get; set; }

        /// <summary>
        ///  0:false(未删除),1:true(删除)
        /// </summary>
        [Column("IsDelete")]
        public bool IsDelete { get; set; }

        #endregion
    }
}
