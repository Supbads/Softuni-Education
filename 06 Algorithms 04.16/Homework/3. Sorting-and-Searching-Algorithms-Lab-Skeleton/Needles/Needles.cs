using System;
using System.Linq;

namespace _08Needles
{
    public class Needles
    {
        public static void Main(string[] args)
        {
            string tokens = Console.ReadLine();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] needles = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < needles.Length; i++)
            {
                int zeroes = 0;
                bool isFound = false;
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (needles[i] <= numbers[j])
                    {
                        Console.Write(j - zeroes + " ");
                        isFound = true;
                        break;
                    }

                    if (numbers[j] == 0)
                    {
                        zeroes++;
                    }
                    else
                    {
                        zeroes = 0;
                    }
                }
                if (!isFound)
                {
                    Console.Write(numbers.Length - zeroes + " ");
                }
            }

            Console.WriteLine();
        }
    }
}


// namespace Needles
// {
    // using System;
    // using System.Collections.Generic;
    // using System.Linq;

    // public class Needles
    // {
        // static void Main(string[] args)
        // {
            // int[] arguments = Console.ReadLine().Split().Select(int.Parse).ToArray();
            // int collectionCount = arguments[0];
            // int numbersToInsertCount = arguments[1];

            // int[] collection = Console.ReadLine().Split().Select(int.Parse).ToArray();
            // int[] numbersToInsert = Console.ReadLine().Split().Select(int.Parse).ToArray();

            // List<int> indexes = new List<int>();

            // for (int num = 0; num < numbersToInsertCount; num++)
            // {
                // bool solutionFount = false;
                // for (int current = 0; current < collectionCount; current++)
                // {
                    // if (collection[current] != 0 && collection[current] >= numbersToInsert[num])
                    // {
                        // int index = RetraseIndex(current, collection);
                        // indexes.Add(index);
                        // solutionFount = true;
                        // break;
                    // }
                // }

                // if (!solutionFount)
                // {
                    // int index = RetraseIndex(collectionCount, collection);
                    // indexes.Add(index);
                // }
            // }

            // Console.WriteLine(string.Join(" ", indexes));
        // }

        // private static int RetraseIndex(int index, int[] collection)
        // {
            // while (index > 0 && collection[index - 1] == 0)
            // {
                // index--;
            // }

            // return index;
        // }
    // }
// }
