using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Type in the coefficient a (ax^2 + bx + c):");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Type in the coefficient b (ax^2 + bx + c):");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Type in the coefficient c (ax^2 + bx + c):");
        double c = double.Parse(Console.ReadLine());
        if(a==0)
        {
            Console.WriteLine("Your equation is not quadratic!");
        }
        else
        {
            double d = (b * b) - (4 * a * c);

            if(d>0)
            {
               double firstRoot = (-b + Math.Sqrt(d))/(2*a);
               double secondRoot = (-b - Math.Sqrt(d))/(2*a);
               Console.WriteLine("The roots of your equation are: {0} and {1}." ,firstRoot ,secondRoot);
            }
            else if(d==0)
            {
                double soleRoot = (-b) / (2 * a) ;
                Console.WriteLine("Your equation has a single root: {0}." , soleRoot);
            }
            else if(d<0)
            {
                Console.WriteLine("Your equation has no real roots!");
            }
        }
    }
}