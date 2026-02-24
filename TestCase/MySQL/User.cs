using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqwang.BackEnd.CSharp.MySQL.TestCase
{
    [Serializable]
    [Table("user", Schema = "test")]
    public class User
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column("ID")]
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Column("Name")]
        public string Name { get; set; }
    }
}
