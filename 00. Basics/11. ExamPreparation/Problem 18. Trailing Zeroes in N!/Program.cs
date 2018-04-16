using System;
using System.Numerics;

class Program
{
    static void Main()
    {

        int a = int.Parse(Console.ReadLine());
        BigInteger factorial = 1;
        int counter = 0;

        for(int i = a; i>0 ; i--)
        {
            factorial *= a;
            a--;

        }
        
        while(factorial%10==0)
        {
            counter++;
            factorial /= 10;
        }
        Console.WriteLine(counter);
    }
}
