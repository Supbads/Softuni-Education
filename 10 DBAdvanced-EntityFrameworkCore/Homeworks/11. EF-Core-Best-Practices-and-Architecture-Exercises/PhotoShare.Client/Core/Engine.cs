namespace PhotoShare.Client.Core
{
    using System.Linq;
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using Services.Contracts;

    public class Engine
    {
        private readonly IServiceProvider serviceProvider;
        private readonly CommandDispatcher commandDispatcher;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            commandDispatcher = new CommandDispatcher(serviceProvider);
        }

        public void Run()
        {
            var databaseInitializerService = serviceProvider.GetService<IDatabaseInitializerService>();

            databaseInitializerService.InitializeDatabase();

            while (true)
            {
                try
                {
                    string input = Console.ReadLine().Trim();
                    string[] data = input.Split(' ');

                    var commandName = data[0];
                    var commandParameters = data.Skip(1).ToArray();

                    var command = this.commandDispatcher.DispatchCommand(commandName);

                    var result = command.Execute(commandParameters);

                    Console.WriteLine(result);
                    // could implement a Logging service with File/Console loggers
                }
                catch (Exception e)
                {

                    throw e;
                }
            }
        }
    }
}