using System;

namespace Problem_1.Point3D
{
    class Program
    {
        static void Main(string[] args)
        {
            Point3D point = new Point3D(1, 2, 3);
            Console.WriteLine(point.ToString());
            point.ToString();
            Point3D asd = Point3D.GetStartingPoint();
            Console.WriteLine(asd.ToString());
        }
    }
}
