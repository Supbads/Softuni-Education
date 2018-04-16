namespace PhotoShare.Services
{
    using System;
    using System.Linq;
    using Data;
    using Models;
    using Contracts;

    public class TownService : ITownService
    {
        private readonly PhotoShareContext context;
        private readonly IUserSessionService sessionService;

        public TownService(PhotoShareContext context, IUserSessionService sessionService)
        {
            this.context = context;
            this.sessionService = sessionService;
        }

        public Town Create(string townName, string countryName)
        {
            if (!sessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("You have to log in to create a Town");
            }

            var town = new Town()
            {
                Name = townName,
                Country = countryName
            };

            this.context.Towns.Add(town);

            context.SaveChanges();

            return town;
        }

        public Town ByName(string townName)
        {
            var town = context.Towns.SingleOrDefault(t => t.Name == townName);

            return town;
        }

        public Town ById(int id)
        {
            var town = context.Towns.SingleOrDefault(t => t.Id == id);

            return town;
        }

        public void Delete(string name)
        {
            var town = context.Towns.SingleOrDefault(t => t.Name == name);

            context.Towns.Remove(town);

            context.SaveChanges();
        }
    }
}