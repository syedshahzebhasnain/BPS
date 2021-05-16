using BPSTakeHome.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BPSTakeHome.Infrastructure.Data.Context
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions options) : base(options) { }
        public DbSet<EmployeePosition> EmployeePosition { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
