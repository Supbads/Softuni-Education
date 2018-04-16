namespace PhotoShare.Client
{
    using Core;
    using Data;
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using PhotoShare.Services;
    using PhotoShare.Services.Contracts;

    public class Application
    {
        public static void Main()
        {
            //ResetDatabase();

            var serviceProvider = ConfigureServices();

            Engine engine = new Engine(serviceProvider);
            engine.Run();
        }

        private static void ResetDatabase()
        {
            using (var db = new PhotoShareContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        }

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();


            serviceCollection.AddDbContext<PhotoShareContext>();

            serviceCollection.AddTransient<IDatabaseInitializerService, DatabaseInitializerService>();
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IFriendsService, FriendsService>();
            serviceCollection.AddTransient<ITownService, TownService>();
            serviceCollection.AddTransient<IAlbumService, AlbumService>();

            /*
            services go here
            */

            serviceCollection.AddSingleton<IUserSessionService, UserSessionService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }

    }
}