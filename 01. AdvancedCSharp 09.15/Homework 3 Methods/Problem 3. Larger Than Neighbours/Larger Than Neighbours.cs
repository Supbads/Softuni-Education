using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LargerThanNeighbours
{
    static void Main(string[] args)
    {
        int[] numbers = (Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
        
        for(int i = 0 ; i < numbers.Length;i++)
        {
            bool isLarger = IsLargerThenNeighbours(i, numbers);
            Console.WriteLine(isLarger);
        }
    }
    private static bool IsLargerThenNeighbours(int i, int[] array)
    {
        if ((i >= 1) && (i < array.Length-1))
        {
            if ((array[i] > array[i + 1]) && (array[i] > array[i - 1]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (i == 0)
        {
            if (array[i] > array[i + 1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if(array[i]>array[i-1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}