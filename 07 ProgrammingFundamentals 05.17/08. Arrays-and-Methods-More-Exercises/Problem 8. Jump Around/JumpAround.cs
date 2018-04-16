using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_8.Jump_Around
{
    class JumpAround
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int currentIndex = 0;

            long sum = 0;

            while (currentIndex >= 0 && currentIndex < numbers.Length)
            {
                int selectedElement = numbers[currentIndex];

                sum += selectedElement;
                if (currentIndex + selectedElement < numbers.Length)
                {
                    currentIndex += selectedElement;
                }
                else // >=
                {
                    currentIndex -= selectedElement;
                }
            }

            Console.WriteLine(sum);
        }
    }
}