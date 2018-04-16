using System;

namespace Problem_1.Square_Root
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int num;
            try
            {
                double squared = SquareRoot(input);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }

        private static double SquareRoot(string input)
        {
            int num;
            bool tryParse = int.TryParse(input, out num);
            if (!tryParse)
            {
                throw new ArgumentException("Input must be a number");
            }
            if (num < 0)
            {
                throw new ArgumentOutOfRangeException("Input number must be a positive integer");
            }
            return Math.Sqrt(num);

        }
    }
}
