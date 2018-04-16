using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MatrixShuffling
{
    static void Main(string[] args)
    {
        int inputRows = int.Parse(Console.ReadLine());
        int inputCols = int.Parse(Console.ReadLine());
        string[,] matrix = new string[inputCols, inputCols];

        FillMatrix(inputRows, inputCols, matrix);

        string command = Console.ReadLine();
        string[] test = CheckIfCommandisValid(command);

        while (command != "END")
        {
            string temp = "";
            string[] commands = command.Split(' ');

            int firstRowsToSwap = int.Parse(commands[1]);
            int firstColsToSwap = int.Parse(commands[2]);
            int secondRowsToSwap = int.Parse(commands[3]);
            int secondColsToSwap = int.Parse(commands[4]);
            //to check index out of range
            if (ValidInputs(matrix, firstRowsToSwap, firstColsToSwap)
                &&
                (ValidInputs(matrix, secondRowsToSwap, secondColsToSwap)))
            {
                temp = matrix[firstRowsToSwap, firstColsToSwap];
                matrix[firstRowsToSwap, firstColsToSwap] = matrix[secondRowsToSwap, secondColsToSwap];
                matrix[secondRowsToSwap, secondColsToSwap] = temp;

                PrintSwapped(matrix, temp, firstRowsToSwap, firstColsToSwap);
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }

            command = Console.ReadLine();
            test = CheckIfCommandisValid(command);
        }
    }

    private static void PrintSwapped(string[,] matrix, string temp, int firstRowsToSwap, int firstColsToSwap)
    {
        Console.WriteLine("(After swapping {0} and {1})\n", temp, matrix[firstRowsToSwap, firstColsToSwap]);
        PrintMatrix(matrix);
    }

    public static string[] CheckIfCommandisValid(string command)
    {
        string[] test = command.Split(' ');

        while (!(test[0] == "swap" && test.Length == 5))
        {
            Console.WriteLine("Invalid input!");
            command = Console.ReadLine();
            test = command.Split(' ');
        }

        return test;
    }

    public static void PrintMatrix(string[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("{0} ", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }

    public static void FillMatrix(int inputRows, int inputCols,string[,] matrix)
    {
        for (int i = 0; i < inputRows; i++)
        {
            for (int j = 0; j < inputCols; j++)
            {
                matrix[i, j] = Console.ReadLine();
            }
        }
    }
    static bool ValidInputs(string[,] matrix, int row, int col)
    {
        if (row >= 0 && row < matrix.GetLength(0))
        {
            if (col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }
        }
        return false;
    }

}