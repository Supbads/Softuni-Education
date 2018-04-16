using System;
using Problem_1.Point3D;

namespace Problem_2.Distance_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Point3D firstPoint = new Point3D(-4,7,9);
            Point3D secondPoint = new Point3D(15, 4, 16);

            double distance = DistanceCalculator.CalculateDistance(firstPoint, secondPoint);
            Console.WriteLine(distance);
        }
    }
}
