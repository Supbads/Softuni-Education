using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int min = int.Parse(Console.ReadLine());
        int max = int.Parse(Console.ReadLine());
        if (min <= max)
        {
            Random rnd = new Random();
            for (int i = 1; i <= n; i++)
            {
                int number = rnd.Next(min, max+1);
                Console.WriteLine(number);
            }
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }
}
