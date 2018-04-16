using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        //peter -> ip(unique) -> loggedInTime
        SortedDictionary<string , SortedDictionary<string, long>> usersAndIPs 
            = new SortedDictionary<string, SortedDictionary<string, long>>();

        int n = int.Parse(Console.ReadLine());

        string input = "";
        for (int i = 0; i < n; i++)
        {
            input = Console.ReadLine();

            var tokens = input.Split();
            var ip = tokens[0];
            var user = tokens[1];
            long loggedTime = long.Parse(tokens[2]);

            if (!usersAndIPs.ContainsKey(user))
            {
                usersAndIPs.Add(user ,new SortedDictionary<string, long>());
            }
            if (!usersAndIPs[user].ContainsKey(ip))
            {
                usersAndIPs[user].Add(ip, 0);
            }

            usersAndIPs[user][ip] += loggedTime;
        }

        foreach (var userAndIPPair in usersAndIPs)
        {
            var user = userAndIPPair.Key;
            
            var IPAndLoggedTime = userAndIPPair.Value;
            var totalLoggedTime = IPAndLoggedTime.Values.Sum();

            var ips = IPAndLoggedTime.Keys;

            Console.WriteLine("{0}: {1} [{2}]",user,totalLoggedTime, string.Join(", ", ips));

        }

    }
}