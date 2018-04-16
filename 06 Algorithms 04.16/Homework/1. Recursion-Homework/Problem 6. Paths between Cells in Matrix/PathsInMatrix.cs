using System;
using System.Collections.Generic;
using System.Linq;

class PathsInMatrix
{

    static SortedDictionary<int, char[,]> pathsLengthAndMatrix = new SortedDictionary<int, char[,]>();

    static char[,] matrix =
    {
        //0    1    2    3    4    5    6    7    8    9   10   11   12   13   14   15
  /*0*/  {'S', ' ', '*', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*', ' ', ' ', ' ', },
  /*1*/  {'*', ' ', '*', '*', '*', '*', '*', ' ', '*', '*', '*', ' ', '*', '*', '*', ' ', },
  /*2*/  {'*', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*', ' ', ' ', ' ', ' ', ' ', ' ', ' ', },
  /*3*/  {'*', ' ', '*', '*', '*', ' ', '*', ' ', '*', '*', '*', '*', '*', '*', ' ', '*', },
  /*4*/  {'*', ' ', '*', ' ', ' ', ' ', '*', ' ', ' ', ' ', ' ', ' ', ' ', '*', ' ', ' ', },
  /*5*/  {'*', ' ', '*', ' ', '*', '*', '*', '*', '*', '*', ' ', '*', ' ', '*', '*', ' ', },
  /*6*/  {'*', ' ', '*', ' ', '*', ' ', ' ', ' ', ' ', ' ', ' ', '*', ' ', ' ', ' ', ' ', },
  /*7*/  {' ', ' ', ' ', ' ', '*', ' ', '*', '*', '*', '*', ' ', '*', ' ', '*', '*', '*', },
  /*8*/  {'*', '*', '*', ' ', '*', ' ', ' ', 'e', ' ', ' ', ' ', '*', ' ', '*', ' ', '*', },
  /*9*/  {' ', ' ', ' ', ' ', '*', ' ', '*', ' ', '*', '*', ' ', ' ', ' ', '*', ' ', ' ', },
  /*10*/ {' ', '*', '*', '*', '*', ' ', '*', ' ', '*', ' ', ' ', '*', ' ', '*', '*', ' ', },
  /*11*/ {' ', '*', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*', '*', '*', ' ', ' ', ' ', ' ', },
  /*12*/ {' ', '*', '*', '*', ' ', '*', ' ', '*', '*', '*', ' ', ' ', ' ', '*', '*', '*', },
  /*13*/ {' ', ' ', ' ', '*', ' ', '*', ' ', '*', ' ', ' ', ' ', '*', ' ', '*', ' ', ' ', },
  /*14*/ {' ', '*', ' ', '*', '*', '*', ' ', '*', '*', '*', ' ', '*', ' ', '*', '*', ' ', },
  /*15*/ {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*', ' ', ' ', ' ', ' ', },
    };

    static List<string> moves = new List<string>();
    static bool exitFound = false;
    static int pathsFound = 0;
    static int steps = -1;

    static void Main(string[] args)
    {
        SearchMatrixForExit(0, 0, "S");
        if (!exitFound)
        {
            Console.WriteLine("No paths were found.");
            return;
        }
        
        Console.WriteLine(pathsFound);
        int counter = 1;
        Console.WriteLine("Paths found: {0}", pathsFound);
        foreach (var item in pathsLengthAndMatrix)
        {
            Console.WriteLine(counter + "th path");
            for (int row = 0; row < item.Value.GetLength(0); row++)
            {
                for (int col = 0; col < item.Value.GetLength(1); col++)
                {
                    Console.Write(item.Value[row, col]);
                }

                Console.WriteLine();
            }

            Console.WriteLine("Steps: " + item.Key);
            counter++;
            Console.WriteLine();
            //return; //uncomment to see only the first path (fastest)
        }
    }

    static void SearchMatrixForExit(int row, int col, string direction)
    {
        steps++;
        //if (steps > getCurrentSmallestPath(pathsLengthAndMatrix)) // to optimize
        //{
        //    return;
        //}

        if (!InRange(row, col))
        {
            return;
        }

        if (matrix[row, col] == 'e')
        {
            exitFound = true;
            pathsFound++;
            //PrintCurrentPath(moves);
            //PrintMatrix(matrix);
            if (!pathsLengthAndMatrix.ContainsKey(steps))
            {
                char[,] clonedMatrix = (char[,])matrix.Clone();
                pathsLengthAndMatrix.Add(steps, clonedMatrix);
            }
            return;
        }

        if (matrix[row, col] == '*' || matrix[row, col] == 'x')
        {
            return;
        }

        matrix[row, col] = 'x';
        //moves.Add(direction);

        SearchMatrixForExit(row, col + 1, "R"); // right
        steps--;
        SearchMatrixForExit(row + 1, col, "D"); // down
        steps--;
        SearchMatrixForExit(row, col - 1, "L"); // left
        steps--;
        SearchMatrixForExit(row - 1, col, "U"); // up
        steps--;

        matrix[row, col] = ' ';  //clean current path
        //moves.RemoveAt(moves.Count - 1); //clean moves listed
    }

    private static int getCurrentSmallestPath(SortedDictionary<int, char[,]> dictionary)
    {
        bool isEmpty = dictionary.Count == 0;
        if (isEmpty)
        {
            return int.MaxValue;
        }
        //int steps = 0;
        //foreach (KeyValuePair<int, char[,]> item in dictionary)
        //{
        //    steps = item.Key;
        //    break;
        //}
        
        return dictionary.First().Key;
    }

    static void PrintCurrentPath(List<string> moves)
    {
        foreach (var move in moves)
        {
            Console.Write(move);
        }
        Console.WriteLine();
    }
    static bool InRange(int row, int col)
    {
        bool rowInRange = row >= 0 && row < matrix.GetLength(0);
        bool colInRange = col >= 0 && col < matrix.GetLength(1);
        return rowInRange && colInRange;
    }
    static void PrintMatrix(char[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }

    }
}
