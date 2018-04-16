using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        if (n >= 1 && n <= 20)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = i; j < n+i; j++)
                {
                    Console.Write("{0,3}", j);
                }
                Console.WriteLine();
            }

        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }
}
