namespace multiple_tenant_solution
{
    public class TenantServiceConfigs
    {
        /// <summary>
        /// 主機位置
        /// </summary>
        public string Host { get; private set; }

        /// <summary>
        /// 路由前綴
        /// </summary>
        public string Prefix { get; private set; }

        /// <summary>
        /// 根據租戶代碼取得租戶的URL
        /// </summary>
        public string GetTenantByNumberURL { get; private set; }

        /// <summary>
        /// 根據租戶代碼取得租戶資訊的路由
        /// </summary>
        /// <param name="tenantNumber">租戶代碼</param>
        /// <returns></returns>
        public string GetTenantByNumberRoute(string tenantNumber) 
        {
            return $"{Host}{Prefix}{GetTenantByNumberURL}/{tenantNumber}";
        }
    }
    
}    
