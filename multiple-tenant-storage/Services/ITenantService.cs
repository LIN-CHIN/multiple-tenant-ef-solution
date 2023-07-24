using multiple_tenant_storage.DTOs;
using multiple_tenant_storage.Entities;

namespace multiple_tenant_storage.Services
{
    /// <summary>
    /// 租戶的 Service Interface
    /// </summary>
    public interface ITenantService
    {
        /// <summary>
        /// 根據租戶代碼取得租戶
        /// </summary>
        /// <param name="tenantNumber">租戶代碼</param>
        /// <returns></returns>
        Tenants? GetByNumber(string tenantNumber);

        /// <summary>
        /// 新增租戶
        /// </summary>
        /// <param name="insertDTO">要新增的租戶資訊</param>
        /// <returns></returns>
        Tenants Insert(InsertTenantDTO insertDTO);
    }
}
