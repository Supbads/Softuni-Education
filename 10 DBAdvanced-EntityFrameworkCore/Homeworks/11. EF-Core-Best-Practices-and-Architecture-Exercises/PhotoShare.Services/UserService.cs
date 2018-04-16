namespace PhotoShare.Services
{
    using System;
    using System.Linq;
    using Data;
    using Models;
    using Contracts;

    public class UserService : IUserService
    {
        private readonly PhotoShareContext context;
        private readonly IUserSessionService sessionService;

        public UserService(PhotoShareContext context, IUserSessionService sessionService)
        {
            this.context = context;
            this.sessionService = sessionService;
        }

        public User ById(int id)
        {
            var user = this.context.Users.SingleOrDefault(u => u.Id == id);

            return user;
        }

        public User ByUsername(string username)
        {
            var user = this.context.Users.SingleOrDefault(u => u.Username == username);

            return user;
        }

        public User ByUsernameAndPassword(string username, string password)
        {
            var user = this.context.Users
                .SingleOrDefault(u => u.Username == username && u.Password == password);

            return user;
        }

        public User Create(string username, string password)
        {
            if (this.sessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("You have to log out to Create a new User");
            }

            var user = new User()
            {
                Username = username,
                Password = password
            };

            context.Users.Add(user);
            context.SaveChanges();

            return user;
        }

        public User Create(User user)
        {
            if (this.sessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("You have to log out to Create a new User");
            }

            this.context.Users.Add(user);
            context.SaveChanges();

            return user;
        }

        public void Delete(int id)
        {
            if (this.sessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("You have to log in to Delete an account");
            }

            var user = context.Users.Find(id);

            if (user == null)
            {
                throw new ArgumentException("User with id:" + id + " not found!");
            }

            if (!this.sessionService.ValidateUser(user))
            {
                throw new InvalidOperationException("A User can only delete their own account");
            }

            if (user.IsDeleted.HasValue)
            {
                if (user.IsDeleted.Value)
                {
                    throw new InvalidOperationException("User with id:" + id + " is already deleted!");
                }
            }

            user.IsDeleted = true;

            context.SaveChanges();
        }

        public void Delete(string username)
        {
            if (this.sessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("You have to log out to Create a new User");
            }

            var user = context.Users.SingleOrDefault(u => u.Username == username);

            if (user == null)
            {
                throw new ArgumentException("User " + username + " not found!");
            }

            if (!this.sessionService.ValidateUser(user))
            {
                throw new InvalidOperationException("A User can only delete their own account");
            }

            if (user.IsDeleted.HasValue)
            {
                if (user.IsDeleted.Value)
                {
                    throw new InvalidOperationException("User " + username + " is already deleted!");
                }
            }

            user.IsDeleted = true;

            context.SaveChanges();
        }

        public void ModifyBornTown(string userName, Town town)
        {
            var user = context.Users.SingleOrDefault(u => u.Username == userName);

            user.BornTown = town;

            context.SaveChanges();
        }

        public void ModifyCurrentTown(string userName, Town town)
        {
            var user = context.Users.SingleOrDefault(u => u.Username == userName);

            user.CurrentTown = town;

            context.SaveChanges();
        }

        public void ModifyPassword(string userName, string newPassword)
        {
            var user = context.Users.SingleOrDefault(u => u.Username == userName);

            user.Password = newPassword;

            context.SaveChanges();
        }
    }
}