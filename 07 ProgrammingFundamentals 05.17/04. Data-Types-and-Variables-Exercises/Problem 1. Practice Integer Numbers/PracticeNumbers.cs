using System;

namespace Problem_1.Practice_Integer_Numbers
{
    class PracticeNumbers
    {
        static void Main(string[] args)
        {
            //3.141592653589793238
            //1.60217657
            //7.8184261974584555216535342341

            sbyte firstNum = sbyte.Parse(Console.ReadLine());
            byte secondNum = byte.Parse(Console.ReadLine());
            short thirdNum = short.Parse(Console.ReadLine());
            int fourthNum = int.Parse(Console.ReadLine());
            uint fifthNum = uint.Parse(Console.ReadLine());
            int sixthNum = int.Parse(Console.ReadLine());
            long seventhNum = long.Parse(Console.ReadLine());
           
            Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}",
            	firstNum,
            	secondNum,
            	thirdNum,
            	fourthNum,
            	fifthNum,
            	sixthNum,
            	seventhNum);

         }
    }
}