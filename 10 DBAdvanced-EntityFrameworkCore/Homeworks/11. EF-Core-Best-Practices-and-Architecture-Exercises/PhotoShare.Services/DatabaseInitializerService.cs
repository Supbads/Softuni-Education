namespace PhotoShare.Services
{
    using Data;
    using Contracts;

    public class DatabaseInitializerService : IDatabaseInitializerService
    {
        private readonly PhotoShareContext context;

        public DatabaseInitializerService(PhotoShareContext context)
        {
            this.context = context;
        }

        public void InitializeDatabase()
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}