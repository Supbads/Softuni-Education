namespace PhotoShare.Client.Core.Commands
{
    using Contracts;
    using System;

    public class PrintFriendsListCommand : ICommand
    {
        // PrintFriendsList <username>
        public string Execute(params string[] data)
        {
            // TODO prints all friends of user with given username.
            throw new NotImplementedException();
        }
    }
}
