namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Services.Contracts;
    using Contracts;

    public class AddTownCommand : ICommand
    {
        // AddTown <townName> <countryName>

        private readonly ITownService townService;

        public AddTownCommand(ITownService townService)
        {
            this.townService = townService;
        }
        
        public string Execute(params string[] data)
        {
            string townName = data[0];
            string countryName = data[1];

            if (townService.ByName(townName) != null)
            {
                throw new ArgumentException("Town " + townName + " was already added!");
            }

            townService.Create(townName, countryName);

            return townName + " was added to database!";
        }
    }
}