using multiple_tenant_solution.ExternalServices.DTOs;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace multiple_tenant_solution.ExternalServices.Tenant
{
    public class TenantExternalService : ITenantExternalService
    {
        private readonly HttpClient _httpClient;
        private readonly TenantServiceConfigs _tenantServiceConfigs;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="tenantServiceConfigs"></param>
        public TenantExternalService(
            HttpClient httpClient,
            TenantServiceConfigs tenantServiceConfigs) 
        {
            _httpClient = httpClient;
            _tenantServiceConfigs = tenantServiceConfigs;
        }

        ///<inheritdoc/>
        public TenantDTO? GetByNumber(string tenantNumber)
        {
            // 建立請求
            var requestMsg = new HttpRequestMessage(
                HttpMethod.Get,
                _tenantServiceConfigs.GetTenantByNumberRoute(tenantNumber));

            // 發送請求
            var response = _httpClient.SendAsync(requestMsg).GetAwaiter().GetResult();

            string result = response.Content.ReadAsStringAsync().Result.ToString();

            TenantDTO? tenantDTO = new TenantDTO();

            // 成功
            if (response.StatusCode.ToString() == "OK")
            {
                JObject obj = JObject.Parse(result);
                JToken token = obj["code"];
                int code = token.ToObject<int>();

                if (code == 0)
                {
                    JToken data = obj["content"];
                    tenantDTO = JsonConvert.DeserializeObject<TenantDTO>(data.ToString());
                }
                else
                {
                    throw new Exception( $" 呼叫租戶API 'GetByNumber()' 失敗:  錯誤代碼為: {code}" );
                }
            }
            else
            {
                throw new Exception($" 呼叫租戶API 'GetByNumber()' 嚴重失敗");
            }

            return tenantDTO;
        }
    }
}
