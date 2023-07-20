using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace multiple_tenant_storage.Entities
{
    /// <summary>
    /// 租戶
    /// </summary>
    [Table("tenants", Schema = "app_tenant_schema")]
    public class Tenants : BaseEntity
    {
        /// <summary>
        /// 租戶的代碼
        /// </summary>
        [Required]
        [Column("number", TypeName = "varchar(50)")]
        public string Number { get; set; }

        /// <summary>
        /// 租戶的名稱
        /// </summary>
        [Required]
        [Column("name", TypeName = "varchar(50)")]
        public string Name { get; set; }

        /// <summary>
        /// 連線帳號
        /// </summary>
        [Required]
        [Column("connection_user_id", TypeName = "varchar(50)")]
        public string ConnectionUserId { get; set; }

        /// <summary>
        /// 連線密碼
        /// </summary>
        [Required]
        [Column("connection_pwd", TypeName = "varchar(50)")]
        public string ConnectionPwd { get; set; }

        /// <summary>
        /// 是否啟用
        /// </summary>
        [Column("is_enable")]
        public bool? IsEnable { get; set; } = true;
    }
}
