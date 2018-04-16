using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.SoftUni_Karaoke
{
    class Program
    {
        static void Main(string[] args)
        {
            var participants = Console.ReadLine().Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim())
                .ToList();
            //hashset to optimize
            var songs = Console.ReadLine().Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim()).ToList();


            Dictionary<string, List<string>> personAndAwards = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "dawn")
            {
                var tokens = input.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

                var currentParticipant = tokens[0];
                var song = tokens[1];
                var award = tokens[2];

                if (!participants.Contains(currentParticipant))
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (!songs.Contains(song))
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (!personAndAwards.ContainsKey(currentParticipant))
                {
                    personAndAwards.Add(currentParticipant, new List<string>());
                }

                if (!personAndAwards[currentParticipant].Contains(award))
                {
                    personAndAwards[currentParticipant].Add(award);
                }

                input = Console.ReadLine();
            }


            bool anyAwards = false;


            //logic
            //Print participants sorted by unique awards count in descending order. If two participants have the same unique award count, sort them alphabetically by name
            //Print unique awards for every participant sorted alphabetically
            foreach (var singerAndAwards in personAndAwards.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                anyAwards = true;
                Console.WriteLine("{0}: {1} awards", singerAndAwards.Key, singerAndAwards.Value.Count);

                foreach (var award in singerAndAwards.Value.OrderBy(x => x))
                {
                    Console.WriteLine("--{0}",award);
                }
            }

            if (!anyAwards)
            {
                Console.WriteLine("No awards");
            }
        }
    }
}
