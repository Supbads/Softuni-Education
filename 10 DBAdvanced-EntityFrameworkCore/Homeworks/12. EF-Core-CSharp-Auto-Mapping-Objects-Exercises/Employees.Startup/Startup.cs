using Employees.DataModels;
using Employees.Models;

namespace Employees.Startup
{
    using Employees.Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using AutoMapper;
    using Employees.Services;
    using Employees.Services.Contracts;
    using Microsoft.EntityFrameworkCore.Internal;

    class Startup
    {
        static void Main(string[] args)
        {
            //build serviceProvider
            var serviceProvider = ConfigureServices();

            //initialize DB
            var databaseInitializerService = serviceProvider.GetService<IDatabaseInitializerService>();
            databaseInitializerService.InitializeDatabase();

            var commandParser = new CommandParser(serviceProvider);

            var engine = new Engine(commandParser);
            engine.Run();
        }

        static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<EmployeesContext>(
                options => options.UseSqlServer(ServerConfig.ConnectionString));

            serviceCollection.AddTransient<IEmployeeService, EmployeeService>();
            serviceCollection.AddTransient<IDatabaseInitializerService, DatabaseInitializerService>();

            serviceCollection.AddAutoMapper(cfg =>
                cfg.AddProfile<AutoMapperProfile>());

            return serviceCollection.BuildServiceProvider();
        }

    }
}