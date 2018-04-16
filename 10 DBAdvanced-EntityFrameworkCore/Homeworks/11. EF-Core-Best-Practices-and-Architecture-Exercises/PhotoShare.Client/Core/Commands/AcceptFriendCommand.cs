namespace PhotoShare.Client.Core.Commands
{
    using Contracts;
    using Services.Contracts;

    public class AcceptFriendCommand : ICommand
    {
        // AcceptFriend <username1> <username2>

        private readonly IFriendsService friendsService;
        
        public AcceptFriendCommand(IFriendsService friendsService)
        {
            this.friendsService = friendsService;
        }
        
        public string Execute(params string[] data)
        {
            var acceptingUser = data[0];
            var acceptedUser = data[1];

            friendsService.AcceptFriend(acceptingUser, acceptedUser);

            return $"{acceptingUser} accepted {acceptedUser} as a friend";
        }
    }
}