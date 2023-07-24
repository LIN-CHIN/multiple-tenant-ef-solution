using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using multiple_tenant_storage.DTOs;
using multiple_tenant_storage.Entities;
using multiple_tenant_storage.Responses;
using multiple_tenant_storage.Services;

namespace multiple_tenant_storage.Controllers
{
    /// <summary>
    /// 租戶Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly ITenantService _tenantService;
        public TenantController(ITenantService tenantService) 
        {
            _tenantService = tenantService;
        }

        /// <summary>
        /// 根據租戶代碼取得租戶資訊
        /// </summary>
        /// <returns></returns>
        [HttpGet("{tenantNumber}")]
        public IActionResult GetByNumber(string tenantNumber) 
        {
            return Ok(ApiResponse<Tenants?>.GetResult( _tenantService.GetByNumber(tenantNumber) ));
        }

        /// <summary>
        /// 新增租戶
        /// </summary>
        /// <param name="insertDTO">要新增的租戶資訊</param>
        /// <returns></returns>
        [HttpPost()]
        public IActionResult Insert(InsertTenantDTO insertDTO) 
        {
            return Ok(ApiResponse<Tenants>.GetResult(_tenantService.Insert(insertDTO)));
        }
    }
}
