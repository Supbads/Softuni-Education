using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Enter_Numbers
{
    class Program
    {
        private static string input;
        private static int num = 1;
        private static int recursiveCalls = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter 10 valid numbers (between 1...100) where each num is bigger than the previous");
            while (recursiveCalls < 10)
            {
                try
                {
                    input = Console.ReadLine();
                    while (!int.TryParse(input, out num) || !(num < 100 && num > 1))
                    {
                        throw new ArgumentException(string.Format("Please enter a valid number (between {0}...{1})",num,100));
                        //Console.WriteLine("Please enter a valid number (between 1...100)");
                        //input = Console.ReadLine();
                    }
                    recursiveCalls++;
                    ReadNumber(num);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void ReadNumber(int start = 1, int end = 100)
        {
            if (recursiveCalls >= 10)
            {
                Console.WriteLine("Good job!");
                return;
            }
            input = Console.ReadLine();
            if (recursiveCalls < 10 && start == 99)
            {
                Console.WriteLine("Buddy you messed darn good");
                return;
            }
            while (!int.TryParse(input, out num) || !(num < end && num > start))
            {
                throw new ArgumentException(string.Format("Please enter a valid number (between {0}...{1})", start, end));
                //Console.WriteLine(string.Format("Please enter a valid number (between {0}...{1})", start, end));
                //input = Console.ReadLine();
            }
            recursiveCalls++;
            ReadNumber(num,end);
        }
    }
}
