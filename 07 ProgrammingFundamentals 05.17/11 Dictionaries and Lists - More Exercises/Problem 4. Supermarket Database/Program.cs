using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Supermarket_Database
{
    public class Product
    {
        public Product(string name, decimal price, int quantity)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
        
        public override bool Equals(object obj)
        {
            if (obj is Product && obj != null)
            {
                Product other = (Product)obj;
                return (other.Name == this.Name);
            }

            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            var input = Console.ReadLine();
            
            while (input!="stocked")
            {
                var tokens = input.Split();
                var name = tokens[0];
                var price = decimal.Parse(tokens[1]);
                var quantity = int.Parse(tokens[2]);

                if (!products.ContainsKey(name))
                {
                    products.Add(name, new Product(name, price, quantity));
                }
                
                products[name].Price = price;
                products[name].Quantity += quantity;

                input = Console.ReadLine();
            }


            decimal sum = 0;

            foreach (var nameAndProductPair in products)
            {
                var currentProduct = nameAndProductPair.Value;

                Console.WriteLine("{0}: ${1:F2} * {2} = ${3:F2}", currentProduct.Name, currentProduct.Price, currentProduct.Quantity, currentProduct.Price*currentProduct.Quantity);

                sum += currentProduct.Price * currentProduct.Quantity;
            }

            Console.WriteLine(new string('-',30));
            Console.WriteLine("Grand Total: ${0:F2}",sum);


        }
    }
}
