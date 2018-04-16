namespace PhotoShare.Client.Core.Commands
{
    using Services.Contracts;
    using Contracts;

    public class DeleteUserCommand : ICommand
    {
        // DeleteUserCommand <username>

        private readonly IUserService userService;
        
        public DeleteUserCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(params string[] data)
        {
            string username = data[0];

            userService.Delete(username);

            return $"User {username} was deleted from the database!";
        }
    }
}