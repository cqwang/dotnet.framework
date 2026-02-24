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
    /// 实体类 tb_account_contact, 此类请勿动，以方便表字段更改时重新生成覆盖
    /// </summary>
    [Serializable]
    [Table("tb_account_contact")]
    public sealed class AccountContactEntity : BaseEntity
    {
        #region 实体属性

        /// <summary>
        /// 联系人标识
        /// </summary>
        [Column("ContactId")]
        [Key]
        public long ContactId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Column("Name")]
        public string Name { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Column("MobilePhone")]
        public string MobilePhone { get; set; }

        /// <summary>
        /// 固定电话
        /// </summary>
        [Column("Telephone")]
        public string Telephone { get; set; }

        /// <summary>
        /// 其它电话，多个用逗号分隔
        /// </summary>
        [Column("OtherPhones")]
        public string OtherPhones { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Column("Email")]
        public string Email { get; set; }

        /// <summary>
        /// QQ号码
        /// </summary>
        [Column("QQ")]
        public string QQ { get; set; }

        /// <summary>
        /// 微信号码
        /// </summary>
        [Column("Wechat")]
        public string Wechat { get; set; }

        #endregion
    }
}
