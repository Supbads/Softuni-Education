namespace PhotoShare.Services
{
    using System;
    using Models;
    using Contracts;

    public class UserSessionService : IUserSessionService
    {
        private readonly IUserService userService;

        public UserSessionService(IUserService userService)
        {
            this.userService = userService;
        }

        public User User { get; private set; }
        public User Login(string username, string password)
        {
            if (this.IsLoggedIn())
            {
                throw new InvalidOperationException("You should logout first!");
            }

            var user = this.userService.ByUsernameAndPassword(username, password);

            if (user == null)
            {
                throw new ArgumentException("Invalid username or password!");
            }

            this.User = user;

            return user;
        }

        public User Logout()
        {
            if (!this.IsLoggedIn())
            {
                throw new InvalidOperationException("Only logged in users can logout");
            }

            var user = this.User;

            this.User = null;

            return user;
        }

        public bool IsLoggedIn()
        {
            return this.User != null;
        }

        public bool ValidateUser(User user)
        {
            if (user != this.User)
            {
                return false;
            }

            return true;
        }
    }
}