using System;

namespace Problem_5.BitArray
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BitArray dsa = new BitArray(30);
                dsa[4] = 1;
                dsa[27] = 1;
                dsa[16] = 1;
                Console.WriteLine(dsa);
                dsa[15] = 4;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
