using System;
using System.Collections.Generic;

namespace Problem2.Rectangle_Area
{
    class RectangleArea
    {
        static void Main(string[] args)
        {
             List<double> numbers = new List<double>();

            for (int i = 0; i < 2; i++)
            {
                numbers.Add(double.Parse(Console.ReadLine()));
            }

            double rectangleArea = numbers[0] * numbers[1];
                       
            Console.WriteLine("{0:0.00}", rectangleArea);
        }
    }
}
