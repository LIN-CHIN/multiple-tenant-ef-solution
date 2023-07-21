using multiple_tenant_solution.DTOs.User;
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

        /// <summary>
        /// 新增使用者
        /// </summary>
        /// <param name="insertDTO">要新增的資料</param>
        /// <returns></returns>
        /// <remarks>
        /// 目前只想做簡單的新增，這功能是只能新增自己當下租戶的使用者
        /// 而不能指定要新增某租戶的使用者
        /// </remarks>
        Users Insert(InsertUserDTO insertDTO);
    }
}
