using AssetManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<AssetCategory> AssetCategories { get; set; } = null!;
        public DbSet<Asset> Assets { get; set; } = null!;
        public DbSet<AssetAssignment> AssetAssignments { get; set; } = null!;
        public DbSet<ServiceRequest> ServiceRequests { get; set; } = null!;
        public DbSet<AssetAudit> AssetAudits { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Asset>()
                .Property(a => a.AssetValue)
                .HasPrecision(18, 2);
        }
    }
}
