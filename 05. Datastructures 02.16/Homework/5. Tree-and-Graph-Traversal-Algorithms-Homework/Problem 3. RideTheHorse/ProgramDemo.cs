namespace _03.RideTheHorse
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ProgramDemo
    {
        private static int[,] matrix;
        private static Queue<HoursePointer> queue = new Queue<HoursePointer>();

        private static int rows;
        private static int cols;

        public static void Main()
        {
            rows = int.Parse(Console.ReadLine());
            cols = int.Parse(Console.ReadLine());

            int hourseRow = int.Parse(Console.ReadLine());
            int hourseCol = int.Parse(Console.ReadLine());

            BuildHorseMovemantMatrix(hourseRow, hourseCol);

            PrintMatrix();

            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine(matrix[i, matrix.GetLength(1) / 2]);
            }
        }

        private static void PrintMatrix()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void BuildHorseMovemantMatrix(int hourseRow, int hourseCol)
        {
            matrix = new int[rows, cols];
            FillTheMatrix();
            matrix[hourseRow, hourseCol] = 1;

            var startPoint = new HoursePointer(hourseRow, hourseCol, 1);

            queue.Enqueue(startPoint);

            while (queue.Count > 0)
            {
                var currentPosition = queue.Dequeue();
                AddNewPosition(currentPosition);
            }
        }

        private static void AddNewPosition(HoursePointer currentPosition)
        {
            int currentX = currentPosition.X;
            int currentY = currentPosition.Y;
            int currentValue = currentPosition.Value;

            int value = currentValue + 1;

            int x = currentX - 2;
            int y = currentY - 1;
            DoMovement(x, y, value);
            
            y = currentY + 1;
            DoMovement(x, y, value);
            
            x = currentX - 1;
            y = currentY - 2;
            DoMovement(x, y, value);

            y = currentY + 2;
            DoMovement(x, y, value);

            x = currentX + 1;
            y = currentY - 2;
            DoMovement(x, y, value);

            y = currentY + 2;
            DoMovement(x, y, value);

            x = currentX + 2;
            y = currentY - 1;
            DoMovement(x, y, value);

            y = currentY + 1;
            DoMovement(x, y, value);
        }

        private static void DoMovement(int x, int y, int value)
        {
            if (IsInMatrix(x, y) && matrix[x, y] == 0)
            {
                queue.Enqueue(new HoursePointer(x, y, value));
                matrix[x, y] = value;
            }
        }

        private static bool IsInMatrix(int x, int y)
        {
            bool checkRow = 0 <= x && x < rows;
            bool checkCol = 0 <= y && y < cols;

            return checkRow && checkCol;
        }

        private static void FillTheMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = 0;
                }
            }
        }

        private class HoursePointer
        {
            public HoursePointer(int x, int y, int value)
            {
                this.X = x;
                this.Y = y;
                this.Value = value;
            }

            public int X { get; set; }
            public int Y { get; set; }
            public int Value { get; set; }
        }
    }
}
