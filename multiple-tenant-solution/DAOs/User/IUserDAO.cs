using multiple_tenant_solution.DTOs.User;
using multiple_tenant_solution.Entities;

namespace multiple_tenant_solution.DAOs.User
{
    /// <summary>
    /// 使用者的 DAO Interface
    /// </summary>
    public interface IUserDAO
    {
        /// <summary>
        /// 根據帳號取得使用者資訊 (通常是給最高權限者使用)
        /// </summary>
        /// <param name="account">帳號</param>
        /// <param name="tenantNumber">租戶代碼</param>
        /// <returns></returns>
        Users? GetByAccount(string account, string tenantNumber);

        /// <summary>
        /// 根據帳號取得使用者資訊
        /// </summary>
        /// <param name="account">帳號</param>
        /// <returns></returns>
        Users? GetByAccount(string account);

        /// <summary>
        /// 新增使用者
        /// </summary>
        /// <param name="user">要新增的使用者實體</param>
        /// <returns></returns>
        Users Insert(Users user);
    }
}
