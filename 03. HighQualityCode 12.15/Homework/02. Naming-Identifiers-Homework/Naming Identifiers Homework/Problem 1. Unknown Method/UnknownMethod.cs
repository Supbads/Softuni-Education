namespace UnknownMethod
{
	using System;
	
    class UnknownMethod
    {
        static void Main(string[] args)
        {
            double[,] firstMatrix = new double[,] { { 1, 3 }, { 5, 7 } };
            double[,] secondMatrix = new double[,] { { 4, 2 }, { 1, 5 } };

            double[,] generatedMatrix = MultiplyMatrices(firstMatrix, secondMatrix);


            for (int row = 0; row < generatedMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < generatedMatrix.GetLength(1); col++)
                {
                    Console.Write(generatedMatrix[row, col] + " ");
                }
                Console.WriteLine();
            }

        }

        static double[,] MultiplyMatrices(double[,] firstMatrix, double[,] secondMatrix)
        {
            if (firstMatrix.GetLength(1) != secondMatrix.GetLength(0))
            {
                throw new ArgumentException("Matrices are not compatible");
            }

            var firstMatrixCols = firstMatrix.GetLength(1);
            var multipliedMatrix = new double[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];
            

            for (int i = 0; i < multipliedMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < multipliedMatrix.GetLength(1); j++)
                {
                    for (int k = 0; k < firstMatrixCols; k++)
                    {
                        multipliedMatrix[i, j] += firstMatrix[i, k]*secondMatrix[k, j];
                    }
                }
            }
            return multipliedMatrix;
        }
    }
}