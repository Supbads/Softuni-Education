using System;

namespace Problem_8.Personal_Exception
{
    class Program
    {
        static void Main(string[] args)
        {
            double input = double.Parse(Console.ReadLine());

            while (true)
            {
                try
                {
                    if (input < 0)
                    {
                        throw new NegativeNumberException();
                    }
                    Console.WriteLine(input);
                }
                catch (NegativeNumberException e)
                {
                    Console.WriteLine(e.Message);
                    break;
                }

                input = double.Parse(Console.ReadLine());
            }
        }
    }
}
