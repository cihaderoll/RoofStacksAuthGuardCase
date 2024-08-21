using Microsoft.EntityFrameworkCore;
using RoofStacksAuthGuardCase.EmployeeService.Model;

namespace RoofStacksAuthGuardCase.EmployeeService.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
