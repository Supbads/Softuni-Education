namespace Employees.Data
{
    using Employees.Models;
    using Microsoft.EntityFrameworkCore;
    using Configuration;

    public class EmployeesContext : DbContext
    {
        public EmployeesContext(){}

        public EmployeesContext(DbContextOptions options)
            :base(options){}

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ServerConfig.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
        }
    }
}