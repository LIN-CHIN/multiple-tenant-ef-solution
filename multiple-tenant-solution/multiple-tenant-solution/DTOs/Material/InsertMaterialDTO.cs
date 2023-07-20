using Newtonsoft.Json;
using multiple_tenant_solution.Entities;

namespace multiple_tenant_solution.DTOs.Material
{
    /// <summary>
    /// 新增物料的 DTO
    /// </summary>
    public class InsertMaterialDTO
    {
        /// <summary>
        /// 料號
        /// </summary>
        [JsonRequired]
        public string Number { get; set; }

        /// <summary>
        /// 料號名稱
        /// </summary>
        [JsonRequired]
        public string Name { get; set; }

        /// <summary>
        /// 建立日期
        /// </summary>
        [JsonIgnore]
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// 轉成 Materials 實體
        /// </summary>
        /// <param name="tenantNumber"></param>
        /// <param name="createUser"></param>
        /// <returns></returns>
        public Materials ToMaterials(string tenantNumber, string createUser) 
        {
            return new Materials
            {
                Number = Number,
                Name = Name,
                TenantNumber = tenantNumber,
                CreateDate = CreateDate,
                CreateUser = createUser
            };
        }
    }
}
