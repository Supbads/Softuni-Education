using System;
using System.Text.RegularExpressions;

class ExtractEmails
{
    static void Main(string[] args)
    {
        // Just send email to s.miller@mit.edu and j.hopking@york.ac.uk 
        // Please contact us at: support@github.com.
        // Many users @ SoftUni confuse email addresses. We @ Softuni.BG provide high-quality training @ home or @ class. –- steve.parker@softuni.de.


        string text = Console.ReadLine();
        //string pattern = @"[a-zA-Z]+([-+.]+\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
        string pattern = @"(?<=\s|^)([a-z0-9]+(?:[_.-][a-z0-9]+)*@[a-z]+\-?[a-z]+(?:\.[a-z]+)+)\b";
        Regex reg = new Regex(pattern);
        MatchCollection matches = reg.Matches(text);
        foreach (Match i in matches)
        {
            Console.WriteLine(i.Groups[0]);
        }
    }
}
