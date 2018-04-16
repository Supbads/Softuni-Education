using System;

class ExtractBitFromInteger
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        int nRightP = number >> p;
        int bit = nRightP & 1;
        Console.WriteLine(bit);

    }
}
