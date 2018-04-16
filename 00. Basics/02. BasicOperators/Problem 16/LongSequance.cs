using System;

class LongSequance
{
    static void Main()
    {
        int a = -2;
        int b = -1;
        int i = 0;
        while (i<1000)   //The console history only holds up to 300 lines
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