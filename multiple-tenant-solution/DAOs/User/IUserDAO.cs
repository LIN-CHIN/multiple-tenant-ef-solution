using multiple_tenant_solution.Entities;

namespace multiple_tenant_solution.DAOs.User
{
    /// <summary>
    /// 使用者的 DAO Interface
    /// </summary>
    public interface IUserDAO
    {
        /// <summary>
        /// 根據帳號取得使用者資訊
        /// </summary>
        /// <param name="account">帳號</param>
        /// <param name="tenantNumber">租戶代碼</param>
        /// <returns></returns>
        Users? GetByAccount(string account, string tenantNumber);
    }
}
