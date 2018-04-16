using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2.Command_Interpreter
{
    class Program
    {
        static void Main()
        {
            var arr = Console.ReadLine().Split().ToArray();
            int length = arr.Length;

            var input = Console.ReadLine();

            while (input != "end")
            {
                var tokens = input.Split();

                var command = tokens[0];

                if (command == "reverse")
                {
                    var startIndex = int.Parse(tokens[2]);
                    var count = int.Parse(tokens[4]);

                    if (!isInputValid(startIndex, arr, count))
                    {
                        Console.WriteLine("Invalid input parameters.");
                        input = Console.ReadLine();
                        continue;
                    }

                    //count = 0  == count = 1
                    Array.Reverse(arr, startIndex, count);
                }
                else if (command == "sort")
                {
                    var startIndex = int.Parse(tokens[2]);
                    var count = int.Parse(tokens[4]);

                    if (!isInputValid(startIndex, arr, count))
                    {
                        Console.WriteLine("Invalid input parameters.");
                        input = Console.ReadLine();
                        continue;
                    }

                    //count = 0  == count = 1
                    Array.Sort(arr,startIndex,count);
                }
                else if (command == "rollLeft")
                {
                    int rollTimes = int.Parse(tokens[1]);

                    rollTimes %= length;
                    RotateArrayElements(arr, length - rollTimes, length);
                }
                else if (command == "rollRight")
                {
                    int rollTimes = int.Parse(tokens[1]);


                    RotateArrayElements(arr, rollTimes, length);
                }


                input = Console.ReadLine();
            }

            PrintArr(arr);
        }

        private static void PrintArr(string[] arr)
        {
            Console.Write("[");
            Console.Write(string.Join(", ", arr));
            Console.Write("]");
        }

        private static void RotateArrayElements(string[] arr, int rollTimes, int length)
        {
            var tempArr = new string[length];

            Array.Copy(arr,tempArr,length);

            rollTimes %= length;
            for (int i = 0; i < length; i++)
            {
                arr[(i + rollTimes) % length] = tempArr[i];
            }
        }

        private static bool isInputValid(int startIndex, string[] arr, int count)
        {
            if (startIndex < 0 || startIndex >= arr.Length || count < 0 || startIndex + count > arr.Length)
            {
                return false;
            }
            return true;
        }
    }
}