namespace PhotoShare.Client.Core.Commands
{
    using Contracts;
    using Services.Contracts;

    public class LoginCommand : ICommand
    {
        private readonly IUserSessionService sessionService;

        public LoginCommand(IUserSessionService sessionService)
        {
            this.sessionService = sessionService;
        }

        public string Execute(params string[] data)
        {
            var username = data[0];
            var password = data[1];

            sessionService.Login(username, password);
            
            return $"User {username} successfully logged in!";

        }
    }
}