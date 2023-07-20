﻿using multiple_tenant_storage.Entities;

namespace multiple_tenant_storage.DAOs
{
    /// <summary>
    /// 租戶的 DAO Interface
    /// </summary>
    public interface ITenantDAO
    {
        /// <summary>
        /// 根據租戶代碼取得租戶
        /// </summary>
        /// <param name="tenantNumber">租戶代碼</param>
        /// <returns></returns>
        Tenants? GetByNumber(string tenantNumber);
    }
}
