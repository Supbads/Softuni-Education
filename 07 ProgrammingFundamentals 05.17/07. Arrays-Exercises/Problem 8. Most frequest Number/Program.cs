using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        ushort[] array = Console.ReadLine().Split(' ').Select(ushort.Parse).ToArray();
        int[] count = new int[65536];

        foreach (ushort num in array)
        {
            count[num]++;
        }

        int maxValue = count.Max();

        for (int i = 0; i < array.Length; i++)
        {
            if (count[array[i]] == maxValue)
            {
                Console.WriteLine(array[i]);
                return;
            }
        }
    }
}