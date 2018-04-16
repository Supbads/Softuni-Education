using System;

namespace Problem_1.Censorship
{
    class Program
    {
        static void Main()
        {
            string censoredWord = Console.ReadLine();
            
            string text = Console.ReadLine();

            var censoredText = text.Replace(censoredWord, new string('*', censoredWord.Length));
            Console.WriteLine(censoredText);


            //StringBuilder censoredText = new StringBuilder();

            //string censoredWord = Console.ReadLine().ToLower();

            //string text = Console.ReadLine();



            //for (int i = censoredWord.Length - 1; i < text.Length; i++)
            //{
            //    var currentWord = "";
            //    int j = i;

            //    while (i - j < censoredWord.Length)
            //    {
            //        currentWord += text[j];
            //        j--;
            //    }


            //    var toCharArr = currentWord.ToLower().ToCharArray();
            //    Array.Reverse(toCharArr);
            //    var loweredAndReversedWord = new string(toCharArr);

            //    if (loweredAndReversedWord == censoredWord)
            //    {
            //        censoredText.Append(new string('*', currentWord.Length));
            //        i += currentWord.Length - 1;
            //    }
            //    else
            //    {
            //        censoredText.Append(text[i - (censoredWord.Length-1)]);
            //    }

            //}


            //Console.WriteLine(censoredText.ToString());

        }
    }
}
