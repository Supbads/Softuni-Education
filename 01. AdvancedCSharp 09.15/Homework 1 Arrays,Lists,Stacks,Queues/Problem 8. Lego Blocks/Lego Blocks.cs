using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class LegoBlocks
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        //string[][] firstArray = new string[n][];
        //string[][] secondArray = new string[n][];
        string[][] firstArray = ReadAndFillJaggetArray(n);
        string[][] secondArray = ReadAndFillJaggetArray(n);

        //FillArrays(n, firstArray, secondArray);

        int countCol = firstArray[0].Length + secondArray[0].Length;
        int count = 1;

        for (int i = 1; i < n; i++)
        {
            if (firstArray[i].Length + secondArray[i].Length == countCol)
            {
                count++;
            }
        }

        if (count == n)
        {
            string[][] merged = new string[n][];

            for (int i = 0; i < n; i++)
            {
                Array.Reverse(secondArray[i]);  //string output = new string(input.ToCharArray().Reverse().ToArray());
            }

            for (int i = 0; i < firstArray.GetLength(0); i++)
            {
                merged[i] = new string[countCol];
                for (int j = 0; j < countCol; j++)
                {
                    if (j < firstArray[i].Length)
                    {
                        merged[i][j] = firstArray[i][j];
                    }
                    else
                    {
                        merged[i][j] = secondArray[i][j - firstArray[i].Length];  //[j - firstNumbers[i].Length]; 
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("[{0}]", string.Join(", ", merged[i]));
            }
        }
        else
        {
            int cells = 0;
            for (int i = 0; i < n; i++)
            {
                cells += firstArray[i].Length + secondArray[i].Length;
            }
            Console.WriteLine("The total number of cells is: {0}", cells);
        }
    }

    static string[][] ReadAndFillJaggetArray(int n)
    {
        string[][] array = new string[n][];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                string input = Console.ReadLine();
                input = Regex.Replace(input, @"\s+", " ").Trim();
                string[] inputNumbers = input.Split(' ');
                array[i] = new string[inputNumbers.Length];

                for (int j = 0; j < inputNumbers.Length; j++)
                {
                    array[i][j] = inputNumbers[j];
                }
            }
        return array;
    }
}

//static void FillArrays(int input, string[][] firstArray, string[][] secondArray)
//{
//    for (int i = 0; i < 2 * input; i++)
//    {
//        if (i < input)
//        {

//            firstArray[i] = Console.ReadLine().Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
//        }
//        else
//        {
//            string str = Console.ReadLine();
//            str.Reverse();
//            secondArray[i] = str.Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
//        }
//    }
//}