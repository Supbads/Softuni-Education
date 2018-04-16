using System;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        if (!(input == ""))
        {
            string[] numbers = input.Split();
            if (numbers.Length < 2)
            {
                double num = double.Parse(input);
                Console.WriteLine("OddSum={0}, OddMin={0}, OddMax={0}, EvenSum=No, EvenMin=No, EvenMax=No", num);
            }
            else
            {
                double oddMin = double.MaxValue;
                double oddMax = double.MinValue;
                double oddSum = 0;

                double evenMin = double.MaxValue;
                double evenMax = double.MinValue;
                double evenSum = 0;





                for (int i = 0; i < numbers.Length; i++)
                {
                    if (i % 2 == 0) // odds 
                    {
                        double num = double.Parse(numbers[i]);

                        if (num >= oddMax)
                        {
                            oddMax = num;
                        }
                        if (num <= oddMin)
                        {
                            oddMin = num;
                        }
                        oddSum += num;
                    }
                    else  //evens
                    {
                        double num = double.Parse(numbers[i]);

                        if (num >= evenMax)
                        {
                            evenMax = num;
                        }
                        if (num <= evenMin)
                        {
                            evenMin = num;
                        }

                        evenSum += num;

                    }
                }
                Console.WriteLine("OddSum={0}, OddMin={1}, OddMax={2}, EvenSum={3}, EvenMin={4}, EvenMax={5}", oddSum, oddMin, oddMax, evenSum, evenMin, evenMax);
            }
        }
        else
        {
            Console.WriteLine("OddSum=No, OddMin=No, OddMax=No, EvenSum=No, EvenMin=No, EvenMax=No");
        }
    }
}
