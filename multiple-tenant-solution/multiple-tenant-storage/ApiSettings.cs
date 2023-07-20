namespace multiple_tenant_storage
{
    public class ApiSettings
    {
        /// <summary>
		/// PostgreSQL連線字串
		/// </summary>
		public string ConnectionString { get; private set; } = "";
    }
}
