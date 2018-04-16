using System;

namespace Problem_3.Megapixels
{
    class Megapixels
    {
        static void Main(string[] args)
        {
            decimal width = decimal.Parse(Console.ReadLine());
            decimal height = decimal.Parse(Console.ReadLine());

            decimal pixelToMegapixelRatio = 1000000;

            decimal pixelsOnScreen = width * height;

            decimal pixelsOnScreenToMegaPixels = pixelsOnScreen / pixelToMegapixelRatio;
            
            Console.WriteLine("{0}x{1} => {2}MP", width, height, Math.Round(pixelsOnScreenToMegaPixels, 1));
        }
    }
}