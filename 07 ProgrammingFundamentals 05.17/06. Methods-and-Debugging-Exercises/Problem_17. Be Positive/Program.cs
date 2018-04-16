using System;
using System.Collections.Generic;
using System.Linq;

public class BePositive_broken
{
    public static void Main()
    {
        int countSequences = int.Parse(Console.ReadLine());

        for (int i = 0; i < countSequences; i++)
        {
            int[] numbers = Console.ReadLine().Split(new[]{' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            List<int> numbersToPrint = new List<int>();

            bool found = false;

            for (int j = 0; j < numbers.Length; j++)
            {
                int currentNum = numbers[j];

                if (currentNum >= 0)
                {
                    numbersToPrint.Add(currentNum);

                    found = true;
                }
                else
                {
                    if (j < numbers.Length - 1)
                    {
                        currentNum += numbers[j + 1];
                        j++;
                    }

                    if (currentNum >= 0)
                    {
                        numbersToPrint.Add(currentNum);

                        found = true;
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("(empty)");
            }
            else
            {
                Console.WriteLine(string.Join(" ", numbersToPrint));
            }
            
        }
    }
}