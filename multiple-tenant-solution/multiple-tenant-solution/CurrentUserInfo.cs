using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace multiple_tenant_solution
{
    /// <summary>
    /// 用來記錄當前使用者的資訊
    /// </summary>
    /// <remarks>
    /// 不能當作輸出回傳至前端
    /// </remarks>
    public class CurrentUserInfo
    {
        [JsonRequired]
        public long Id { get; set; }

        /// <summary>
        /// 帳號
        /// </summary>
        [JsonRequired]
        public string Account { get; set; }

        /// <summary>
        /// 使用者名稱
        /// </summary>
        [JsonRequired]
        public string Name { get; set; }

        /// <summary>
        /// 租戶Number
        /// </summary>
        [JsonRequired]
        public string TenantNumber { get; set; }

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
    }
}
