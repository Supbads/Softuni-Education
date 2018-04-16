using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {

    }

    static List<int> FindPrimesInRange(int startNum, int endNum)
    {

        for (int i = startNum; i <= endNum; i++)
        {
            bool isPrime = true;

            for (int j = 2; j <= Math.Sqrt(i); j++)
            {
                if (i%j==0)
                {
                    isPrime = false;

                }
                if (isPrime)
                {
                    ;

                }

            }
            

            

        }

    }


}
