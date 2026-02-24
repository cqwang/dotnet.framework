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
    /// 实体类 tb_account_address, 此类请勿动，以方便表字段更改时重新生成覆盖
    /// </summary>
    [Serializable]
    [Table("tb_account_address")]
    public sealed class AccountAddressEntity : BaseEntity
    {
        #region 实体属性

        /// <summary>
        /// 地址标识
        /// </summary>
        [Column("AddressId")]
        [Key]
        public long AddressId { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        [Column("City")]
        public string City { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        [Column("Region")]
        public string Region { get; set; }

        /// <summary>
        /// 商位号
        /// </summary>
        [Column("BoothNo")]
        public string BoothNo { get; set; }

        /// <summary>
        /// 地址明细
        /// </summary>
        [Column("Detail")]
        public string Detail { get; set; }

        #endregion
    }
}
