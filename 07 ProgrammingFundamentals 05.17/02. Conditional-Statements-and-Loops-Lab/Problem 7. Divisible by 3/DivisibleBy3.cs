using System;
using System.Collections.Generic;

class DivisibleBy3
{
    static void Main()
    {
        List<int> numbersDivisibleBy3 = new List<int>();

        for (int i = 3; i < 100; i+=3)
        {
            Console.WriteLine(i);
        }
    }
}