namespace ProductsShop.Startup
{
    using ProductsShop.Data;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using Models;
    using System.Collections.Generic;
    using System.Xml.Linq;
    using Microsoft.EntityFrameworkCore;

    class Startup
    {
        static void Main(string[] args)
        {
            using (var context = new ProductsShopContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                // JSON
                // Problem 1.
                //ImportData(context);

                // Problem 2. Products In range
                //ProductsInRange(context);

                // Problem 3. Successfully sold products
                //SuccessfullySoldProducts(context);

                // Problem 4. Categories by products count
                //CategoriesByProductsCount(context);

                // Problem 5. Users And Products
                //UsersAndProducts(context);

                // XML
                // Problem 6. Import Data from XML
                ImportDataXml(context);

                // Problem 7. Product in range
                ProductsInRangeXml(context);

                // Problem 8. Sold Products
                SoldProductsXml(context);


                // Problem 9. Categories By Products Count
                CategoriesByProductsCountXml(context);

                // Problem 10. Users and Products
                UsersAndProductsXML(context);
            }
        }

        private static void UsersAndProductsXML(ProductsShopContext context)
        {
            var outputDirectory = "users-and-products.xml";

            var users = context.Users
                .Include(u => u.ProductsSold)
                .ThenInclude(p => p.Buyer)
                .Where(u => u.ProductsSold.Any())
                .AsNoTracking().ToArray();

            var usersWithSoldProducts = new
            {
                users = users.Select(u => new
                    {
                        u.FirstName,
                        u.LastName,
                        u.Age,
                        soldProducts = new
                        {
                            u.ProductsSold.Count,
                            products = u.ProductsSold.Select(p => new
                            {
                                p.Name,
                                p.Price
                            }).ToArray()
                        }
                    })
                    .OrderByDescending(u => u.soldProducts.Count)
            };

            var usersFinal = new
            {
                usersCount = usersWithSoldProducts.users.Count(),
                users = usersWithSoldProducts.users
            };
            
            var doc = new XDocument(new XDeclaration("1.0", "utf-8", null));
            doc.Add(new XElement("users", new XAttribute("count", usersFinal.usersCount))); // root


            foreach (var user in usersFinal.users)
            {
                doc.Root.Add(new XElement("user",
                    new XAttribute("first-name", $"{user.FirstName}"),
                    new XAttribute("last-name", $"{user.LastName}"),
                    new XAttribute("age", $"{user.Age}"),
                    new XElement("sold-products", new XAttribute("count", user.soldProducts.Count))
                    ));

                var productElements = doc.Root.Elements()
                    .SingleOrDefault(e =>
                        e.Name == "user" &&
                        e.Attribute("first-name").Value == $"{user.FirstName}" &&
                        e.Attribute("last-name").Value == $"{user.LastName}")
                    .Element("sold-products");

                // What happens if 2 people have the same name ;x

                foreach (var p in user.soldProducts.products)
                {
                    productElements
                        .Add(new XElement("product",
                            new XAttribute("Name", $"${p.Name}"),
                            new XAttribute("Price", $"{p.Price}")));
                }

            }

            var result = doc.Declaration + doc.ToString();

            File.WriteAllText(outputDirectory, result);
        }

