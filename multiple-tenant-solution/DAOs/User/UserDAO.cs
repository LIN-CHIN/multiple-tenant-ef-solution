using multiple_tenant_solution.Context;
using multiple_tenant_solution.Entities;

namespace multiple_tenant_solution.DAOs.User
{
    /// <summary>
    /// 使用者的 DAO
    /// </summary>
    public class UserDAO : IUserDAO
    {
        private readonly DataContext _dataContext;

        public UserDAO(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }

        ///<inheritdoc/>
        public Users? GetByAccount(string account, string tenantNumber)
        {
            return _dataContext.Users
                .Where(u => u.Account == account &&
                            u.TenantNumber == tenantNumber)
                .SingleOrDefault();
        }
    }
}
