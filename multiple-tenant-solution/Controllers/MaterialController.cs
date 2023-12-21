using Microsoft.AspNetCore.Mvc;
using multiple_tenant_solution.DTOs.Material;
using multiple_tenant_solution.Entities;
using multiple_tenant_solution.Responses;
using multiple_tenant_solution.Services.Material;

namespace multiple_tenant_solution.Controllers
{
    /// <summary>
    /// 物料Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(TenantFilterAttribute))]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        /// <summary>
        /// 查詢物料清單
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ApiResponse<IQueryable<Materials>>
                        .GetResult(_materialService.Get()));
        }

        /// <summary>
        /// 新增物料
        /// </summary>
        /// <param name="insertDTO">要新增的物料 DTO</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertMaterial(InsertMaterialDTO insertDTO)
        {
            return Ok(ApiResponse<Materials>
                .GetResult(_materialService.Insert(insertDTO)));
        }

        /// <summary>
        /// 更新物料
        /// </summary>
        /// <param name="id">要更新的物料id</param>
        /// <param name="updateDTO">要更新的物料 DTO</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateMaterial(long id, UpdateMaterialDTO updateDTO)
        {
            _materialService.Update(id, updateDTO);
            return Ok(ApiResponse<string>.GetResult(""));
        }

        /// <summary>
        /// 刪除物料
        /// </summary>
        /// <param name="id">要刪除的id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteMaterial(long id)
        {
            _materialService.Delete(id);
            return Ok(ApiResponse<string>.GetResult(""));
        }
    }
}
