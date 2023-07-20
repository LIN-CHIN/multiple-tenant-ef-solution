using multiple_tenant_storage.DAOs;
using multiple_tenant_storage.Entities;

namespace multiple_tenant_storage.Services
{
    /// <summary>
    /// 租戶的 Service
    /// </summary>
    public class TenantService : ITenantService
    {
        private readonly ITenantDAO _tenantDAO;
        public TenantService(ITenantDAO tenantDAO)
        {
            _tenantDAO = tenantDAO;
        }

        ///<inheritdoc/>
        public Tenants? GetByNumber(string tenantNumber)
        {
            return _tenantDAO.GetByNumber(tenantNumber);
        }
    }
}
