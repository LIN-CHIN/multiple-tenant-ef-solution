using multiple_tenant_solution.Entities;

namespace multiple_tenant_solution.Services.User
{
    /// <summary>
    /// 使用者的 Service Interface
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 根據帳戶取得使用者
        /// </summary>
        /// <param name="account">帳號</param>
        /// <param name="tenantNumber">租戶代碼</param>
        /// <returns></returns>
        Users? GetUserByAccount(string account, string tenantNumber);
    }
}
