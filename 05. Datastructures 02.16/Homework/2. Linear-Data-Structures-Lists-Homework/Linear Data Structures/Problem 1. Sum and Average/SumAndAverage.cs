namespace Problem_1.Sum_and_Average
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SumAndAverage
    {
        static void Main(string[] args)
        {
            string output = "Sum={0}; Average={1}";
            List<int> numbers =
                Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

            int sum = numbers.Sum();

            if (numbers.Count == 0)
            {
                Console.WriteLine(string.Format(output,sum,0));
            }
            else
            {
                double average = (double)sum / numbers.Count;
                Console.WriteLine(string.Format(output,sum,average));
            }
        }
    }
}