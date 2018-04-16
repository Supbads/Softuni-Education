using System;
using System.Collections.Generic;
using System.Linq;


namespace Problem_2.Odd_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var onlyEven = numbers.Where(n => n % 2 == 0);

            var average = onlyEven.Average();
            
            foreach (var i in onlyEven)
            {
                if (i <= average)
                {
                    Console.Write(i-1+" ");
                }
                else if (i > average)
                {
                    Console.Write(i+1+" ");
                }

            }
        }
    }
}
