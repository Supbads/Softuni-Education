namespace Problem_3.Array_Based_Stack
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            ArrayStack<int> testStack = new ArrayStack<int>();
            testStack.Push(5);
            testStack.Push(8);
            testStack.Push(3);

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(testStack.Pop());
            }
        }
    }
}
