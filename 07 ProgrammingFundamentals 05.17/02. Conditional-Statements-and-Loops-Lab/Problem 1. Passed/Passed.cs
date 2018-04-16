using System;

namespace Problem_1.Passed
{
    class Passed
    {
        static void Main()
        {
            double defaultPassingGrade = 3.00;

            double numberToCheck = double.Parse(Console.ReadLine());

            if (numberToCheck < defaultPassingGrade)
            {
                return;
            }
            else
            {
                Console.WriteLine("Passed!");
            }
        }
    }
}
