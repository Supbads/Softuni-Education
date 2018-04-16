using System;
using System.Collections.Generic;

class ForeignLangauges
{
    
    static Dictionary<string,string> CountryAndLanguage = new Dictionary<string, string>();

    static void Main()
    {
        FillDictionary(CountryAndLanguage);

        string input = Console.ReadLine();

        if (CountryAndLanguage.ContainsKey(input))
        {
            Console.WriteLine(CountryAndLanguage[input]);
        }
        else
        {
            Console.WriteLine("unknown");
        }
    }

    private static void FillDictionary(Dictionary<string, string> countryAndLanguage)
    {
        countryAndLanguage.Add("USA", "English");
        countryAndLanguage.Add("England", "English");
        countryAndLanguage.Add("Spain", "Spanish");
        countryAndLanguage.Add("Argentina", "Spanish");
        countryAndLanguage.Add("Mexico", "Spanish");
    }
}