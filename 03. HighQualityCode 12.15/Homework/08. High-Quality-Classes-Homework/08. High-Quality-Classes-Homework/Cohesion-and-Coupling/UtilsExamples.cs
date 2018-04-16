namespace CohesionAndCoupling
{
    using System;

    class UtilsExamples
    {
        static void Main()
        {
            Console.WriteLine(FileUtils.GetFileExtension("example"));
            Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                Utils.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                Utils.CalcDistance3D(5, 2, -1, 3, -6, 4));

            //could be made as a separate class or a struct
            int width = 3;
            int height = 4;
            int depth = 5;

            Console.WriteLine("Volume = {0:f2}", Utils.CalcVolume(width, height, depth));
            Console.WriteLine("Diagonal XYZ = {0:f2}", Utils.CalcDiagonalXYZ(width, height, depth));
            Console.WriteLine("Diagonal XY = {0:f2}", Utils.CalcDiagonalXY(width, height));
            Console.WriteLine("Diagonal XZ = {0:f2}", Utils.CalcDiagonalXZ(width, depth));
            Console.WriteLine("Diagonal YZ = {0:f2}", Utils.CalcDiagonalYZ(height, depth));
        }
    }
}
