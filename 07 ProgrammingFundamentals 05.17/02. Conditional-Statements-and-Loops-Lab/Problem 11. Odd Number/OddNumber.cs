using System;

class OddNumber
{
    static void Main()
    {
        int inputNumber = 0;

        bool isNumberOdd = false;

        while (isNumberOdd != true)
        {
            inputNumber = Math.Abs(int.Parse(Console.ReadLine()));


            if (inputNumber % 2 == 1)
            {
                isNumberOdd = true;
            }
            else
            {
                Console.WriteLine("Please write an odd number.");
            }
        }
        Console.WriteLine("The number is: " + inputNumber);

    }
}