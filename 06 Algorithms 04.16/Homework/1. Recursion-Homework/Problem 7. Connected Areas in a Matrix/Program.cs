namespace Problem_7.Connected_Areas_in_a_Matrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    class Program
    {
        private static int areasCounter;

        private static bool[,] visited;

        private static readonly char[,] firstMatrix =
        {
            { ' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ' },
            { ' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ' },
            { ' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ' },
            { ' ', ' ', ' ', ' ', '*', ' ', '*', ' ', ' ' }
        };

        private static readonly char[,] secondMatrix =
        {
            { '*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' ' },
            { '*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' ' },
            { '*', ' ', ' ', '*', '*', '*', '*', '*', ' ', ' ' },
            { '*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' ' },
            { '*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' ' }
        };

        static void Main()
        {
            //Should've merged the '*' with visited
            var areasOfFirstMatrix = GetAreasForMatrix(firstMatrix);
            var areasOfSecondMatrix = GetAreasForMatrix(secondMatrix);

            Print(areasOfFirstMatrix);
            Print(areasOfSecondMatrix);
        }

        private static List<Area> GetAreasForMatrix(char[,] matrix)
        {
            areasCounter = 0;
            List<Area> currentMatrixAreas = new List<Area>();

            visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (!visited[i, j])
                    {
                        areasCounter++;
                        Area currentArea = new Area { Number = areasCounter, StartX = i, StartY = j };
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

        //private static void TraversePosition(char[,] matrix, int i, int j, Area area)//iterative bfs attempt
        //{
        //    var cellsToVisit = new Queue<Cell>();

        //    cellsToVisit.Enqueue(new Cell(i, j));

        //    while (cellsToVisit.Count > 0)
        //    {
        //        var cell = cellsToVisit.Dequeue();
        //        area.Length++;
        //        var cellX = cell.X;
        //        var cellY = cell.Y;
        //        visited[cellX, cellY] = true;
        //        //area.Cells.Add(cell);
                

        //        if (cellX - 1 >= 0 && matrix[cellX - 1, cellY] != '*' && !visited[cellX - 1, cellY])
        //        {
        //            visited[cellX - 1, cellY] = true;
        //            cellsToVisit.Enqueue(new Cell(cellX - 1, cellY));
        //        }

        //        if (cellY - 1 >= 0 && matrix[cellX, cellY - 1] != '*' && !visited[cellX, cellY - 1])
        //        {
        //            visited[cellX, cellY - 1] = true;
        //            cellsToVisit.Enqueue(new Cell(cellX, cellY - 1));
        //        }

        //        if (cellX + 1 < matrix.GetLength(0) && matrix[cellX + 1, cellY] != '*' && !visited[cellX + 1, cellY])
        //        {
        //            visited[cellX + 1, cellY] = true;
        //            cellsToVisit.Enqueue(new Cell(cellX + 1, cellY));
        //        }

        //        if (cellY + 1 < matrix.GetLength(1) && matrix[cellX, cellY + 1] != '*' && !visited[cellX, cellY + 1])
        //        {
        //            visited[cellX, cellY + 1] = true;
        //            cellsToVisit.Enqueue(new Cell(cellX, cellY + 1));
        //        }
        //    }
        //}

        private static void TraversePosition(char[,] matrix, int i, int j, Area area) //bfs attempt
        {
            if (!IsInRange(matrix, i, j))
            {
                return;
            }

            if (visited[i, j])
            {
                return;
            }

            if (matrix[i, j] == '*')
            {
                visited[i, j] = true;
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

        private static bool IsInRange(char[,] matrix, int i, int j)
        {
            return i >= 0 && i < matrix.GetLength(0) && j >= 0 && j < matrix.GetLength(1);
        }

        private static void Print(List<Area> areas)
        {
            Console.WriteLine("Total areas found: {0}", areas.Count);
            foreach (Area area in areas)
            {
                Console.WriteLine("Area #{0} at ({1}, {2}), size: {3}", area.Number, area.StartX, area.StartY, area.Length);
            }
        }
    }
}