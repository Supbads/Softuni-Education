namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class FootballBettingContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Team> Teams { get; set; }

        public FootballBettingContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Team>(e =>
            {
                e.HasKey(t => t.TeamId);
                e.HasOne(t => t.PrimaryKitColor)
                    .WithMany(c => c.PrimaryKitTeams)
                    .HasForeignKey(t => t.PrimaryKitColorId);

                e.HasOne(t => t.SecondaryKitColor)
                    .WithMany(c => c.SecondaryKitTeams)
                    .HasForeignKey(t => t.SecondaryKitColorId);

                e.HasOne(team => team.Town)
                    .WithMany(town => town.Teams)
                    .HasForeignKey(team => team.TownId);

                e.ToTable("Teams");
            });

            builder.Entity<Game>(e =>
            {
                e.HasKey(g => g.GameId);

                e.HasOne(g => g.HomeTeam)
                    .WithMany(ht => ht.HomeGames)
                    .HasForeignKey(g => g.HomeTeamId);

                e.HasOne(g => g.AwayTeam)
                    .WithMany(at => at.AwayGames)
                    .HasForeignKey(g => g.AwayTeamId);

                e.ToTable("Games");
            });
            
            builder.Entity<Player>(e =>
            {
                e.HasKey(p => p.PlayerId);

                e.HasOne(p => p.Team)
                    .WithMany(t => t.Players)
                    .HasForeignKey(p => p.TeamId);

                e.HasOne(p => p.Position)
                    .WithMany(pos => pos.Players)
                    .HasForeignKey(p => p.PositionId);
                

                e.ToTable("Players");
            });

            builder.Entity<PlayerStatistic>(e =>
            {
                e.HasKey(ps => new
                {
                    ps.GameId,
                    ps.PlayerId
                });

                e.HasOne(ps => ps.Game)
                    .WithMany(g => g.PlayerStatistics)
                    .HasForeignKey(ps => ps.GameId);

                e.HasOne(ps => ps.Player)
                    .WithMany(p => p.PlayerStatistics)
                    .HasForeignKey(ps => ps.PlayerId);

                e.ToTable("PlayerStatistics");
            });

            builder.Entity<Bet>(e =>
            {
                e.HasKey(b => b.BetId);

                e.HasOne(b => b.User)
                    .WithMany(u => u.Bets)
                    .HasForeignKey(b => b.UserId);

                e.ToTable("Bets");
            });

            builder.Entity<Town>(e =>
            {
                e.HasKey(t => t.TownId);
                e.HasOne(t => t.Country)
                    .WithMany(c => c.Towns)
                    .HasForeignKey(t => t.CountryId);

                e.ToTable("Towns");
            });

            builder.Entity<User>(e =>
            {
                e.HasKey(u => u.UserId);

                e.ToTable("Users");
            });

            builder.Entity<Country>(e =>
            {
                e.HasKey(c => c.CountryId);

                e.ToTable("Countries");
            });

        }
    }
}