using System;

class Program
{
    static void Main(string[] args)
    {
        int offset = 'a';

        char[] input = Console.ReadLine().ToCharArray();

        for (int i = 0; i < input.Length; i++)
        {
            Console.WriteLine("{0} -> {1}",input[i], (int)input[i] - offset);
        }
            
    }
}