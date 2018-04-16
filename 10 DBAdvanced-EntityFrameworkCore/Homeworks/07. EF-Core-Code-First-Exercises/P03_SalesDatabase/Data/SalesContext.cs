using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Store> Stores { get; set; }


        public SalesContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.ConnectionString);
            }

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            #region productConstraints

            builder.Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode();

            builder.Entity<Product>()
                .Property(p => p.Description)
                .HasMaxLength(250)
                .HasDefaultValue("No description");

            #endregion

            #region customerConstraints

            //builder.Entity<Customer>()
            //    .HasKey(c => c.CustomerId);

            builder.Entity<Customer>()
                .Property(c => c.Name)
                .HasMaxLength(100)
                .IsUnicode();

            builder.Entity<Customer>()
                .Property(c => c.Email)
                .HasMaxLength(80);

            #endregion

            #region storeConstraints

            //builder.Entity<Store>()
            //    .HasKey(s => s.StoreId);

            builder.Entity<Store>()
                .Property(s => s.Name)
                .IsUnicode()
                .HasMaxLength(80);

            #endregion

            #region saleConstraints

            //builder.Entity<Sale>()
            //    .HasKey(s => s.SaleId); //composite key ?

            //builder.Entity<Sale>()
            //    .Property(s => s.SaleId)
            //    .ValueGeneratedOnAdd();

            //builder.Entity<Sale>()
            //    .HasOne(s => s.Store)
            //    .WithMany(s => s.Sales)
            //    .HasForeignKey(s => s.SaleId);

            //builder.Entity<Sale>()
            //    .HasOne(s => s.Product)
            //    .WithMany(p => p.Sales)
            //    .HasForeignKey(s => s.SaleId);

            //builder.Entity<Sale>()
            //    .HasOne(s => s.Customer)
            //    .WithMany(c => c.Sales)
            //    .HasForeignKey(s => s.SaleId);

            builder.Entity<Sale>(esa =>
            {
                esa.Property(p => p.Date).HasDefaultValueSql("getdate()");
            });

            #endregion
        }


    }
}