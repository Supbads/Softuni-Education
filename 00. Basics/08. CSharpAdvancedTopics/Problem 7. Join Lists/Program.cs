using System;
using System.Collections.Generic;

class JoinLists
{
    static void Main()
    {
        List<string> numbersOne = new List<string>();
        string[] firstNumbers = Console.ReadLine().Split();
        for (int i = 0; i < firstNumbers.Length; i++)
        {
            numbersOne.Add(firstNumbers[i]);
        }

        List<string> numbersTwo = new List<string>();

        string[] secondNumbers = Console.ReadLine().Split();
        for (int i = 0; i < secondNumbers.Length; i++)
        {
            numbersTwo.Add(secondNumbers[i]);
        }
        for (int i = 0; i < firstNumbers.Length; i++)
        {
            if (!numbersTwo.Contains(numbersOne[i]))
            {
                numbersTwo.Add(numbersOne[i]);
            }
            else
            {
                continue;
            }
        }
        numbersTwo.Sort();
        foreach (var item in numbersTwo)
        {
            Console.Write("{0} ", item);
        }
        Console.WriteLine();
    }
}