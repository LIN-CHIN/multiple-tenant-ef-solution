using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using multiple_tenant_solution.Entities;

namespace multiple_tenant_solution.Context
{
    public class DataContext : DbContext
    {
        private readonly ApiSettings _apiSettings;
        private readonly CurrentUserInfo _currentUserInfo;

        public DbSet<Users> Users => Set<Users>();
        public DbSet<Materials> Materials => Set<Materials>();

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DataContext(
            DbContextOptions<DataContext> options,
            ApiSettings apiSettings,
            CurrentUserInfo currentUserInfo) : base(options)
        {
            _apiSettings = apiSettings;
            _currentUserInfo = currentUserInfo;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("app_main_schema");

            //建立unique
            modelBuilder.Entity<Users>()
                .HasIndex(c => new { c.Account, c.TenantNumber })
                .IsUnique();

            modelBuilder.Entity<Materials>()
                .HasIndex(c => new { c.Number, c.TenantNumber })
                .IsUnique();

            modelBuilder.Entity<Users>().HasData(AddUserSeed());

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "";

            if (_apiSettings.isRoot)
            {
                connectionString = _apiSettings.RootConnectionString;
                _apiSettings.isRoot = false;
            }
            else 
            {
                connectionString = string.Format(
                    _apiSettings.ConnectionString,
                    _currentUserInfo.ConnectionUserId,
                    _currentUserInfo.ConnectionPwd);

                if (string.IsNullOrWhiteSpace(_currentUserInfo.ConnectionUserId) ||
                   string.IsNullOrWhiteSpace(_currentUserInfo.ConnectionPwd)) 
                {
                    throw new Exception("連線資訊錯誤 系統異常");
                }

            }

            optionsBuilder.UseNpgsql(connectionString, dbContext =>
                dbContext.MigrationsHistoryTable(
                    HistoryRepository.DefaultTableName,
                    "app_main_schema"));
        }

        private IEnumerable<Users> AddUserSeed() 
        {
            return new List<Users>
            {
                new Users
                {
                    Id = 1,
                    Account = "admin",
                    Pwd = "admin",
                    Name = "系統管理員",
                    TenantNumber = "admin",
                    CreateDate = DateTime.UtcNow,
                    CreateUser = "admin",
                },
                new Users
                {
                    Id = 2,
                    Account = "A-user",
                    Pwd = "A-user",
                    Name = "A的一般使用者",
                    TenantNumber = "CompanyA",
                    CreateDate = DateTime.UtcNow,
                    CreateUser = "admin",
                },
                new Users
                {
                    Id = 3,
                    Account = "B-user",
                    Pwd = "B-user",
                    Name = "B的一般使用者",
                    TenantNumber = "CompanyB",
                    CreateDate = DateTime.UtcNow,
                    CreateUser = "admin",
                }
           };
        }
    }
}
