namespace PhotoShare.Client.Core.Commands
{
    using Contracts;
    using System;
    using Models;
    using Services.Contracts;

    public class RegisterUserCommand : ICommand
    {
        // RegisterUser <username> <password> <repeat-password> <email>

        private readonly IUserService userService;
        
        public RegisterUserCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(params string[] data)
        {
            string username = data[0];
            string password = data[1];
            string repeatPassword = data[2];
            string email = data[3];

            if (password != repeatPassword)
            {
                throw new ArgumentException("Passwords do not match!");
            }

            if (userService.ByUsername(username) != null)
            {
                throw new InvalidOperationException("Username " + username + " is already taken!");
            }

            User user = new User
            {
                Username = username,
                Password = password,
                Email = email,
                IsDeleted = false,
                RegisteredOn = DateTime.Now,
                LastTimeLoggedIn = DateTime.Now
            };

            this.userService.Create(user);

            return "User " + user.Username + " was registered successfully!";
        }
    }
}