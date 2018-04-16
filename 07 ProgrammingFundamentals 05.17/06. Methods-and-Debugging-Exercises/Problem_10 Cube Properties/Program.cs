using System;
class Program
{
    static void Main()
    {
        double cubeSide = double.Parse(Console.ReadLine());
        string parameters = Console.ReadLine();

        double face = Math.Sqrt((cubeSide * cubeSide) * 2);
        double space = Math.Sqrt((cubeSide * cubeSide) * 3);
        double volume = cubeSide * cubeSide * cubeSide;
        double area = cubeSide*cubeSide * 6;

        if (parameters == "face")
        {

            Console.WriteLine("{0:f2}", face);
        }
        else if (parameters == "space")
        {

            Console.WriteLine("{0:f2}", space);
        }
        else if (parameters == "volume")
        {

            Console.WriteLine("{0:f2}", volume);
        }
        else if (parameters == "area")
        {
            Console.WriteLine("{0:f2}", area);
        }
    }
}