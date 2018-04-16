using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int arrlength = numbers.Length;

        if (arrlength == 1)
        {
            Console.WriteLine(numbers[0]);
            return;
        }


        int biggestSequanceLength = 1;
        int biggestSequanceIndex = 0;

        for (int i = 1; i < arrlength; i++)
        {
            int currentSequanceLength = 1;

            while (i < arrlength && numbers[i] == numbers[i - 1])
            {
                currentSequanceLength++;
                i++;
            }

            if (currentSequanceLength > biggestSequanceLength)
            {
                biggestSequanceLength = currentSequanceLength;
                biggestSequanceIndex = i - 1;
            }
        }


        int biggestSequanceCharacter = numbers[biggestSequanceIndex];

        for (int i = 0; i < biggestSequanceLength; i++)
        {
            Console.Write(biggestSequanceCharacter + " ");
        }
    }
}