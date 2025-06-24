using Microsoft.EntityFrameworkCore;
using AssetManagementSystem.Models;

namespace AssetManagementSystem.Context
{
    public class AssetDbContext : DbContext
    {
        public AssetDbContext(DbContextOptions<AssetDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetCategory> AssetCategories { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<AuditRequest> AuditRequests { get; set; }

    }
}
