namespace Instagraph.Data
{
    using Microsoft.EntityFrameworkCore;
    using Instagraph.Models;

    public class InstagraphContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<UserFollower> UsersFollowers { get; set; }
        public DbSet<Post> Posts { get; set; }
        
        public InstagraphContext() { }

        public InstagraphContext(DbContextOptions options)
            :base(options) { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(u => u.Id);

                e.Property(u => u.Username).HasMaxLength(30).IsRequired();
                e.HasIndex(u => u.Username).IsUnique(true); //overwrites isReq?

                e.Property(u => u.Password).HasMaxLength(20).IsRequired(); ;

                e.Property(u => u.ProfilePictureId).IsRequired();

                e.HasOne(u => u.ProfilePicture)
                .WithMany(p => p.Users)
                .HasForeignKey(u => u.ProfilePictureId);
            });

            modelBuilder.Entity<Picture>(e =>
            {
                e.HasKey(p => p.Id);

                e.Property(p => p.Size).IsRequired();
                e.Property(p => p.Path).IsRequired();
            });

            modelBuilder.Entity<Post>(e =>
            {
                e.HasKey(p => p.Id);

                e.Property(p => p.Caption).IsRequired();
                e.Property(p => p.PictureId).IsRequired();
                e.Property(p => p.UserId).IsRequired();

                e.HasOne(p => p.User)
                    .WithMany(u => u.Posts)
                    .HasForeignKey(p => p.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(p => p.Picture)
                    .WithMany(pic => pic.Posts)
                    .HasForeignKey(p => p.PictureId);
            });

            modelBuilder.Entity<Comment>(e =>
            {
                e.HasKey(c => c.Id);

                e.Property(c => c.Content).HasMaxLength(250).IsRequired();
                e.Property(c => c.UserId).IsRequired();
                e.Property(c => c.PostId).IsRequired();

                e.HasOne(c => c.User)
                    .WithMany(u => u.Comments)
                    .HasForeignKey(c => c.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(c => c.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(c => c.PostId)
                    .OnDelete(DeleteBehavior.Restrict);
            });


            modelBuilder.Entity<UserFollower>(e =>
            {
                e.HasKey(uf => new
                {
                    uf.UserId, uf.FollowerId
                });

                e.HasOne(uf => uf.User)
                    .WithMany(u => u.Followers)
                    .HasForeignKey(uf => uf.UserId)
                    .OnDelete(DeleteBehavior.Restrict); ;

                e.HasOne(uf => uf.Follower)
                    .WithMany(u => u.UsersFollowing)
                    .HasForeignKey(uf => uf.FollowerId);

                e.ToTable("UsersFollowers");
            });

        }
    }
}