using System;

class PrintTheASCIITable
{
    static void Main()
    {
        for (int i = 0; i <= 255; i++)
        {
            char d = (char)i;
            Console.WriteLine(d);
        }
    }
}