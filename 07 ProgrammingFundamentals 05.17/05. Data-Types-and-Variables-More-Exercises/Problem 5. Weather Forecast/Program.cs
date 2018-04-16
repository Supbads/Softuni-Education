using System;
using System.Linq;

namespace Problem_5.Weather_Forecast
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            if (str.Contains('.'))
            {
                Console.WriteLine("Rainy");
                return;
            }

            long number = long.Parse(str);


            bool isSbyte = (-128 <= number) && (number <= 127);
            if (isSbyte)
            {
                Console.WriteLine("Sunny");
                return;
            }

            bool isInt = (-2147483648 <= number) && (number <= 2147483647);
            if (isInt)
            {
                Console.WriteLine("Cloudy");
                return;
            }
            bool isLong = (-9223372036854775808 <= number) && (number <= 9223372036854775807);

            if (isLong)
            {
                Console.WriteLine("Windy");
                return;
            }
        }
    }
}