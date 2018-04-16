namespace Problem_2.Sort_Words
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SortWords
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split(new char[] { ' ' }).ToList();
            words.Sort();
            Console.WriteLine(string.Join(" ", words));
        }
    }
}