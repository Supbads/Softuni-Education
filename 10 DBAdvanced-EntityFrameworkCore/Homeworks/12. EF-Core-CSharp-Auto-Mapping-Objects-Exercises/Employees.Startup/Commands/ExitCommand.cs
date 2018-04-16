namespace Employees.Startup.Commands
{
    using System;
    using Contracts;

    class ExitCommand : ICommand
    {
        public string Execute(params string[] parameters)
        {
            Console.WriteLine("Bye bye");

            Environment.Exit(0);

            return "";
        }
    }
}