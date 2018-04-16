namespace Orders
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    class LINQQueries
    {
        private const int defaultNumberOfDashes = 10;
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var dataMapper = new DataMapper();
            var categories = dataMapper.GetAllCategories();
            var products = dataMapper.GetAllProducts();
            var orders = dataMapper.GetAllOrders();

            // Names of the 5 most expensive products
            var firstFiveMostExpensiveProducts = products
                .OrderByDescending(p => p.UnitPrice)
                .Take(5)
                .Select(p => p.Name);
            Console.WriteLine(string.Join(Environment.NewLine, firstFiveMostExpensiveProducts));

            GenerateDashes(defaultNumberOfDashes);

            // Number of products in each category
            var countOfProductsInEachCategory = products
                .GroupBy(p => p.CategoryID)
                .Select(group => new { Category = categories.First(c => c.ID == group.Key).Name, Count = group.Count() })
                .ToList();

            foreach (var item in countOfProductsInEachCategory)
            {
                Console.WriteLine("{0}: {1}", item.Category, item.Count);
            }

            GenerateDashes(defaultNumberOfDashes);

            // The 5 top products (by order quantity)
            var fiveMostOrderedProducts = orders
                .GroupBy(o => o.ProductID)
                .Select(grp => new { Product = products.First(p => p.ID == grp.Key).Name, Quantities = grp.Sum(grpgrp => grpgrp.Quantity) })
                .OrderByDescending(q => q.Quantities)
                .Take(5);

            foreach (var item in fiveMostOrderedProducts)
            {
                Console.WriteLine("{0}: {1}", item.Product, item.Quantities);
            }

            GenerateDashes(defaultNumberOfDashes);

            // The most profitable category
            var mostProfitableCategory = orders
                .GroupBy(o => o.ProductID)
                .Select(g => new { categoryID = products.First(p => p.ID == g.Key).CategoryID, price = products.First(p => p.ID == g.Key).UnitPrice, quantity = g.Sum(p => p.Quantity) })
                .GroupBy(gg => gg.categoryID)
                .Select(grp => new { categoryName = categories.First(c => c.ID == grp.Key).Name, totalQuantity = grp.Sum(g => g.quantity * g.price) })
                .OrderByDescending(g => g.totalQuantity)
                .First();

            Console.WriteLine("{0}: {1}", mostProfitableCategory.categoryName, mostProfitableCategory.totalQuantity);
        }

        private static void GenerateDashes(int numberOfDashes)
        {
            Console.WriteLine(new string('-', numberOfDashes));
        }
    }
}
