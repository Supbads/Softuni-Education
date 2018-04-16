namespace Problem_8.Distance_in_Lab
{
    using System;

    class DistanceInLabyrinth
    {
        static string[,] matrix =
            {
                //0    1    2    3    4    5   
                /*0*/
                { "0", "0", "0", "x", "0", "x" },
                /*1*/
                { "0", "x", "0", "x", "0", "x" },
                /*2*/
                { "0", "*", "x", "0", "x", "0" },
                /*3*/
                { "0", "x", "0", "0", "0", "0" },
                /*4*/
                { "0", "0", "0", "x", "x", "0" },
                /*5*/
                { "0", "0", "0", "x", "0", "x" }
            };

        static int steps = -1;

        static void Main(string[] args)
        {
            SearchMatrixForExit(2, 1);

            SearchUnfilledCells();

            PrintMatrix(matrix);
        }

        static void SearchMatrixForExit(int row, int col)
        {
            steps++;
            
            if (!InRange(row, col))
            {
                return;
            }

            if (matrix[row, col] == "x")
            {
                return;
            }

            if (matrix[row, col] != "*")
            {
                if (matrix[row, col] != "0" && int.Parse(matrix[row,col]) < steps)
                {
                    return;
                }
                matrix[row, col] = steps.ToString();
            }
            
            SearchMatrixForExit(row, col - 1); // left
            steps--;
            SearchMatrixForExit(row + 1, col); // down
            steps--;
            SearchMatrixForExit(row, col + 1); // right
            steps--;
            SearchMatrixForExit(row - 1, col); // up
            steps--;
        }
        
        private static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < matrix.GetLength(0);
            bool colInRange = col >= 0 && col < matrix.GetLength(1);
            return rowInRange && colInRange;
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(" " + matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static void SearchUnfilledCells()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == "0")
                    {
                        matrix[i, j] = "u";
                    }
                }
            }
        }
    }
}