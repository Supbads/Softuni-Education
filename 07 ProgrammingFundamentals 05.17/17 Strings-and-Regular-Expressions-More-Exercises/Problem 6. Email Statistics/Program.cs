using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Problem_6.Email_Statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> domainsAndUsernames = new Dictionary<string, List<string>>();

            string pattern = @"([a-zA-Z]{5,})@([a-z]{3,}\.(com|bg|org))";

            Regex emailValidator = new Regex(pattern);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string currentEmail = Console.ReadLine();

                var match = emailValidator.Match(currentEmail);

                if (!match.Success)
                {
                    continue;
                }

                string username = match.Groups[1].ToString();
                string domain = match.Groups[2].ToString();

                if (!domainsAndUsernames.ContainsKey(domain))
                {
                    domainsAndUsernames.Add(domain, new List<string>());
                }

                if (!domainsAndUsernames[domain].Contains(username)) //use a hashset cuck
                {
                    domainsAndUsernames[domain].Add(username);
                }

            }

            foreach (var domainAndUsername in domainsAndUsernames.OrderByDescending(x => x.Value.Count))
            {
                var currentDomain = domainAndUsername.Key;
                var currentUsernames = domainAndUsername.Value;

                Console.WriteLine("{0}:", currentDomain);

                foreach (var username in currentUsernames)
                {
                    Console.WriteLine("### " + username);
                }

            }


        }
    }
}
