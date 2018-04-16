using System;

class Program
{
    static void Main()
    {
        string[] userINput = Console.ReadLine().Split();
        int a = Convert.ToInt32(userINput[0]);
        int b = Convert.ToInt32(userINput[1]);
        int c = Convert.ToInt32(userINput[2]);
        int d = Convert.ToInt32(userINput[3]);
        int e = Convert.ToInt32(userINput[4]);
        int sumOfAll = a + b + c + d + e;
        Console.WriteLine(sumOfAll);
        
    }
}