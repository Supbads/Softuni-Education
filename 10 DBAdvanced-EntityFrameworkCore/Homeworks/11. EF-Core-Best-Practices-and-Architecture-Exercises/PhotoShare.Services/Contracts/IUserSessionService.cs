namespace PhotoShare.Services.Contracts
{
    using Models;
    public interface IUserSessionService
    {
        User User { get; }

        User Login(string username, string password);

        User Logout();

        bool IsLoggedIn();

        bool ValidateUser(User user);
    }
}