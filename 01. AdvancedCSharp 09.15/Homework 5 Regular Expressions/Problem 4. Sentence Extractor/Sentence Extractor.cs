using System;
using System.Text.RegularExpressions;

class SentanceExtractor
{
    static void Main(string[] args)
    {
        // is
        //This is my cat!And this is my dog.We happily live in Paris – the most beautiful city in the world!Isn’t it great? Well it is :)
        // it
        //This is my cat!And this is my dog.We happily live in Paris – the most beautiful city in the world!Isn’t it great? Well it is :)

        string word = "is";
        //string word = Console.ReadLine();
        string text = "This is my cat!And this is my dog.We happily live in Paris – the most beautiful city in the world!Isn’t it great? Well it is :)";
        //string text = Console.ReadLine();

        string pattern = @"\b[^.?!]+\b"+ word + @"\b.*?[!.?]";
        Regex rgx = new Regex(pattern);
        MatchCollection matches = rgx.Matches(text);
        foreach (var item in matches)
        {
            Console.WriteLine(item);
        }
    }
}
