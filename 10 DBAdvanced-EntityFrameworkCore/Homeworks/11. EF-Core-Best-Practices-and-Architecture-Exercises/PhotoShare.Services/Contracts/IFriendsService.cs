namespace PhotoShare.Services.Contracts
{
    using System.Collections.Generic;
    using Models;

    public interface IFriendsService
    {
        void AddFriend(string username1, string username2);

        void AcceptFriend(string username1, string username2);

        ICollection<string> ListFriends(string username);
    }
}