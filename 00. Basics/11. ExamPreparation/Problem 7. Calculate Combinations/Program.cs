using System;

class Program
{
    static void Main()
    {
        // Calculate N! / (K! * (N-K)!)
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        int top = 1;
        int bottom = 1;

        if (n > k)
        {

            for (int i = (n - k) + 1; i<=n ; i++)
            {
                top *= i;
            }
            for(int i = 1; i<=k;i++)
            {
                bottom *= i;
            }
            Console.WriteLine(top / bottom);
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }

    }
}