        private static void CategoriesByProductsCountXml(ProductsShopContext context)
        {
            var outputDirectory = "categories-by-products.xml";

            var categoriesByProductsCount = context.Categories
                .Include(c => c.CategoryProducts)
                .ThenInclude(cp => cp.Product)
                .Select(c => new
                {
                    Category = c.Name,
                    productsCount = c.CategoryProducts.Count,
                    averagePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    totalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(e => e.productsCount)
                .ThenBy(e => e.Category);

            var doc = new XDocument(new XDeclaration("1.0", "utf-8", null));
            doc.Add(new XElement("categories")); // root
            
            foreach (var category in categoriesByProductsCount)
            {
                doc.Root.Add(new XElement("category",
                    new XAttribute("name", category.Category),
                    new XElement("products-count",category.productsCount),
                    new XElement("average-price", category.averagePrice),
                    new XElement("total-revenue", category.totalRevenue)));
            }

            var result = doc.Declaration + doc.ToString();

            File.WriteAllText(outputDirectory, result);
        }

        private static void SoldProductsXml(ProductsShopContext context)
        {
            var outputDir = "users-sold-products.xml";

            var usersWithSoldProducts = context.Users
                .Include(u => u.ProductsSold)
                .ThenInclude(p => p.Buyer)
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    Products = u.ProductsSold
                        .Select(p => new
                        {
                            p.Name,
                            p.Price
                        }).ToArray()
                })
                .OrderBy(e => e.LastName)
                .ThenBy(e => e.FirstName);

            var doc = new XDocument(new XDeclaration("1.0", "utf-8", null));
            doc.Add(new XElement("users")); // root

            foreach (var user in usersWithSoldProducts)
            {
                doc.Root.Add(
                    new XElement("user",
                        new XAttribute("first-name", $"{user.FirstName}"),
                        new XAttribute("last-name", $"{user.LastName}"),
                        new XElement("sold-products")));

                var productElements = doc.Root.Elements()
                    .SingleOrDefault(e => 
                        e.Name == "user" &&
                        e.Attribute("first-name").Value == $"{user.FirstName}" && 
                        e.Attribute("last-name").Value == $"{user.LastName}")
                    .Element("sold-products");

                // What happens if 2 people have the same name ;x

                foreach (var p in user.Products)
                {
                    productElements
                        .Add(new XElement("product",
                            new XElement("Name", $"${p.Name}"),
                            new XElement("Price", $"{p.Price}")));
                }

            }

            var result = doc.Declaration + doc.ToString();
            File.WriteAllText(outputDir, result);
        }

