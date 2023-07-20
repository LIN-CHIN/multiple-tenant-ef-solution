using multiple_tenant_solution.DTOs;
using multiple_tenant_solution.Entities;

namespace multiple_tenant_solution.DAOs.Material
{
    /// <summary>
    /// 物料 DAO Interface
    /// </summary>
    public interface IMaterialDAO
    {
        /// <summary>
        /// 取得物料清單
        /// </summary>
        /// <returns></returns>
        IQueryable<Materials> Get();

        /// <summary>
        /// 根據id取得物料
        /// </summary>
        /// <param name="id">物料id</param>
        /// <returns></returns>
        Materials? GetById(long id);

        /// <summary>
        /// 根據物料代碼取得物料
        /// </summary>
        /// <param name="number>物料代碼</param>
        /// <returns></returns>
        Materials? GetByNumber(string number);

        /// <summary>
        /// 新增物料
        /// </summary>
        /// <param name="material">要新增的物料實體</param>
        /// <returns></returns>
        Materials Insert(Materials material);

        /// <summary>
        /// 更新物料
        /// </summary>
        /// <param name="material">要更新的物料實體</param>
        /// <returns></returns>
        void Update(Materials material);

    }
}
