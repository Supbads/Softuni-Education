namespace Employees.Startup
{
    using System;
    using System.Linq;

    public class Engine
    {
        private readonly CommandParser commandParser;

        public Engine(CommandParser commandParser)
        {
            this.commandParser = commandParser;
        }

        public void Run()
        {
            
            while (true)
            {
                //try
                //{
                    var input = Console.ReadLine();

                    var inputArgs = input.Split();

                    var commandName = inputArgs.FirstOrDefault();

                    var parameters = inputArgs.Skip(1).ToArray();

                    var command = commandParser.ParseCommand(commandName);

                    var output = command.Execute(parameters);

                    Console.WriteLine(output);
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine(e.Message);
                   
                //}

            }

        }

    }
}