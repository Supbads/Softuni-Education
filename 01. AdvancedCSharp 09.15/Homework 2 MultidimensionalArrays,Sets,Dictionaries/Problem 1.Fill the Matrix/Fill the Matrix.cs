using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FillTheMatrix
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[,] firstPattern = new int[n, n];
        int[,] secondPattern = new int[n, n];

        DrawFirstPattern(n, firstPattern);
        DrawSecondPattern(n, secondPattern);

    }

    private static void DrawSecondPattern(int n, int[,] secondPattern)
    {
        int countSecond = 1;
        int count = 1;

        for (int i = 0; i < n; i++)
        {
            if (count % 2 == 0)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    secondPattern[j, i] = countSecond;
                    countSecond++;
                }
            }
            else
            {
                for (int j = 0; j < n; j++)
                {
                    secondPattern[j, i] = countSecond;
                    countSecond++;
                }
            }

            count++;
        }

        Console.WriteLine();
        Console.WriteLine("Second Pattern");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0}   ", secondPattern[i, j]);
            }
            Console.WriteLine();
        }
    }

    private static void DrawFirstPattern(int n, int[,] firstPattern)
    {
        int countFirst = 1;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                firstPattern[j, i] = countFirst;
                countFirst++;
            }
        }

        Console.WriteLine("First Pattern");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0}   ", firstPattern[i, j]);
            }
            Console.WriteLine();
        }
    }
}
