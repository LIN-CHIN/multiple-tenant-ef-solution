using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace multiple_tenant_solution.Entities
{
    /// <summary>
    /// 物料
    /// </summary>
    [Table("materials")]
    public class Materials : BaseEntity
    {
        /// <summary>
        /// 料號
        /// </summary>
        [Required]
        [Column("number", TypeName = "varchar(50)")]
        public string Number { get; set; }

        /// <summary>
        /// 料號名稱
        /// </summary>
        [Required]
        [Column("name", TypeName = "varchar(50)")]
        public string Name { get; set; }

        /// <summary>
        /// 租戶Number
        /// </summary>
        [Required]
        [Column("tenant_number", TypeName = "varchar(50)")]
        public string TenantNumber { get; set; }
    }
}
