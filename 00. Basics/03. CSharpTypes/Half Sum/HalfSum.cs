using System;

class HalfSum
{
    static void Main()
    {
        long firstSum=0;
        long secondSum=0;
        short n = short.Parse(Console.ReadLine());
        for (int i = 1; i <= 2*n; i++)
        {
            long number = int.Parse(Console.ReadLine());
            if (i <= n)
            {
                firstSum += number;
            }
            else
            {
                secondSum += number;
            }

       }
       long difference = firstSum - secondSum;
       if (difference < 0)
       {
           difference *= -1;
       }
       if((firstSum == secondSum))
       {
           Console.WriteLine("Yes, sum={0}",firstSum);
       }
       else
       {
           Console.WriteLine("No, diff={0}",difference);
       }
        //http://puu.sh/hXOJM/482cc6e5fc.png
    }
}