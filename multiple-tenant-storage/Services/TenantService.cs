using multiple_tenant_storage.DAOs;
using multiple_tenant_storage.DTOs;
using multiple_tenant_storage.Entities;
using System.Data;

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

        ///<inheritdoc/>
        public Tenants Insert(InsertTenantDTO insertDTO)
        {
            if (_tenantDAO.GetByNumber(insertDTO.Number) != null) 
            {
                throw new ArgumentException("租戶代碼已存在");
            }

            return _tenantDAO.Insert(insertDTO.ToTenants());
        }
    }
}
