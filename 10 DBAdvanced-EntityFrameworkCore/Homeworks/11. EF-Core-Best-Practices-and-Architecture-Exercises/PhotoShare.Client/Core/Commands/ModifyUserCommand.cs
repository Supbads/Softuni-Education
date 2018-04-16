namespace PhotoShare.Client.Core.Commands
{
    using System.Text.RegularExpressions;
    using Services.Contracts;
    using Contracts;
    using System;

    public class ModifyUserCommand : ICommand
    {
        // ModifyUser <username> <property> <new value>
        // For example:
        // ModifyUser <username> Password <NewPassword>
        // ModifyUser <username> BornTown <newBornTownName>
        // ModifyUser <username> CurrentTown <newCurrentTownName>
        // !!! Cannot change username

        private readonly IUserService userService;
        private readonly ITownService townService;
        private readonly IUserSessionService sessionService;

        public ModifyUserCommand(IUserService userService, ITownService townService, IUserSessionService sessionService)
        {
            this.userService = userService;
            this.townService = townService;
            this.sessionService = sessionService;
        }

        public string Execute(params string[] data)
        {
            if (!this.sessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("You need to log in to Modify your details");
            }

            var userName = data[0];
            var propertyName = data[1];
            var newValue = data[2];

            var user = userService.ByUsername(userName);

            if (user == null)
            {
                throw new ArgumentException("User " + userName + " not found!");
            }
            
            if (this.sessionService.User != user)
            {
                throw new InvalidOperationException("Cannot modify another user's details");
            }

            switch (propertyName)
            {
                case "Username":
                    throw new ArgumentException("Cannot change the Username");

                case "Password":
                    if (!Regex.IsMatch(newValue, "[0-9a-z]+"))
                    {
                        throw new ArgumentException("Invalid Password!");
                    }

                    userService.ModifyPassword(userName, newValue);
                    break;
                case "BornTown":
                    var bornTown = townService.ByName(newValue);
                    if (bornTown == null)
                    {
                        throw new ArgumentException($"Town {newValue} not found!");
                    }

                    userService.ModifyBornTown(userName, bornTown);
                    break;
                case "CurrentTown":
                    var currentTown = townService.ByName(newValue);
                    if (currentTown == null)
                    {
                        throw new ArgumentException($"Town {newValue} not found!");
                    }

                    userService.ModifyCurrentTown(userName, currentTown);
                    break;
                default:
                    throw new ArgumentException($"Property {propertyName} not supported!");
            }
            
            return $"User {userName} {propertyName} is {newValue}.";
        }
    }
}