        private static void ProductsInRangeXml(ProductsShopContext context)
        {
            string outputDir = "products-in-range.xml";
            int lowerBound = 1000;
            int upperBound = 2000;

            var products = context.Products
                .Include(p => p.Buyer)
                .Include(p => p.Seller)
                .Where(p => p.Price >= lowerBound && p.Price <= upperBound && p.Buyer != null)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = $"{p.Name}",
                    price = p.Price,
                    buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}",
                });

            var doc = new XDocument(new XDeclaration("1.0", "utf-8", null));

            doc.Add(new XElement("products")); // root

            foreach (var product in products)
            {
                doc.Root.Add(new XElement("product", 
                    new XAttribute("name", product.name),
                    new XAttribute("price", product.price),
                    new XAttribute("buyer", product.buyer)));
            }

            var result = doc.Declaration + doc.ToString();
            File.WriteAllText(outputDir, result);
        }

        private static void ImportDataXml(ProductsShopContext context)
        {
            ImportUsersXml(context);

            ImportProductsXml(context);

            ImportCategoriesXml(context);

            ImportCategoryProducts(context);
        }

        private static void ImportCategoriesXml(ProductsShopContext context)
        {
            var inputDir = "categories.xml";

            var input = File.ReadAllText(inputDir);
            var xmlDoc = XDocument.Parse(input);

            var elements = xmlDoc.Root.Elements();

            var categories = new List<Category>();

            foreach (XElement element in elements)
            {
                var name = element.Element("name").Value;

                var category = new Category()
                {
                    Name = name
                };

                categories.Add(category);
            }

            context.Categories.AddRange(categories);

            context.SaveChanges();

            Console.WriteLine($"{categories.Count} categories added from: " + inputDir);
        }

        private static void ImportProductsXml(ProductsShopContext context)
        {
            var inputDir = "products.xml";

            var input = File.ReadAllText(inputDir);
            var xmlDoc = XDocument.Parse(input);

            var elements = xmlDoc.Root.Elements();

            var products = new List<Product>();

            foreach (XElement element in elements)
            {
                var name = element.Element("name").Value;
                var price = decimal.Parse(element.Element("price").Value);

                var product = new Product()
                {
                    Name = name,
                    Price = price
                };

                products.Add(product);
            }


            var productsLength = products.Count;

            var users = context.Users.ToArray();
            var userIds = users.Select(u => u.Id).ToArray();
            var usersCount = users.Length;

            var random = new Random();

            for (int i = 0; i < productsLength; i++)
            {
                int? sellerId = 0;
                int buyerId = 0;

                do
                {
                    int sellerIndex = random.Next(0, usersCount);
                    int buyerIndex = random.Next(0, usersCount);

                    sellerId = userIds[sellerIndex];
                    buyerId = userIds[buyerIndex];

                } while (sellerId == buyerId);

                if (buyerId - sellerId > 5)
                {
                    sellerId = null;
                }

                products[i].BuyerId = sellerId;
                products[i].SellerId = buyerId;
            }

            context.Products.AddRange(products);

            context.SaveChanges();

            Console.WriteLine($"{products.Count} products added from: " + inputDir);
        }

        private static void ImportUsersXml(ProductsShopContext context)
        {
            var inputDir = "users.xml";
            var input = File.ReadAllText(inputDir);

            var xmlDoc = XDocument.Parse(input);

            var elements = xmlDoc.Root.Elements();

            var users = new List<User>();

            foreach (XElement element in elements)
            {
                var firstName = element.Attribute("firstName")?.Value;

                var lastName = element.Attribute("lastName")?.Value;

                int? age = null;

                if (element.Attribute("age") != null)
                {
                    age = int.Parse(element.Attribute("age")?.Value);
                }

                var user = new User()
                {
                    Age = age,
                    FirstName = firstName,
                    LastName = lastName
                };

                users.Add(user);
            }

            context.AddRange(users);

            context.SaveChanges();

            Console.WriteLine($"{users.Count} users added from: " + inputDir);
        }

        private static void UsersAndProducts(ProductsShopContext context)
        {
            var outputDir = "users-and-products.json";

            var users = context.Users
                .Include(u => u.ProductsSold)
                .ThenInclude(p => p.Buyer)
                .Where(u => u.ProductsSold.Any())
                .AsNoTracking().ToArray();

            var usersWithSoldProducts = new
            {
                users = users.Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Count,
                        products = u.ProductsSold.Select(p => new
                        {
                            name = p.Name,
                            price = p.Price
                        }).ToArray()
                    }
                })
                .OrderByDescending(u => u.soldProducts.count)};

            var usersFinal = new
            {
                usersCount = usersWithSoldProducts.users.Count(),
                users = usersWithSoldProducts.users
            };

            var asJson = JsonConvert.SerializeObject(usersFinal, Formatting.Indented);

            File.WriteAllText(outputDir, asJson);

            Console.WriteLine("Exported users and product details to file: " + outputDir);
        }

        private static void CategoriesByProductsCount(ProductsShopContext context)
        {
            var outputDirectory = "categories-by-products.json";

            var categoriesByProductsCount = context.Categories
                .Include(c => c.CategoryProducts)
                .ThenInclude(cp => cp.Product)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count,
                    averagePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    totalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(e => e.productsCount)
                .ThenBy(e => e.category);

            var asJson = JsonConvert.SerializeObject(categoriesByProductsCount, Formatting.Indented);

            File.WriteAllText(outputDirectory, asJson);

            Console.WriteLine("Exported categories by products to file: " + outputDirectory);
        }

        private static void SuccessfullySoldProducts(ProductsShopContext context)
        {
            var outputDirectory = "users-sold-products.json";

            var usersWithSoldProducts = context.Users
                .Include(u => u.ProductsSold)
                .ThenInclude(p => p.Buyer)
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                        .Select(p => new
                        {
                            name = p.Name,
                            price = p.Price,
                            buyerFirstName = p.Buyer.FirstName,
                            buyerLastName = p.Buyer.LastName
                        }).ToArray()
                })
                .OrderBy(e => e.lastName)
                .ThenBy(e => e.firstName);

            var asJson = JsonConvert.SerializeObject(usersWithSoldProducts, Formatting.Indented,
                new JsonSerializerSettings
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore
                });

            File.WriteAllText(outputDirectory, asJson);

            Console.WriteLine("Exported users and sold products to file: " + outputDirectory);
        }

        private static void ProductsInRange(ProductsShopContext context)
        {
            var lowerBound = 500m;
            var upperBound = 1000m;

            var outputDir = "products-in-range.json";

            var products = context.Products
                .Include(p => p.Buyer)
                .Include(p => p.Seller)
                .Where(p => p.Price >= lowerBound && p.Price <= upperBound)
                .OrderBy(p => p.Price)
                .Select(p => new
                {

                    name =   $"{p.Name}",
                    price = p.Price,
                    seller = $"{p.Seller.FirstName} {p.Seller.LastName}",
                });


            var productsSerialized = JsonConvert.SerializeObject(products, Formatting.Indented,
                new JsonSerializerSettings
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore
                });

            File.WriteAllText(outputDir, productsSerialized);

            Console.WriteLine("Exported users and products to file: " + outputDir);
        }

        static T[] ImportJson<T>(string path)
        {
            var file = File.ReadAllText(path);

            T[] objects = JsonConvert.DeserializeObject<T[]>(file);

            return objects;
        }

        static void ImportData(ProductsShopContext context)
        {
            string usersPath = "users.json";
            string productsPath = "products.json";
            string categoriesPath = "categories.json";

            ImportUsers(context, usersPath);

            ImportProducts(context, productsPath);

            ImportCategories(context, categoriesPath);

            ImportCategoryProducts(context);
        }

        private static void ImportCategoryProducts(ProductsShopContext context)
        {
            var categories = context.Categories.ToArray();
            var categoryIds = categories.Select(c => c.Id).ToArray();
            var categoriesCount = categoryIds.Length;

            var products = context.Products.ToArray();
            var productIds = products.Select(p => p.Id).ToArray();

            var categoryProducts = new List<CategoryProduct>();
            var random = new Random();

            bool limit = false;

            foreach (int productId in productIds)
            {
                if (limit)
                {
                    break;
                }

                for (int i = 0; i < 1; i++)
                {
                    int index = random.Next(0, categoriesCount);
                    while (categoryProducts.Any(cp => cp.ProductId == productId && cp.CategoryId == categoryIds[index]))
                    {
                        index = random.Next(0, categoriesCount);
                    }

                    var categoryProduct = new CategoryProduct()
                    {
                        CategoryId = categoryIds[index],
                        ProductId = productId
                    };

                    categoryProducts.Add(categoryProduct);

                }
            }

            context.CategoryProducts.AddRange(categoryProducts);

            context.SaveChanges();
        }

        private static void ImportCategories(ProductsShopContext context, string categoriesPath)
        {
            var categories = ImportJson<Category>(categoriesPath);
            var categoriesCount = categories.Length;

            context.Categories.AddRange(categories);

            context.SaveChanges();
            Console.WriteLine($"{categoriesCount} categories added");
            }

        private static void ImportProducts(ProductsShopContext context, string productsPath)
        {
            var products = ImportJson<Product>(productsPath);

            var productsLength = products.Length;

            var users = context.Users.ToArray();
            var userIds = users.Select(u => u.Id).ToArray();
            var usersCount = users.Length;

            var random = new Random();

            for (int i = 0; i < productsLength; i++)
            {
                int? sellerId = 0;
                int buyerId = 0;

                do
                {
                    int sellerIndex = random.Next(0, usersCount);
                    int buyerIndex = random.Next(0, usersCount);

                    sellerId = userIds[sellerIndex];
                    buyerId = userIds[buyerIndex];

                } while (sellerId == buyerId);

                if (buyerId - sellerId > 5)
                {
                    sellerId = null;
                }

                products[i].BuyerId = sellerId;
                products[i].SellerId = buyerId;
            }

            context.Products.AddRange(products);

            context.SaveChanges();

            Console.WriteLine($"{productsLength} products added");
        }

        private static void ImportUsers(ProductsShopContext context, string usersPath)
        {
            var users = ImportJson<User>(usersPath);

            context.Users.AddRange(users);

            var usersAdded = users.Length;

            Console.WriteLine($"{usersAdded} users added.");

            context.SaveChanges();
        }
    }
}