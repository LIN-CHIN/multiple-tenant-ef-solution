using multiple_tenant_solution.DAOs.User;
using multiple_tenant_solution.DTOs.User;
using multiple_tenant_solution.Entities;

namespace multiple_tenant_solution.Services.User
{
    /// <summary>
    /// 使用者的 Service
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserDAO _userDAO;
        private readonly CurrentUserInfo _currentUserInfo;

        public UserService(IUserDAO userDAO,
                CurrentUserInfo currentUserInfo) 
        {
            _userDAO = userDAO;
            _currentUserInfo = currentUserInfo;
        }

        ///<inheritdoc/>
        public Users? GetUserByAccount(string account, string tenantNumber)
        {
            return _userDAO.GetByAccount(account, tenantNumber);
        }

        ///<inheritdoc/>
        public Users Insert(InsertUserDTO insertDTO)
        {
            Users? user = _userDAO.GetByAccount(insertDTO.Account);

            if(user != null) 
            {
                throw new ArgumentException("帳號已存在");
            }

            return  _userDAO.Insert(insertDTO.ToUsers(
                _currentUserInfo.ConnectionUserId,
                _currentUserInfo.TenantNumber));
        }
    }
}
