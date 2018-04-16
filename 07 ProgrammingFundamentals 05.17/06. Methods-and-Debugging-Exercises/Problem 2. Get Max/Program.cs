using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Get_Max
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstN = int.Parse(Console.ReadLine());
            int secN = int.Parse(Console.ReadLine());
            int thirdN = int.Parse(Console.ReadLine());

            int max = GetMax(firstN, secN, thirdN);

            Console.WriteLine(max);


        }

        private static int GetMax(int a, int b, int c)
        {
            if (a < b)
            {
                a = b;
            }
            if (a < c)
            {
                a = c;
            }
            return a;
        }
    }
}
