namespace Problem_2Calc_sequance_with_queue
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            //•	S1 = N
            //•	S2 = S1 + 1
            //•	S3 = 2*S1 + 1
            //•	S4 = S1 + 2
            Queue<int> sequanceOfNumbers = new Queue<int>();
            Console.WriteLine("Enter a starting Number");
            int startingNumber = int.Parse(Console.ReadLine());
            sequanceOfNumbers.Enqueue(startingNumber);

            int counterino = 50;
            for (int i = 0; i < counterino; i++)
            {
                int currentNumber = sequanceOfNumbers.Dequeue();
                Console.Write(currentNumber + " ");
                int s1 = currentNumber + 1;
                int s2 = (2 * currentNumber) + 1;
                int s3 = currentNumber + 2;

                sequanceOfNumbers.Enqueue(s1);
                sequanceOfNumbers.Enqueue(s2);
                sequanceOfNumbers.Enqueue(s3);
            }
        }
    }
}
