using multiple_tenant_storage.Entities;
using Newtonsoft.Json;

namespace multiple_tenant_storage.DTOs
{
    /// <summary>
    /// 新增租戶用的DTO
    /// </summary>
    public class InsertTenantDTO
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
        public string ConnectionUserId 
        {
            get; set;
        }

        /// <summary>
        /// 連線密碼
        /// </summary>
        [JsonRequired]
        public string ConnectionPwd
        {
            get; set;
        }

        /// <summary>
        /// 是否啟用
        /// </summary>
        public bool? IsEnable
        {
            get; set;
        } = true;

        /// <summary>
        /// 轉成Tenants
        /// </summary>
        /// <returns></returns>
        public Tenants ToTenants() 
        {
            return new Tenants
            {
                Number = Number,
                Name = Name,
                ConnectionUserId = ConnectionUserId,
                ConnectionPwd = ConnectionPwd,
                IsEnable = IsEnable,
                CreateDate = DateTime.UtcNow,
                CreateUser = "admin"
            };
        }
    }
}
