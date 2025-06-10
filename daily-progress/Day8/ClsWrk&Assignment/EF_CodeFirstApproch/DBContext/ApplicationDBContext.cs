using EF_CodeFirstApproch.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_CodeFirstApproch.DBContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}

