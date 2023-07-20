using Newtonsoft.Json;

namespace multiple_tenant_solution.ExternalServices.DTOs
{
    /// <summary>
    /// 租戶實體
    /// </summary>
    public class TenantDTO
    {
        /// <summary>
        /// 租戶代碼
        /// </summary>
        [JsonRequired]
        public string Number { get; set; }

        /// <summary>
        /// 租戶名稱
        /// </summary>
        [JsonRequired]
        public string Name { get; set; }

        /// <summary>
        /// 連線帳號
        /// </summary>
        [JsonRequired]
        public string ConnectionUserId { get; set; }

        /// <summary>
        /// 連線密碼
        /// </summary>
        [JsonRequired]
        public string ConnectionPwd { get; set; }

        /// <summary>
        /// 是否啟用
        /// </summary>
        [JsonRequired]
        public bool IsEnable { get; set; }
    }
}
