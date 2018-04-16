using System;

class Program
{
    static void Main()
    {
        string str = Console.ReadLine();

        char[] chars = new char[str.Length];
        for (int i = 0; i < str.Length; i++)
        {

            char c = str[i];
            if (c % 3 == 0)
            {
               c = char.ToUpper(c);
                chars[i] = c;
            }
            else
            {
                chars[i] = c;
            }
        }
        Console.WriteLine(new string(chars));

    }
}