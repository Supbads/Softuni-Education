using System;

class BitwiseExtract3rdBit
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int p = 3;
        int nRightP = number >> p;   
        int bit = nRightP & 1; 
        Console.WriteLine(bit);
    }
}
