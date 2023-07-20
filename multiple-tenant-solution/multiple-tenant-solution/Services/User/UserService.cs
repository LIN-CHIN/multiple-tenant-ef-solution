using multiple_tenant_solution.DAOs.User;
using multiple_tenant_solution.Entities;

namespace multiple_tenant_solution.Services.User
{
    /// <summary>
    /// 使用者的 Service
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserDAO _userDAO;

        public UserService(IUserDAO userDAO) 
        {
            _userDAO = userDAO;
        }

        ///<inheritdoc/>
        public Users? GetUserByAccount(string account, string tenantNumber)
        {
            return _userDAO.GetByAccount(account, tenantNumber);
        }
    }
}
