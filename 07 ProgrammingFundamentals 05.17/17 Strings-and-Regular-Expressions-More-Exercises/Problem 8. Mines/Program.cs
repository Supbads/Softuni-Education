using System;

namespace Problem_8.Mines
{
    class Program
    {
        static void Main(string[] args)
        {
            const int offset = 3;
            char destroyedSymbol = '_';

            var input = Console.ReadLine().ToCharArray();

            for (int i = offset; i < input.Length; i++)
            {
                if (input[i] != '>')
                {
                    continue;
                }

                if (input[i - offset] != '<')
                {
                    continue;
                }

                var firstChar = input[i - 2];  //i - offset + 1
                var secondChar = input[i - 1]; //i - offset + 2

                var destructionRange = Math.Abs((int) firstChar - (int) secondChar);

                var bottomRange = Math.Max(0, i - offset - destructionRange); //inclusive
                var topRange = Math.Min(input.Length - 1, i + destructionRange); //inclusive

                int j = bottomRange;
                while (j <= topRange)
                {
                    input[j] = destroyedSymbol;
                    j++;
                }

            }

            Console.WriteLine(new string(input));
        }
    }
}
