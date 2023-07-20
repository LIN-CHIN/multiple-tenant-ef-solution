namespace multiple_tenant_solution
{
    public class ApiSettings
    {
        public bool isRoot { get; set; } = true;

        /// <summary>
        /// PostgreSQL連線字串
        /// </summary>
        public string RootConnectionString { get; private set; } = "";

        /// <summary>
		/// PostgreSQL連線字串
		/// </summary>
		public string ConnectionString { get; private set; } = "";

    }
}
