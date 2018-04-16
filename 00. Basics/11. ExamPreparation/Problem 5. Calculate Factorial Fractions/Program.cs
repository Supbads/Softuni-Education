using System;

class Program
{
    static void Main()
    {
        //Calculate 1 + 1!/ X + 2!/ X2 + … +N!/ XN
        int n = int.Parse(Console.ReadLine());
        int x = int.Parse(Console.ReadLine());


        double factorialN = 1;
        double numXPowerN = 1;
        double sum = 1;


        for (int i = 1 ; i<=n ; i++)
        {
            factorialN *= i;
            numXPowerN *= x;
            sum += (factorialN / numXPowerN);

        }
        Console.WriteLine("The Sum of sequence of these numbers N and X is = {0:F5} ", sum);


    }
}
