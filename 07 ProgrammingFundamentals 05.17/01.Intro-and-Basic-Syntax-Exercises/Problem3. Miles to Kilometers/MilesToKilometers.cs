using System;

namespace Problem3.Miles_to_Kilometers
{
    class MilesToKilometers
    {

        //static double MilesToKilometersRatio = 1.60934;


        static void Main(string[] args)
        {
            Console.WriteLine("{0:0.00}", double.Parse(Console.ReadLine()) * 1.60934);

            //var miles = double.Parse(Console.ReadLine());

            //Console.WriteLine("{0:0.00}", miles * MilesToKilometersRatio);

        }
    }
}