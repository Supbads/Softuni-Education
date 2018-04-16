using System;

class Program
{
    static void Main()
    {
        short a = short.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());

        Console.Write("|{0, -10:X}|{1}|{2}|", a, Convert.ToString(a, 2).PadLeft(10, '0'), b.ToString().PadLeft(10, ' '));

        bool check = Convert.ToString(c).IndexOf(".") > 0;
        Console.WriteLine(check ? "{0:0.000}         |" : "{0}", c);
    }
}