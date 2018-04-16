namespace Employees.Services
{
    using Employees.Data;
    using Contracts;
    using Microsoft.EntityFrameworkCore;

    public class DatabaseInitializerService : IDatabaseInitializerService
    {
        private readonly EmployeesContext context;

        public DatabaseInitializerService(EmployeesContext context)
        {
            this.context = context;
        }

        public void InitializeDatabase()
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            //context.Database.Migrate();
        }
    }
}