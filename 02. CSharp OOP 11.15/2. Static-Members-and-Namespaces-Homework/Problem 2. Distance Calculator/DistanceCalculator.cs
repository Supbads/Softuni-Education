using System;
using Problem_1.Point3D;

namespace Problem_2.Distance_Calculator
{
    static class DistanceCalculator
    {
        
        public static double CalculateDistance(Point3D p1, Point3D p2)
        {
            double deltaX = (p2.X - p1.X);
            double deltaY = (p2.Y - p1.Y);
            double deltaZ = (p2.Z - p1.Z);
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
        }
    }
}
