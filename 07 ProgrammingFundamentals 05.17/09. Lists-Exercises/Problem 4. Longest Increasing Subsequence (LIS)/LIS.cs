using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int length = array.Length;

        int[] len = new int[length];
        int[] prev = new int[length];
        prev[0] = -1;  // endless backtrack if arr[0] is present in the sequance

        int biggestLenIndex = 0;

        
        for (int i = 1; i < length; i++) //prevSelectsTheLeftmost for BackTrack
        {
            prev[i] = -1;

            int j = i - 1;

            while (j >= 0)
            {
                if (array[i] > array[j])
                {
                    if (len[i] <= len[j])
                    {
                        //len[i] = len[j] + 1; //prev[]selects the rightmost for backtrack
                        len[i] = len[j];
                        prev[i] = j;
                    }
                }

                j--;
            }

            len[i]++;

            if (len[i] > len[biggestLenIndex]) //saves another for cycle
            {
                biggestLenIndex = i;
            }
        }
        
        List<int> sequance = new List<int>();

        for (int i = biggestLenIndex; i >= 0;) //backtrack elements with prev[]
        {
            int currentElement = array[i];
            sequance.Add(currentElement);

            int previousIndex = prev[i];
            i = previousIndex;
        }

        sequance.Reverse();
        Console.WriteLine(string.Join(" ", sequance));
    }
}


//for (int i = 0; i < length; i++) // with a second for from 0 to i
//{
//    len[i] = 1;
//    prev[i] = -1;

//    for (int j = 0; j < i; j++)
//    {
//        if (array[j] < array[i] && len[j] >= len[i])
//        {
//            len[i] = len[j] + 1;
//            prev[i] = j;
//        }
//    }

//    if (len[i] > len[biggestLenIndex])
//    {
//        biggestLenIndex = i;
//    }

//}