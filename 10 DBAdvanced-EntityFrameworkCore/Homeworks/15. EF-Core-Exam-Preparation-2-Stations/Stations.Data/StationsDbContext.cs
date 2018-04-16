namespace Stations.Data
{
    using Microsoft.EntityFrameworkCore;
    using Stations.Models;
    using Stations.Models.Enums;

    public class StationsDbContext : DbContext
    {
        public DbSet<CustomerCard> Cards { get; set; }
        public DbSet<SeatingClass> SeatingClasses { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<TrainSeat> TrainSeats { get; set; }
        public DbSet<Trip> Trips { get; set; }

        public StationsDbContext()
        {
        }

        public StationsDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerCard>(e =>
            {
                e.HasKey(cc => cc.Id);

                e.Property(cc => cc.Name).HasMaxLength(128).IsRequired();

                e.Property(cc => cc.Type).HasDefaultValue(CardType.Normal);
            });

            modelBuilder.Entity<Ticket>(e =>
            {
                e.HasKey(t => t.Id);

                e.Property(t => t.Price).IsRequired();
                e.Property(t => t.SeatingPlace).HasMaxLength(8).IsRequired();
                e.Property(t => t.TripId).IsRequired();
                e.Property(t => t.CustomerCardId).IsRequired(false);

                e.HasOne(t => t.CustomerCard)
                    .WithMany(cc => cc.BoughtTickets)
                    .HasForeignKey(t => t.CustomerCardId);

                //e.HasOne(t => t.Trip)
                //    .WithOne(trip => trip.Ticket)
                //    .HasForeignKey<Trip>(t => t.Id);

            });

            modelBuilder.Entity<Trip>(e =>
            {
                e.HasKey(t => t.Id);

                e.Property(t => t.OriginStationId).IsRequired();
                e.Property(t => t.DestinationStationId).IsRequired();
                e.Property(t => t.DepartureTime).IsRequired();
                e.Property(t => t.ArrivalTime).IsRequired();
                e.Property(t => t.TrainId).IsRequired();
                e.Property(t => t.Status).HasDefaultValue(TripStatus.OnTime);
                e.Property(t => t.TimeDifference).IsRequired(false);

                e.HasOne(t => t.OriginStation)
                    .WithMany(s => s.TripsFrom)
                    .HasForeignKey(t => t.OriginStationId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(t => t.DestinationStation)
                    .WithMany(s => s.TripsTo)
                    .HasForeignKey(t => t.DestinationStationId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(t => t.Train)
                    .WithMany(train => train.Trips)
                    .HasForeignKey(t => t.TrainId)
                    .OnDelete(DeleteBehavior.Restrict);// might need to remove
            });

            modelBuilder.Entity<TrainSeat>(e =>
            {
                e.HasKey(ts => ts.Id);

                e.Property(ts => ts.TrainId).IsRequired();
                e.Property(ts => ts.SeatingClassId).IsRequired();
                e.Property(ts => ts.Quantity).IsRequired();

                e.HasOne(ts => ts.Train)
                    .WithMany(t => t.TrainSeats)
                    .HasForeignKey(ts => ts.TrainId);

                //e.HasOne(ts => ts.SeatingClass)
                //    .WithOne(sc => sc.TrainSeat)
                //    .HasForeignKey<SeatingClass>(sc => sc.Id);
            });

            modelBuilder.Entity<SeatingClass>(e =>
            {
                e.HasKey(sc => sc.Id);

                e.Property(sc => sc.Name).HasMaxLength(30).IsRequired();
                e.HasIndex(sc => sc.Name).IsUnique();

                e.Property(sc => sc.Abbreviation).HasMaxLength(2).IsRequired();
                e.HasIndex(sc => sc.Abbreviation).IsUnique();
            });

            modelBuilder.Entity<Train>(e =>
            {
                e.HasKey(t => t.Id);

                e.Property(t => t.TrainNumber).IsRequired().HasMaxLength(10);
                e.HasIndex(t => t.TrainNumber).IsUnique();

                e.Property(t => t.Type).IsRequired(false);
            });

            modelBuilder.Entity<Station>(e =>
            {
                e.HasKey(s => s.Id);

                e.Property(s => s.Name).HasMaxLength(50).IsRequired();
                e.HasIndex(s => s.Name).IsUnique();

                e.Property(s => s.Town).HasMaxLength(50).IsRequired();
            });

        }
    }
}