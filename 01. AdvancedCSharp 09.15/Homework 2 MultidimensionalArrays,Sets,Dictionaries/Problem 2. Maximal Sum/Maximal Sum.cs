using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MaximalSum
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string[] shape = input.Split();
        int rows = int.Parse(shape[0]);
        int cols = int.Parse(shape[1]);

        int[,] matrix = new int[rows, cols];

        FillMatrix(matrix);

        int biggestSum = int.MinValue;
        int rowHolder = 0;
        int colHolder = 0;
        for (int i = 0; i < matrix.GetLength(0)-2; i++)
        {
            for (int j = 0; j < matrix.GetLength(1)-2; j++)
            {

                if (BiggestSumCheck(matrix, biggestSum, i, j))
                {
                    biggestSum = currentSum;
                    rowHolder = i;
                    colHolder = j;
                }
            }
        }

        Console.WriteLine("Sum = " + biggestSum);

        Console.WriteLine();

        for (int i = rowHolder; i < rowHolder+3 ; i++)
        {
            for (int j = colHolder; j < colHolder+3; j++)
            {
                Console.Write("{0}  ", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
    static int currentSum;

     static bool BiggestSumCheck(int[,] matrix, int biggestSum, int i, int j)
    {
        currentSum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] + matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2] + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];

        if (currentSum > biggestSum)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

     static void FillMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            string[] numbers = Console.ReadLine().Split(' ');
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = int.Parse(numbers[col]);
            }
        }
    }
}
