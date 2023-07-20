using multiple_tenant_solution.ExternalServices.DTOs;

namespace multiple_tenant_solution.ExternalServices.Tenant
{
    /// <summary>
    /// 租戶的外部Service Interface
    /// </summary>
    public interface ITenantExternalService
    {
        /// <summary>
        /// 根據租戶代碼取得租戶資訊
        /// </summary>
        /// <param name="tenantNumber">租戶代碼</param>
        TenantDTO? GetByNumber(string tenantNumber);
    }
}
