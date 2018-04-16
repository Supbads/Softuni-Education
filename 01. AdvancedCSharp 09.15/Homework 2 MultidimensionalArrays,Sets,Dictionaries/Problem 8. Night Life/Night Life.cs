using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class NightLife
{
    static void Main(string[] args)
    {
        var schedule = new Dictionary<string, SortedDictionary<string, SortedSet<string>>>();
        FillDictionary(schedule);
        Print(schedule);
    }

    static void FillDictionary(Dictionary<string, SortedDictionary<string, SortedSet<string>>> schedule)
    {
        string input = Console.ReadLine();
        while (input != "END")
        {
            //declarations and intialization
            string[] splitInput = input.Split(';');
            string city = splitInput[0];
            string club = splitInput[1];
            string performer = splitInput[2];
            var performers = new SortedSet<string>() { performer };
            var clubs = new SortedDictionary<string, SortedSet<string>>() { { club, performers } };

            //if there is no entry for this city add a new entry
            if (!schedule.Keys.Contains(city))
            {
                schedule.Add(city, clubs);
            }
            //if there is an entry for this city, add to the entry
            else
            {
                //if the city doesn't have an entry for this club add a new entry
                if (!schedule[city].Keys.Contains(club))
                {
                    schedule[city].Add(club, performers);
                }
                //if club already exists in this city add performers to the club
                else
                {
                    schedule[city][club].Add(performer);
                }
            }
            input = Console.ReadLine();
        }
    }

    static void Print(Dictionary<string, SortedDictionary<string, SortedSet<string>>> schedule)
    {
        foreach (var dict in schedule)
        {
            Console.WriteLine(dict.Key);
            foreach (var set in dict.Value)
            {
                Console.Write("->{0}: ", set.Key);
                Console.WriteLine(String.Join(", ", set.Value));
            }
        }
    }
}