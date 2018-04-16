namespace PhotoShare.Services
{
    using System;
    using System.Linq;
    using Data;
    using System.Collections.Generic;
    using Models;
    using Contracts;

    public class FriendsService : IFriendsService
    {
        private readonly PhotoShareContext context;
        private readonly IUserService userService;
        private readonly IUserSessionService sessionService;

        public FriendsService(PhotoShareContext context, IUserService userService, IUserSessionService sessionService)
        {
            this.context = context;
            this.userService = userService;
            this.sessionService = sessionService;
        }

        public void AddFriend(string username1, string username2)
        {
            if (!sessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("You must log in first to add a friend");
            }

            var requestingUser = userService.ByUsername(username1);

            if (requestingUser == null)
            {
                throw new ArgumentException($"{username1} not found!");
            }

            if (!this.sessionService.ValidateUser(requestingUser))
            {
                throw new InvalidOperationException("You can only add friends to yourself");
            }

            var addedUser = userService.ByUsername(username2);

            if (addedUser == null)
            {
                throw new ArgumentException($"{username2} not found!");
            }

            if (requestingUser.FriendsAdded.Any(f => f.Friend.Username == username2))
            {
                throw new InvalidOperationException($"{username2} is already a friend to {username1}");
            }

            var friendShip = new Friendship
            {
                User = requestingUser,
                Friend = addedUser
            };
            
            requestingUser.FriendsAdded.Add(friendShip);
            addedUser.AddedAsFriendBy.Add(friendShip);

            context.SaveChanges();
        }

        public void AcceptFriend(string username1, string username2)
        {
            if (!sessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("You must log in first to accept a friend");
            }
            
            var AcceptingUser = userService.ByUsername(username1);

            if (AcceptingUser == null)
            {
                throw new ArgumentException($"{username1} not found!");
            }

            if (!this.sessionService.ValidateUser(AcceptingUser))
            {
                throw new InvalidOperationException("You can only accept friends to yourself");
            }

            var AddedByUser = userService.ByUsername(username2);

            if (AddedByUser == null)
            {
                throw new ArgumentException($"{username2} not found!");
            }

            if (AcceptingUser.FriendsAdded.Any(f => f.Friend.Username == username2))
            {
                throw new InvalidOperationException($"{username2} is already a friend to {username1}");
            }

            var friendship =
                AcceptingUser.AddedAsFriendBy.SingleOrDefault(
                    fs => fs.Friend.Username == username1 
                    && fs.User.Username == username2);

            if (friendship == null)
            {
                throw new InvalidOperationException($"{username2} has not added {username1} as a friend");
            }

            AcceptingUser.FriendsAdded.Add(friendship);
        }

        public ICollection<string> ListFriends(string username)
        {
            if (!sessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("You must log in first to List friends of a user");
            }

            var user = userService.ByUsername(username);

            var friends = user.FriendsAdded.Select(f => f.Friend.Username).ToList();

            return friends;
        }
    }
}