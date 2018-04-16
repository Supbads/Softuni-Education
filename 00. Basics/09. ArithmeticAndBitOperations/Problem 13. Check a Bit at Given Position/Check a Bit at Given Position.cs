using System;

class CheckaBitAtGivenPosition
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        int nRightP = number >> p;
        int bit = nRightP & 1;
        if (bit == 1)
        {
            Console.WriteLine(true);
        }
        else
        {
            Console.WriteLine(false);
        }
    }
}
