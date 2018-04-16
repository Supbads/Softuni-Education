using System;

class MutliplicationTable
{
    //Problem 10. Multiplication Table 2.0 and Problem 9.
    static void Main(string[] args)
    {
        int numberToMultiply = int.Parse(Console.ReadLine());
        int multiplier = int.Parse(Console.ReadLine());


        int product = numberToMultiply * multiplier;

        Console.WriteLine("{0} X {1} = {2}", numberToMultiply, multiplier, product);

        for (int i = ++multiplier; i <= 10; i++)
        {
            product = numberToMultiply * i;
            Console.WriteLine("{0} X {1} = {2}",numberToMultiply, i, product);
        }
    }
}