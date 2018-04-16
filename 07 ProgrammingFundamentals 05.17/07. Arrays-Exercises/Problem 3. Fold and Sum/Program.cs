using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersUnfolded = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int foldNumber = numbersUnfolded.Length / 4;

            int arrayslength = foldNumber * 2;

            int[] topLeft = new int[foldNumber];
            Array.Copy(numbersUnfolded,topLeft,foldNumber);
            Array.Reverse(topLeft);

            int[] topRight = CopyBackwards(numbersUnfolded, foldNumber);

            int[] topPartMerged = MergeTopPart(topLeft, topRight, arrayslength);

            int[] middlePart = TakeMiddlepart(numbersUnfolded, foldNumber);

            int[] sumArr = SumArrays(topPartMerged, middlePart, arrayslength);

            Console.WriteLine(string.Join(" ", sumArr));
        }

        private static int[] SumArrays(int[] firstArr, int[] secondArr, int n)
        {
            int[] sumArr = new int[n];

            for (int i = 0; i < n; i++)
            {
                sumArr[i] = firstArr[i] + secondArr[i];
            }

            return sumArr;
        }

        private static int[] TakeMiddlepart(int[] numbersUnfolded, int n)
        {
            int[] middlePart = new int[2 * n];

            int topBorder = n * 2;
            for (int i = n, j = 0; j < topBorder; i++, j++)
            {
                middlePart[j] = numbersUnfolded[i];
            }

            return middlePart;
        }

        private static int[] MergeTopPart(int[] topLeft, int[] topRight, int arrayslength)
        {
            int[] topPart = new int[arrayslength];

            for (int i = 0; i < arrayslength; i++)
            {
                if (arrayslength / 2 > i)
                {
                    topPart[i] = topLeft[i];
                }
                else
                {
                    topPart[i] = topRight[i - (arrayslength / 2)];
                }
            }

            return topPart;

        }

        static int[] CopyBackwards(int[] source, int n)
        {
            int[] backwardsArray = new int[n];

            for (int i = source.Length - 1, k = 0; n > k; i--, k++)
            {
                backwardsArray[k] = source[i];
            }

            return backwardsArray;
        }
    }
}
