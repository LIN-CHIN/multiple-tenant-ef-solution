using Microsoft.EntityFrameworkCore;
using multiple_tenant_solution.Entities;

namespace multiple_tenant_solution.Context
{
    public class DataContext : DbContext
    {
        DbSet<Users> Users => Set<Users>();

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasIndex(c => new { c.Account })
                .IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 

        }
    }
}
