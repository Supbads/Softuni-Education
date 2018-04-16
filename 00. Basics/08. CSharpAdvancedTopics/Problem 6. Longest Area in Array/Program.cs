using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] str = new string[n];
        for (int i = 0; i < n; i++)
        {
            str[i] = Console.ReadLine();
        }
        int counter = 1;
        int maxCounted = 1;
        string keyword = " ";
        for (int i = 0; i < str.Length; i++)
        {
            counter = 1;
            int j = i + 1;
            while (j < str.Length)
            {
                if (str[i] == str[j])
                {
                    counter++;
                }
                if (maxCounted<counter)
                {
                    maxCounted = counter;
                    keyword = str[i];
                }


                j++;
            }

        }
        Console.WriteLine(maxCounted);
        for (int i = 0; i < maxCounted; i++)
        {
            Console.WriteLine(keyword);
        }


    }
}
