using System;

class PrintASequance
{
    static void Main()
    {
        int a = -2;
        int b = -1;
        int i = 0;
        while (i < 10)
        {
            a *= b;

            Console.WriteLine(a);

            if (a < 0)
            {
                a *= -1;
                a++;
                a *= -1;
            }
            else
            {
                a++;
            }

            i++;
        }
    }
}