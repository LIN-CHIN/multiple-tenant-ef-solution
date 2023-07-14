using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace multiple_tenant_solution.Entities
{
    /// <summary>
    /// 實體的基底類別
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// 流水號
        /// </summary>
        [Key]
        [Required]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        /// <summary>
        /// 建立日期
        /// </summary>
        [Required]
        [Column("create_date")]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 建立者
        /// </summary>
        [Required]
        [Column("create_user", TypeName = "varchar(50)")]
        public string CreateUser { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        [Column("update_date")]
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// 修改者
        /// </summary>
        [Column("update_user", TypeName = "varchar(50)")]
        public string? UpdateUser { get; set; }
    }
}
