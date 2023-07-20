using Microsoft.EntityFrameworkCore;
using multiple_tenant_storage.Entities;

namespace multiple_tenant_storage.Context
{
    public class TenantContext : DbContext
    {
        public DbSet<Tenants> Tenants => Set<Tenants>();

        public TenantContext(DbContextOptions<TenantContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("app_main_schema");

            //建立unique
            modelBuilder.Entity<Tenants>()
                .HasIndex(c => new { c.Number })
                .IsUnique();

            //設定預設值
            modelBuilder.Entity<Tenants>()
                .Property(t => t.IsEnable)
                .HasDefaultValue(true);

            modelBuilder.Entity<Tenants>().HasData(AddTenantsSeed());
        }

        private IEnumerable<Tenants> AddTenantsSeed()
        {
            return new List<Tenants>
            {
                new Tenants
                {
                    Id = 1,
                    Number = "admin",
                    Name = "管理員",
                    ConnectionUserId = "admin",
                    ConnectionPwd = "admin",
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

    }
}
