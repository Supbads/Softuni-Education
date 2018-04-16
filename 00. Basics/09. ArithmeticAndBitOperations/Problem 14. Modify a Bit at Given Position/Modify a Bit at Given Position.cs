using System;

class ModifyABitAtGivenPosition
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        byte v = byte.Parse(Console.ReadLine());

        int switchedBit = 0;
        int switchedV = 0;

        if (v == 1)
        {
            switchedV = 0;
            int mask = ((int)v << p);
            switchedBit = number | mask;
        }

        else if (v == 0)
        {
            switchedV = 1;
            int mask = ~((int)switchedV << p);
            switchedBit = number & mask;
        }

        Console.WriteLine(switchedBit);
    }
}
