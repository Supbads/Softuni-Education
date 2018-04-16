namespace PhotoShare.Services.Contracts
{
    using Models;

    public interface IUserService
    {
        User ById(int id);

        User ByUsername(string username);

        User ByUsernameAndPassword(string username, string password);

        User Create(string username, string password);

        User Create(User user);

        void Delete(int id);

        void Delete(string userName);

        void ModifyBornTown(string userName, Town town);

        void ModifyCurrentTown(string userName, Town town);

        void ModifyPassword(string userName, string newPassword);
    }
}