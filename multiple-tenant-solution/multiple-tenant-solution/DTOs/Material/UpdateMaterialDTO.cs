using Newtonsoft.Json;

namespace multiple_tenant_solution.DTOs.Material
{
    /// <summary>
    /// 更新物料的 DTO
    /// </summary>
    public class UpdateMaterialDTO
    {
        /// <summary>
        /// 料號名稱
        /// </summary>
        [JsonRequired]
        public string Name { get; set; }

    }
}
