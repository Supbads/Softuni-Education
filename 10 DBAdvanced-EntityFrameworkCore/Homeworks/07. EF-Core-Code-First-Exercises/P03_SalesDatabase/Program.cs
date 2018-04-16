using System;
using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SalesContext())
            {

                //OnStartup(context);



            }
            

        }

        private static void OnStartup(SalesContext context)
        {
            context.Database.EnsureDeleted();

            context.Database.Migrate();

            Seed(context);
        }

        private static void Seed(SalesContext context)
        {
            var customers = new[]
            {
                new Customer("Ivan", "ivan@abv.bg", "12132125"),
                new Customer("Dragan", "drago@hotmail.com", "5674564"),
                new Customer("Petkan", "5kan@mail.bg", "897897789"),
                new Customer("Gosho", "George@gmail.com", "558285258258"),
            };

            var products = new[]
            {
                new Product("Grim", 26, 19.99m),
                new Product("Gashti", 22, 35.99m),
                new Product("Shapka", 17, 46.99m),
                new Product("Napitka", 10, 2m),
            };

            var stores = new[]
            {
                new Store("maybelline"),
                new Store("Cropp"),
                new Store("Kappa"),
                new Store("Becks"),
            };

            var sales = new[]
            {
                new Sale(new DateTime(2017, 1, 8), 3, 1, 3),
                new Sale(new DateTime(2014, 6, 21), 1, 3, 1),
                new Sale(new DateTime(2016, 11, 17), 2, 3, 2),
                new Sale(new DateTime(2017, 1, 8), 4, 4, 4),
            };

            context.Customers.AddRange(customers);
            context.Products.AddRange(products);
            context.Stores.AddRange(stores);
            context.Sales.AddRange(sales);

            context.SaveChanges();
        }
    }
}