using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace multiple_tenant_solution.Entities
{
    /// <summary>
    /// 使用者
    /// </summary>
    [Table("users")]
    public class Users : BaseEntity
    {
        /// <summary>
        /// 帳號
        /// </summary>
        [Required]
        [Column("account", TypeName = "varchar(50)")]
        public string Account { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        [Required]
        [Column("pwd", TypeName = "varchar(50)")]
        public string Pwd { get; set; }

        /// <summary>
        /// 使用者名稱
        /// </summary>
        [Required]
        [Column("name", TypeName = "varchar(50)")]
        public string Name { get; set; }
    }
}
