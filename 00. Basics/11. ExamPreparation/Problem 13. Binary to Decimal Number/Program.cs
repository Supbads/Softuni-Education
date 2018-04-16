using System;
using System.Numerics;


class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        BigInteger numberInBinary = BigInteger.Parse(input);
        BigInteger lastBitValue = 0;
        BigInteger numberInDecimal = 0;

        for (int bitPos = 0; bitPos < input.Length; bitPos++)
        {
            lastBitValue = numberInBinary % 10;
            numberInBinary = numberInBinary / 10;
            numberInDecimal = numberInDecimal + lastBitValue * (BigInteger)Math.Pow(2, bitPos);
        }
        Console.WriteLine(numberInDecimal);
    }
}
