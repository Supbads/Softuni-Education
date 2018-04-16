using System;

namespace Problem_12.Rectangle_Properties
{
    class RectangleProperties
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Console.WriteLine("{0}\n{1}\n{2}",(width+height)*2, width*height, Math.Sqrt(width*width + height*height));
            
        }
    }
}