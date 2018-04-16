using System;

namespace Problem_16_Comparing_Floats
{
    class ComparingFloats
    {
        static void Main(string[] args)
        {
            double eps = 0.000001d;

            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            if (Math.Abs(a - b) > eps)
            {
                Console.WriteLine("False");
            }
            else
            {
                Console.WriteLine("True");
            }
        }
    }
}