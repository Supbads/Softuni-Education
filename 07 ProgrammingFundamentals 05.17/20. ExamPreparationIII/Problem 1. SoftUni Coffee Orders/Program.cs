using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.SoftUni_Coffee_Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            decimal sum = 0;
            for (int i = 0; i < n; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());

                var date = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", DateTimeFormatInfo.InvariantInfo);
                var daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
                int capsulesCount = int.Parse(Console.ReadLine());

                decimal product = pricePerCapsule * capsulesCount * daysInMonth;
                Console.WriteLine("The price for the coffee is: ${0:F2}",product);
                sum += product;

            }
            Console.WriteLine("Total: ${0:F2}",sum);

        }
    }
}
