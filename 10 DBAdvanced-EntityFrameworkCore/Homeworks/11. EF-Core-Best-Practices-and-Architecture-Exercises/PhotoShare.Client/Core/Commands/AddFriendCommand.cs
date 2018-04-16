namespace PhotoShare.Client.Core.Commands
{
    using Services.Contracts;
    using Contracts;

    public class AddFriendCommand : ICommand
    {
        // AddFriend <username1> <username2>
        
        private readonly IFriendsService friendsService;

        public AddFriendCommand(IFriendsService friendsService)
        {
            this.friendsService = friendsService;
        }
        
        public string Execute(params string[] data)
        {
            var requestingUser = data[0];
            var addedUser = data[1];
            
            friendsService.AddFriend(requestingUser, addedUser);

            return $"{requestingUser} added {addedUser} as a friend";
        }
    }
}