namespace Problem_2.Count_Symbols
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var hashMap = new HashTable<char, int>();

            var arr = Console.ReadLine().ToCharArray();

            List<char> keys = new List<char>(arr.Length);
            //SoftUni Rocks
            //Did you know Math.Round rounds to the nearest even integer?

            foreach (char element in arr)
            {
                if (!hashMap.ContainsKey(element))
                {
                    hashMap[element] = 0;
                }
                hashMap[element]++;
                keys.Add(element);
            }

            keys.Sort();
            foreach (char c in keys.Distinct())
            {
                var times = hashMap[c];
                Console.WriteLine("{0}: {1} time/s", c, times);
            }
        }
    }
}
