namespace Problem_2.Areas_in_Matrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static int areasCounter;

        private static bool[,] visited;

        private static char[][] matrix;

        static void Main()
        {
            ReadInput();
            var areasOfMatrix = GetAreasForMatrix(matrix);
            Print(areasOfMatrix);
        }

        private static void ReadInput()
        {
            var tokens = Console.ReadLine().Split(' ');
            var rows = int.Parse(tokens[tokens.Length - 1]);
            matrix = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                var row = Console.ReadLine().ToCharArray();
                matrix[i] = new char[row.Length];
                matrix[i] = row;
            }
        }

        private static List<Area> GetAreasForMatrix(char[][] matrix)
        {
            areasCounter = 0;
            List<Area> currentMatrixAreas = new List<Area>();

            visited = new bool[matrix.GetLength(0), matrix[0].Length];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (!visited[i, j])
                    {
                        areasCounter++;
                        Area currentArea = new Area { Letter = matrix[i][j], Number = areasCounter, StartX = i, StartY = j };
                        TraversePosition(matrix, i, j, currentArea);
                        if (currentArea.Length == 0)
                        {
                            areasCounter--;
                            continue;
                        }

                        currentMatrixAreas.Add(currentArea);
                    }
                }
            }

            return currentMatrixAreas;
        }
        
        private static void TraversePosition(char[][] matrix, int i, int j, Area area)
        {
            if (!IsInRange(matrix, i, j))
            {
                return;
            }

            if (visited[i, j])
            {
                return;
            }

            if (matrix[i][j] != area.Letter)
            {
                //visited[i, j] = true;
                return;
            }

            area.Length++;
            visited[i, j] = true;

            area.Cells.Add(new Cell(i, j));

            TraversePosition(matrix, i + 1, j, area);
            TraversePosition(matrix, i, j + 1, area);
            TraversePosition(matrix, i - 1, j, area);
            TraversePosition(matrix, i, j - 1, area);
        }

        private static bool IsInRange(char[][] matrix, int i, int j)
        {
            return i >= 0 && i < matrix.GetLength(0) && j >= 0 && j < matrix[i].Length;
        }

        private static void Print(List<Area> areas)
        {
            //Console.WriteLine("Total areas found: {0}", areas.Count);
            //foreach (Area area in areas)
            //{
            //    Console.WriteLine("Area #{0} at ({1}, {2}), size: {3}", area.Number, area.StartX, area.StartY, area.Length);
            //}

            Console.WriteLine("Areas: {0}", areas.Count);
            var byLetter = areas.GroupBy(a => a.Letter).OrderBy(a => a.Key);
            foreach (var something in byLetter)
            {
                Console.WriteLine("Letter '" + something.Key + "' -> " + something.Count());
            }
        }
    }
}
