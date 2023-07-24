using Microsoft.EntityFrameworkCore;
using multiple_tenant_storage.Context;
using multiple_tenant_storage.Entities;

namespace multiple_tenant_storage.DAOs
{
    /// <summary>
    /// 租戶的 DAO Service
    /// </summary>
    public class TenantDAO : ITenantDAO
    {
        private readonly TenantContext _tenantContext;

        public TenantDAO(TenantContext tenantContext)
        {
            _tenantContext = tenantContext;
        }

        ///<inheritdoc/>
        public Tenants? GetByNumber(string tenantNumber)
        {
            return _tenantContext.Tenants
                .Where(t => t.Number == tenantNumber)
                .SingleOrDefault();
        }

        ///<inheritdoc/>
        public Tenants Insert(Tenants tenant)
        {
            _tenantContext.Tenants.Add(tenant);
            _tenantContext.SaveChanges();
            return tenant;
        }
    }
}
