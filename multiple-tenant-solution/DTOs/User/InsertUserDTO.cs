using multiple_tenant_solution.Entities;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace multiple_tenant_solution.DTOs.User
{
    /// <summary>
    /// 新增使用者
    /// </summary>
    public class InsertUserDTO
    {
        /// <summary>
        /// 帳號
        /// </summary>
        [JsonRequired]
        public string Account { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        [JsonRequired]
        public string Pwd { get; set; }

        /// <summary>
        /// 名稱
        /// </summary>
        [JsonRequired]
        public string Name { get; set; }

        /// <summary>
        /// 轉成Users實體
        /// </summary>
        /// <param name="createUser">建立者</param>
        /// <param name="tenantNumber">租戶代碼</param>
        /// <returns></returns>
        public Users ToUsers(string createUser, string tenantNumber) 
        {
            return new Users
            {
                Account = Account,
                Pwd = Pwd,
                Name = Name,
                TenantNumber = tenantNumber,
                CreateDate = DateTime.UtcNow,
                CreateUser = createUser
            };
        }
    }
}
