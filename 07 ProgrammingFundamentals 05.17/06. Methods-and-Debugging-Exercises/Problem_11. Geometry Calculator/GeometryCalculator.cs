using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_11.Geometry_Calculator
{
    class GeometryCalculator
    {
        static void Main(string[] args)
        {
            //triangle square rectangle , circle
            string figure = Console.ReadLine();

            if (figure == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());

                Console.WriteLine("{0:0.00}", a*b/2);
            }
            else if (figure == "square")
            {
                double a = double.Parse(Console.ReadLine());

                Console.WriteLine("{0:F2}", a*a);
            }
            else if (figure == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());

                Console.WriteLine("{0:F2}", a * b);
            }
            else
            {
                double a = double.Parse(Console.ReadLine());
                Console.WriteLine("{0:F2}", Math.PI * Math.Pow(a,2));
            }
        }
    }
}
