namespace Problem_1.Stack_Reverse_Numbers
{
    using System;
    using System.Collections.Generic;

    class ReverseNumbersWithStack
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            //int[] numbers = new int[0];

            Stack<int> numbersToReverse = new Stack<int>(numbers);

            if (numbersToReverse.Count == 0)
            {
                Console.WriteLine("(empty)");
            }
            else
            {
                Console.WriteLine(string.Join(" ", numbersToReverse));
            }
        }
    }
}
