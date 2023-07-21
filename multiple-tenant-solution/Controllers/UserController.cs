using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using multiple_tenant_solution.DTOs.User;
using multiple_tenant_solution.Responses;
using multiple_tenant_solution.Services.User;

namespace multiple_tenant_solution.Controllers
{
    /// <summary>
    /// 使用者Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(TenantFilterAttribute))]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        /// <summary>
        /// 新增使用者
        /// </summary>
        /// <param name="insertDTO">要新增的資料</param>
        /// <returns></returns>
        [HttpPost()]
        public IActionResult Insert(InsertUserDTO insertDTO) 
        {
            _userService.Insert(insertDTO);
            return Ok(ApiResponse<string>.GetResult(""));
        }

    }
}
