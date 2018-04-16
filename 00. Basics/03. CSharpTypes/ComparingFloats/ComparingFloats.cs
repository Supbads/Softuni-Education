using System;

class ComparingFloats
{
    static void Main()
    {
        double eps = 0.000001;
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        if (a > b)
        {
            if((a - b) < eps)
            {
                Console.WriteLine("a is equal to b");

            }
            else
            {
                Console.WriteLine("a isn't equal to b");
            }

        }
        else
        {
            if(b > a)
            {
                if ((b - a) < eps)
                {
                    Console.WriteLine("a is equal to b");
                }
                else
                {
                    Console.WriteLine("a isn't equal to b");
                }
            }
        }
    }
}