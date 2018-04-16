using System;
using System.Linq;

namespace Problem_5.CompareCharArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] shorter = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(x => x.FirstOrDefault())
                .ToArray();

            char[] longer = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.FirstOrDefault())
                .ToArray();

            if (shorter.Length > longer.Length)
            {
                char[] temp = shorter;
                shorter = longer;
                longer = temp;
            }

            bool isFirstArrSmaller = true;

            for (int i = 0; i < shorter.Length; i++)
            {
                if (shorter[i] > longer[i])
                {
                    isFirstArrSmaller = false;
                    break;
                }
            }

            if (isFirstArrSmaller)
            {
                Console.WriteLine(new string(shorter));
                Console.WriteLine(new string(longer));
            }
            else
            {
                Console.WriteLine(new string(longer));
                Console.WriteLine(new string(shorter));
            }

        }
    }
}
