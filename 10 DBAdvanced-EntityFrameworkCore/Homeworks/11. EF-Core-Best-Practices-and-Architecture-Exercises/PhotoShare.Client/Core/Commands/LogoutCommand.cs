namespace PhotoShare.Client.Core.Commands
{
    using Services.Contracts;
    using Contracts;

    public class LogoutCommand : ICommand
    {
        private readonly IUserSessionService sessionService;

        public LogoutCommand(IUserSessionService sessionService)
        {
            this.sessionService = sessionService;
        }

        public string Execute(params string[] data)
        {
            var username = sessionService.Logout().Username;

            return $"User {username} successfully logged out!";
        }
    }
}