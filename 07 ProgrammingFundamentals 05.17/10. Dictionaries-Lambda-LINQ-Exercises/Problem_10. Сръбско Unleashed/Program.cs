using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        //Venue -> singer -> tickets(long)
        Dictionary<string, Dictionary<string, long>> venuesAndSingers =
            new Dictionary<string, Dictionary<string, long>>();
        
        string pattern = @"([\w ]+)\s{1}@([^\d]+)\s{1}([\d]+)\s([\d]+)";
        Regex rgx = new Regex(pattern);

        string input = Console.ReadLine();

        while (input != "End")
        {
            var match = rgx.Match(input);
            if (!match.Success)
            {
                input = Console.ReadLine();
                continue;
            }

            var singer = match.Groups[1].ToString();
            var venue = match.Groups[2].ToString();
            long money = long.Parse(match.Groups[3].ToString()) * long.Parse(match.Groups[4].ToString());

            if (!venuesAndSingers.ContainsKey(venue))
            {
                venuesAndSingers.Add(venue, new Dictionary<string, long>());
            }

            if (!venuesAndSingers[venue].ContainsKey(singer))
            {
                venuesAndSingers[venue].Add(singer, 0);
            }

            venuesAndSingers[venue][singer] += money;

            input = Console.ReadLine();
        }
        
        foreach (var venueAndSingersPair in venuesAndSingers)
        {
            Console.WriteLine("{0}",venueAndSingersPair.Key);

            foreach (var singerAndMoney in venueAndSingersPair.Value.OrderByDescending(x => x.Value))
            {
                Console.WriteLine("#  {0} -> {1}", singerAndMoney.Key, singerAndMoney.Value);

            }

        }

    }
}