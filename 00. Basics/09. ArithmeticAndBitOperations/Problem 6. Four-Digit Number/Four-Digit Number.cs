using System;

class FourDigitNumber
{
    static void Main()
    {
        int abcd = int.Parse(Console.ReadLine());
        int a = abcd / 1000;
        int b = (abcd / 100) % 10;
        int c = (abcd / 10) % 10;
        int d = abcd % 10;
        Console.WriteLine("first {0} ,second {1} ,third {2} ,fourth {3}", a, b, c, d);
        int sumofthenumbers = a + b + c + d;

        Console.WriteLine(sumofthenumbers);
        Console.WriteLine("{3}{2}{1}{0}", a, b, c, d);  //obraten red
        Console.WriteLine("{0}{1}{2}{3}", d, a, b, c);  //poslednata na purvo
        Console.WriteLine("{0}{1}{2}{3}", a, c, b, d);  // razmenq 2 i 3 cifra

    }
}
