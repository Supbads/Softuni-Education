using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Problem_2.Laptop_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Laptop> laptopShop = new List<Laptop>();
            laptopShop.Add(new Laptop("Alienware nqkaf bugaf",899.99));
            string laptopInfo = laptopShop[0].ToString();
            Console.WriteLine(laptopInfo);

        }
    }
}
