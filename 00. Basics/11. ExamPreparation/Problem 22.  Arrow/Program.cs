using System;

class Program
{
    static void Main()
    {
            int n = int.Parse(Console.ReadLine());
            int width = n * 2 - 1;

            Console.WriteLine("{0}{1}{0}"
                , new string('.', n / 2)
                , new string('#', n));


            for (int i = 0; i < n - 2; i++)
            {
                Console.WriteLine("{0}#{1}#{0}"
                    , new string('.', n / 2)
                    , new string('.', width - (n / 2) * 2 - 2));
            }

            Console.WriteLine("{0}{1}{0}"
                , new string('#', n / 2 + 1)
                , new string('.', width - ((n / 2 + 1) * 2)));

            for (int i = 0; i < n - 2; i++)
            {
                Console.WriteLine("{0}#{1}#{0}"
                    , new string('.', 1 + i)
                    , new string('.', (width - 4) - (2 * i)));
            }
            Console.WriteLine("{0}#{0}",
                new string('.', (width - 1) / 2));
        
    }
}
