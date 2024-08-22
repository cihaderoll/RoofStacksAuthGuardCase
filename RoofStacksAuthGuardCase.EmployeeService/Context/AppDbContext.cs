using Microsoft.EntityFrameworkCore;
using RoofStacksAuthGuardCase.EmployeeService.Model;

namespace RoofStacksAuthGuardCase.EmployeeService.Context
{
    public class AppDbContext : DbContext
    {
        //for testing
        public AppDbContext()
        {
            
        }

        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
        {
            
        }

        public virtual DbSet<Employee> Employees { get; set; }
    }
}
