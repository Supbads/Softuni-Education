using System;

class Program
{
    static void Main()
    {
        uint n = uint.Parse(Console.ReadLine());
        for (int i = 1; i<=n;i++)
        {
            if (i % 3 == 0 || i % 7 == 0)
            {

            }
            else
            {
                Console.Write(i + " ");
            }
        }

    }
}
