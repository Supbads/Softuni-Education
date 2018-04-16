using System;

class MatrixOfPalindromes
{
    static void Main()
    {
        Console.WriteLine("Enter numbers of row and col of matrix:");
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        int[,] arrayMatrix = new int[n, m];
        char firstLetter = 'a';
        for (char i = 'a'; i <= firstLetter + n - 1; i++)
        {
            for (char j = i; j < i + m; j++)
            {
                string letters = i.ToString() + j.ToString() + i.ToString();
                Console.Write("{0} ", letters);
            }
            Console.WriteLine();
        }
    }
}