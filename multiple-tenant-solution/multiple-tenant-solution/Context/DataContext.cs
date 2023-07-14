using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.VisualBasic;
using multiple_tenant_solution.Entities;
using System.Security.Principal;
using System.Xml.Linq;

namespace multiple_tenant_solution.Context
{
    public class DataContext : DbContext
    {
        private readonly ApiSettings _apiSettings;
        DbSet<Users> Users => Set<Users>();
        DbSet<Tenants> Tenants => Set<Tenants>();
        DbSet<Materials> Materials => Set<Materials>();

        public DataContext(DbContextOptions<DataContext> options, ApiSettings apiSettings) : base(options)
        {
            _apiSettings = apiSettings;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("app_main_schema");

            //建立unique
            modelBuilder.Entity<Users>()
                .HasIndex(c => new { c.Account, c.TenantNumber })
                .IsUnique();

            modelBuilder.Entity<Tenants>()
                .HasIndex(c => new { c.Number })
                .IsUnique();

            modelBuilder.Entity<Materials>()
                .HasIndex(c => new { c.Number, c.TenantNumber })
                .IsUnique();

            //設定預設值
            modelBuilder.Entity<Tenants>()
                .Property(t => t.IsEnable)
                .HasDefaultValue(true);

            modelBuilder.Entity<Tenants>().HasData(AddTenantsSeed());
            modelBuilder.Entity<Users>().HasData(AddUserSeed());

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_apiSettings.ConnectionString);
        }

        private IEnumerable<Tenants> AddTenantsSeed()
        {
            return new List<Tenants>
            {
                new Tenants
                {
                    Id = 1,
                    Number = "Admin",
                    Name = "管理員",
                    ConnectionUserId = "Admin",
                    ConnectionPwd = "Admin",
                    CreateDate = DateTime.UtcNow,
                    CreateUser = "admin",
                },
                new Tenants
                {
                    Id = 2,
                    Number = "CompanyA",
                    Name = "A公司",
                    ConnectionUserId = "CompanyA",
                    ConnectionPwd = "CompanyA",
                    CreateDate = DateTime.UtcNow,
                    CreateUser = "admin",
                },
                new Tenants
                {
                    Id = 3,
                    Number = "CompanyB",
                    Name = "B公司",
                    ConnectionUserId = "CompanyB",
                    ConnectionPwd = "CompanyB",
                    CreateDate = DateTime.UtcNow,
                    CreateUser = "admin",
                }
           };
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
                    TenantNumber = "Admin",
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
