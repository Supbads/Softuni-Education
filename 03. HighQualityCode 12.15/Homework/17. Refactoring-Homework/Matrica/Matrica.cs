namespace Matrix
{
    using System;
    
    public class Matrix
    {
        private static void Main()
        {
            Console.WriteLine("Enter a positive number ");
            string input = Console.ReadLine();
            int number;
            while (!int.TryParse(input, out number) || number < 0 || number > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }

            int[,] matrix = new int[number, number];
            int value = 1;
            int currentRow = 0;
            int currentCol = 0;
            int directionX = 1;
            int directionY = 1;

            while (true)
            {
                matrix[currentRow, currentCol] = value;

                if (!CheckCell(matrix, currentRow, currentCol))
                {
                    break;
                }

                while (currentRow + directionX >= number || currentRow + directionX < 0 || currentCol + directionY >= number || currentCol + directionY < 0 || matrix[currentRow + directionX, currentCol + directionY] != 0)
                {
                    Change(ref directionX, ref directionY);
                }

                currentRow += directionX;
                currentCol += directionY;
                value++;
            }

            FindCell(matrix, out currentRow, out currentCol);
            if (currentRow != 0 && currentCol != 0)
            {
                directionX = 1;
                directionY = 1;

                while (true)
                {
                    matrix[currentRow, currentCol] = value;
                    if (!CheckCell(matrix, currentRow, currentCol))
                    {
                        break;
                    }
                   
                    while (currentRow + directionX >= number || currentRow + directionX < 0 || currentCol + directionY >= number || currentCol + directionY < 0 || matrix[currentRow + directionX, currentCol + directionY] != 0)
                    {
                        Change(ref directionX, ref directionY);
                    }

                    currentRow += directionX;
                    currentCol += directionY;
                    value++;
                }
            }

            for (int row = 0; row < number; row++)
            {
                for (int col = 0; col < number; col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static void Change(ref int dX, ref int dY)
        {
            int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int cd = 0;
            for (int count = 0; count < directionsX.Length; count++)
            {
                if (directionsX[count] == dX && directionsY[count] == dY)
                {
                    cd = count;
                    break;
                }
            }

            if (cd == 7)
            {
                dX = directionsX[0];
                dY = directionsY[0];
                return;
            }

            dX = directionsX[cd + 1];
            dY = directionsY[cd + 1];
        }

        private static bool CheckCell(int[,] arr, int x, int y)
        {
            int[] directionX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < directionX.Length; i++)
            {
                if (x + directionX[i] >= arr.GetLength(0) || x + directionX[i] < 0)
                {
                    directionX[i] = 0;
                }

                if (y + directionY[i] >= arr.GetLength(0) || y + directionY[i] < 0)
                {
                    directionY[i] = 0;
                }
            }

            for (int i = 0; i < directionX.Length; i++)
            {
                if (arr[x + directionX[i], y + directionY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static void FindCell(int[,] board, out int x, out int y)
        {
            x = 0;
            y = 0;
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(0); col++)
                {
                    if (board[row, col] == 0)
                    {
                        x = row;
                        y = col;
                        return;
                    }
                }
            }
        }
    }
}