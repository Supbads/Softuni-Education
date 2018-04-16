using System;

public class Class1
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());

        long mask = 7 << p;
        long attempt = (n ^ mask);
        Console.WriteLine(attempt);
    }
}