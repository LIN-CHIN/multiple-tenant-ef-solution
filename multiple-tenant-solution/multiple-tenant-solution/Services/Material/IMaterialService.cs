using multiple_tenant_solution.DTOs.Material;
using multiple_tenant_solution.Entities;

namespace multiple_tenant_solution.Services.Material
{
    /// <summary>
    /// 物料 Service Interface
    /// </summary>
    public interface IMaterialService
    {
        /// <summary>
        /// 取得物料清單
        /// </summary>
        /// <returns></returns>
        IQueryable<Materials> Get();

        /// <summary>
        /// 新增物料
        /// </summary>
        /// <param name="insertDTO">要新增的物料資訊</param>
        /// <returns></returns>
        Materials Insert(InsertMaterialDTO insertDTO);

        /// <summary>
        /// 更新物料
        /// </summary>
        /// <param name="id">要更新的物料ID</param>
        /// <param name="updateDTO">要更新的物料資訊</param>
        /// <returns></returns>
        void Update(long id, UpdateMaterialDTO updateDTO);

        /// <summary>
        /// 刪除物料
        /// </summary>
        /// <param name="id">要刪除的物料ID</param>
        /// <returns></returns>
        void Delete(long id);
    }
}
