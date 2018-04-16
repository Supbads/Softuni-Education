namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;
    using Contracts;
    using Models;
    using Data;
    using Utilities;
    using Services.Contracts;

    public class AddTagCommand : ICommand
    {
        // AddTag <tag>

        private readonly IUserSessionService sessionService;
        
        public AddTagCommand(IUserSessionService sessionService)
        {
            this.sessionService = sessionService;
        }

        public string Execute(params string[] data)
        {
            if (!sessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("You must log in to add a tag");
            }

            string tagName = data[0].ValidateOrTransform();

            using (PhotoShareContext context = new PhotoShareContext())
            {
                if (context.Tags.Any(t => t.Name == tagName))
                {
                    throw new ArgumentException($"Tag {tagName} exists!");
                }

                context.Tags.Add(new Tag
                {
                    Name = tagName
                });

                context.SaveChanges();
            }

            return tagName + " was added successfully to database!";
        }
    }
}