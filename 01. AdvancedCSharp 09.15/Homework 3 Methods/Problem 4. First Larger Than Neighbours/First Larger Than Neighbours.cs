using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FirstLargerThanNeighbours
{
    static void Main(string[] args)
    {
        //int[] sequanceOne = (Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
        //int[] sequanceTwo = (Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
        //int[] sequanceThree = (Console.ReadLine().Split(' ').Select(int.Parse).ToArray());

        int[] sequanceOne = { 1, 3, 4, 5, 1, 0, 5 };
        int[] sequanceTwo = { 1,2,3,4,5,6,6 };
        int[] sequanceThree = {1,1,1 };

        Console.WriteLine(GetIndexOfFirstElementLargerThanNeighbours(sequanceOne));
        Console.WriteLine(GetIndexOfFirstElementLargerThanNeighbours(sequanceTwo));
        Console.WriteLine(GetIndexOfFirstElementLargerThanNeighbours(sequanceThree));
    }
    static int GetIndexOfFirstElementLargerThanNeighbours(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            bool isLarger = IsLargerThenNeighbours(i, array);
            if(isLarger==true)
            {
                return i;
            }
        }
        return -1;
    }

    private static bool IsLargerThenNeighbours(int i, int[] array)
    {
        if ((i >= 1) && (i < array.Length - 1))
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
            if (array[i] > array[i - 1])
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