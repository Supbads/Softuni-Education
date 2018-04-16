using System;

class Program
{
    static void Main()
    {
        string[] num = Console.ReadLine().Split();
        long sumEven = 1;
        long sumOdd = 1;
        for (int i = 0; i<num.Length; i++)
        {
            if (i % 2 == 0)
            {
                sumOdd *= Convert.ToInt32(num[i]);
            }
            else
            {
                sumEven *= Convert.ToInt32(num[i]);
            }
        }

        if (sumEven == sumOdd)
        {
            Console.WriteLine("yes\n product = {0}", sumEven);
        }
        else
        {
            Console.WriteLine("no \nodd_product = {0} \neven_product = {1}",sumOdd,sumEven);
        }
    }
}
