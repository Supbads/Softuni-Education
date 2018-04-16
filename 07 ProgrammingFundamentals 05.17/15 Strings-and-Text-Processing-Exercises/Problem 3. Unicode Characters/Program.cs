using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.Unicode_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();


            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                var currentCharacter ="\\u" + ((int)input[i]).ToString("X4").ToLower();
                sb.Append(currentCharacter);

            }
            Console.WriteLine(sb.ToString());


        }
    }
}
