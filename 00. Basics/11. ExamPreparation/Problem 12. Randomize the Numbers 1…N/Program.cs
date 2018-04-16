using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];

        for (int i = 0 ; i<numbers.Length ; i++)
        {
            numbers[i] = i + 1;
        }

        Random rnd = new Random();
        int[] randomized = numbers.OrderBy(x => rnd.Next()).ToArray();
        foreach (var item in randomized)
        {
            Console.Write("{0} ", item);
        }
    }
}
