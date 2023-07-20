using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using multiple_tenant_solution.Entities;
using multiple_tenant_solution.ExternalServices.DTOs;
using multiple_tenant_solution.ExternalServices.Tenant;
using multiple_tenant_solution.Services.User;
using System.Xml.Linq;

namespace multiple_tenant_solution
{
    /// <summary>
    /// 租戶Filter
    /// </summary>
    /// <remarks>
    /// 呼叫API時都要過這一個Filter
    /// </remarks>
    public class TenantFilterAttribute : ActionFilterAttribute
    {
        private readonly CurrentUserInfo _currentUserInfo;
        private readonly ITenantExternalService _tenantExternalService;
        private readonly IUserService _userService;
        private readonly ApiSettings _apiSettings;
        public TenantFilterAttribute(
            CurrentUserInfo currentUserInfo,
            ITenantExternalService tenantExternalService,
            IUserService userService,
            ApiSettings apiSettings)
        {
            _currentUserInfo = currentUserInfo;
            _tenantExternalService = tenantExternalService;
            _userService = userService;
            _apiSettings = apiSettings; 
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string tenantNumber = context.HttpContext.Request.Headers["TenantNumber"].ToString();
            string account = context.HttpContext.Request.Headers["Account"].ToString();

            if (string.IsNullOrWhiteSpace(tenantNumber))
            {
                context.Result = new BadRequestObjectResult("請輸入TenantNumber");
                return;
            } 
            
            if (string.IsNullOrWhiteSpace(account)) 
            {
                context.Result = new BadRequestObjectResult("請輸入Account");
                return;
            }

            TenantDTO? tenantDTO = _tenantExternalService.GetByNumber(tenantNumber);

            if (tenantDTO == null)
            {
                // 如果不存在，則回傳 400 Bad Request 錯誤
                context.Result = new BadRequestObjectResult("找不到租戶代碼");
                return;
            }

            _currentUserInfo.TenantNumber = tenantNumber;
            _currentUserInfo.ConnectionUserId = tenantDTO.ConnectionUserId;
            _currentUserInfo.ConnectionPwd = tenantDTO.ConnectionPwd;

            Users? user = _userService.GetUserByAccount(account, tenantNumber);
            if (user == null)
            {
                // 如果不存在，則回傳 400 Bad Request 錯誤
                context.Result = new BadRequestObjectResult("找不到帳號");
                return;
            }

            _currentUserInfo.Id = user.Id;
            _currentUserInfo.Account = account;
            _currentUserInfo.Name = user.Name;
            
       
            base.OnActionExecuting(context);
        }
    }
}
