namespace ProductsShop.Data
{
    using Microsoft.EntityFrameworkCore;
    using ProductsShop.Models;

    public class ProductsShopContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
        public DbSet<Product> Products { get; set; }

        public ProductsShopContext() { }

        public ProductsShopContext(DbContextOptions options) : base(options){ }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=ProductsShop;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(e =>
            {
                e.HasKey(p => p.Id);

                e.Property(p => p.BuyerId).IsRequired(false);

                e.HasOne(p => p.Buyer)
                    .WithMany(b => b.ProductsBought)
                    .HasForeignKey(p => p.BuyerId);

                e.HasOne(p => p.Seller)
                    .WithMany(s => s.ProductsSold)
                    .HasForeignKey(p => p.SellerId);
            });

            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(u => u.Id);

                e.Property(u => u.FirstName).IsRequired(false);

                e.Property(u => u.LastName).IsRequired();
            });

            modelBuilder.Entity<CategoryProduct>(e =>
            {
                e.HasKey(cp => new {cp.CategoryId, cp.ProductId});

                e.HasOne(cp => cp.Product)
                    .WithMany(p => p.CategoryProducts)
                    .HasForeignKey(cp => cp.ProductId);
                
                e.HasOne(cp => cp.Category)
                    .WithMany(c => c.CategoryProducts)
                    .HasForeignKey(cp => cp.CategoryId);

            });

            modelBuilder.Entity<Category>(e =>
            {
                e.HasKey(c => c.Id);
            });

        }
    }
}