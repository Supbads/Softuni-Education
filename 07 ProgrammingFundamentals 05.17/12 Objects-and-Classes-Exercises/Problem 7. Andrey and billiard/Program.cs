using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_7.Andrey_and_billiard
{
    //public class Product
    //{
    //    public Product(string name, decimal price)
    //    {
    //        Name = name;
    //        Price = price;
    //    }

    //    public string Name { get; set; }

    //    public decimal Price { get; set; }
    //}

    public class Student
    {
        public Student(string name)
        {
            Name = name;
            ShopList = new Dictionary<string, int>();
        }

        public string Name { get; set; }

        public Dictionary<string, int> ShopList { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Student> students = new Dictionary<string, Student>();
            Dictionary<string, decimal> products = new Dictionary<string, decimal>();
            
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(new[] {'-'});
                string product = tokens[0];
                decimal price = decimal.Parse(tokens[1]);

                if (!products.ContainsKey(product))
                {
                    products.Add(product, 0);//test without add
                }

                products[product] = price;
            }


            string input = Console.ReadLine();

            while (input != "end of clients")
            {
                var tokens = input.Split(new[] {'-', ','});
                //Toshko-Bira,3
                var studentName = tokens[0];
                var productName = tokens[1];
                var quantity = int.Parse(tokens[2]);


                if (!products.ContainsKey(productName))
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (!students.ContainsKey(studentName))
                {
                    students.Add(studentName ,new Student(studentName));
                }

                if (!students[studentName].ShopList.ContainsKey(productName))
                {
                    students[studentName].ShopList.Add(productName, 0);
                }
                students[studentName].ShopList[productName] += quantity;

                input = Console.ReadLine();
            }

            decimal totalBill = 0;
            foreach (var nameAndStudentPair in students.OrderBy(x => x.Value.Name))
            {
                var studentName = nameAndStudentPair.Key;
                var student = nameAndStudentPair.Value;

                Console.WriteLine(studentName);

                decimal sum = 0;
                foreach (var productAndQuantityPair in student.ShopList)
                {
                    var product = productAndQuantityPair.Key;
                    var productQuantity = productAndQuantityPair.Value;

                    decimal price = products[product] * productQuantity;
                    sum += price;

                    Console.WriteLine("-- {0} - {1}",product, productQuantity);
                }

                Console.WriteLine("Bill: {0:F2}",sum);
                totalBill += sum;
            }

            Console.WriteLine("Total bill: {0:F2}", totalBill);
        }
    }
}