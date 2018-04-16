using System;
using System.Linq;

namespace Problem_2.Rotate_and_Sum
{
    class RotateAndSum
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            int n = int.Parse(Console.ReadLine());
            
            int[] summedArray = RotateAndSumArray(array, n);

            Console.WriteLine(string.Join(" ", summedArray));
        }

        static int[] RotateAndSumArray(int[] arrayToRotate, int timesToRotate)
        {
            int arrayLength = arrayToRotate.Length;

            int[] summedArray = new int[arrayLength];

            for (int j = 0; j < timesToRotate; j++)  //itterate through all rotations
            {
                int[] tempArr = new int[arrayLength];

                for (int i = 0; i < arrayLength; i++) //rotate an array right once
                {
                    tempArr[i] = arrayToRotate[(arrayLength - 1 + i) % arrayLength];
                }

                // Sum array with the temporary rotated one.
                for (int i = 0; i < arrayLength; i++)
                {
                    summedArray[i] += tempArr[i];
                }
                arrayToRotate = tempArr;
            }

            return summedArray;
        }
    }
}