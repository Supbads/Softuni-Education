using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];
        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < n; i++)
        {
            int j = i + 1;
            int temp;
            while (j<numbers.Length&&i<numbers.Length)
            {
                if (numbers[i]>numbers[j])
                {
                    temp= numbers[i];
                    numbers[i] = numbers[j];
                    numbers[j] = temp;

                }

                j++;
            }


        }

        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}
