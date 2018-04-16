using System;

namespace Problem_12.Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string nameOfBiggestKeg = "";
            double volumeOfBiggestKeg = 0.0;


            for (int i = 0; i < n; i++)
            {
                string nameOfCurrentKeg = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                double volumeOfCurrentKeg = Math.PI * Math.Pow(radius, 2) * height;

                if (volumeOfCurrentKeg > volumeOfBiggestKeg)
                {
                    volumeOfBiggestKeg = volumeOfCurrentKeg;
                    nameOfBiggestKeg = nameOfCurrentKeg;
                }

            }

            Console.WriteLine(nameOfBiggestKeg);


        }
    }
}