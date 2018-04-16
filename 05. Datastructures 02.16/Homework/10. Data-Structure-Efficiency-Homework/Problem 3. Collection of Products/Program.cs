namespace Problem_3.Collection_of_Products
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var collection = new ProductCollection<Product>();
            SeedProducts(collection);

            var productsByTitleAndPrice350 = collection.Find("Neshto", 350);
            PrintCollection(productsByTitleAndPrice350, "Products with title Neshto and price 350", "######");

            var productsInRange220to420 = collection.Find(220, 420);
            PrintCollection(productsInRange220to420, "Products in range 220 to 420", "######");

            var productsBySupplierInRange150to600 = collection.Find(Supplier.Apple, 150, 600);
            PrintCollection(productsBySupplierInRange150to600, "Products by supplier Apple in range 150 to 420", "######");


            //var product10 = new Product("1", "drugoNeshto", Supplier.Toshiba, 77);
        }

        static void SeedProducts(ProductCollection<Product> collection)
        {
            var product = new Product(1, "Neshto", Supplier.Acer, 350);
            var product1 = new Product(2, "something", Supplier.Toshiba, 400);
            var product2 = new Product(3, "something", Supplier.Razer, 377);
            var product3 = new Product(4, "Neshto", Supplier.Nakov, 420);
            var product4 = new Product(5, "rick", Supplier.Acer, 280);
            var product5 = new Product(6, "morty", Supplier.Razer, 500);
            var product6 = new Product(7, "Stamat", Supplier.Toshiba, 350);
            var product7 = new Product(8, "something", Supplier.Apple, 350);
            var product8 = new Product(9, "Neshto", Supplier.Acer, 350);
            var product9 = new Product(10, "Mariika", Supplier.Nakov, 415);
            var product10 = new Product(11, "telefonche", Supplier.Apple, 70);
            var product11 = new Product(12, "SomethingIntrsting", Supplier.Apple, 900);
            var product12 = new Product(13, "Neshto", Supplier.Nakov, 350);
            var product13 = new Product(14, "Neshto", Supplier.Razer, 500);
            var product14 = new Product(15, "Pesho", Supplier.Apple, 140);
            var product15 = new Product(16, "Gosho", Supplier.Apple, 330);

            collection.Add(product);
            collection.Add(product1);
            collection.Add(product2);
            collection.Add(product3);
            collection.Add(product4);
            collection.Add(product5);
            collection.Add(product6);
            collection.Add(product7);
            collection.Add(product8);
            collection.Add(product9);
            collection.Add(product10);
            collection.Add(product11);
            collection.Add(product12);
            collection.Add(product13);
            collection.Add(product14);
            collection.Add(product15);
        }

        static void PrintCollection(IEnumerable<Product> collection, string startMessage, string endMessage)
        {
            Console.WriteLine(startMessage);
            foreach (Product product in collection)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine(endMessage);
        }
    }
}
