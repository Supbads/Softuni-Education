using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PythagoreanNumbers
{
    static void Main(string[] args)
    {
        int inputNum = int.Parse(Console.ReadLine());
        int[] nums = new int[inputNum];

        bool noSolution = true;

        for (int i = 0; i < inputNum; i++)
        {
            nums[i] = int.Parse(Console.ReadLine());
        }

        List<int> squares = nums.Select(x => x * x).ToList();

        foreach (int num in squares)
        {
            foreach (int num2 in squares)
            {

                int c = num + num2;

                if (num2 >= num && squares.Contains(c))
                {
                    int firstNum = (int)Math.Sqrt(num);
                    int secondNum = (int)Math.Sqrt(num2);
                    int thirdNum = (int)Math.Sqrt(c);
                    Console.WriteLine("{0}*{0}+{1}*{1}={2}*{2}", firstNum, secondNum, thirdNum);
                    noSolution = false;
                }
            }
        }
        if (noSolution)
        {
            Console.WriteLine("No");
        }
    }
}