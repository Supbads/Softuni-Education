using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // username -> ip -> messages count
        SortedDictionary<string, Dictionary<string, int>> usernameAndIP = new SortedDictionary<string, Dictionary<string, int>>();

        string input = Console.ReadLine();

        //to try with regex

        while (input != "end")
        {
            string[] tokens = input.Split();
            var ip = tokens[0].Split(new[] { '=' })[1];
            var username = tokens[2].Split(new[] { '=' })[1];

            if (!usernameAndIP.ContainsKey(username))
            {
                usernameAndIP.Add(username, new Dictionary<string, int>());
            }

            if (!usernameAndIP[username].ContainsKey(ip))
            {
                usernameAndIP[username].Add(ip, 0);
            }

            usernameAndIP[username][ip]++;

            input = Console.ReadLine();
        }

        foreach (var usernameAndIPPair in usernameAndIP)
        {
            Console.WriteLine("{0}:", usernameAndIPPair.Key);

            var IPAndMessagesPair = usernameAndIPPair.Value;
            //StringBuilder sb = new StringBuilder();

            //foreach (var IPAndMessagesCount in IPAndMessagesPair)
            //{
            //    sb.AppendFormat("{0} => {1}, ", IPAndMessagesCount.Key, IPAndMessagesCount.Value);
            //}

            //sb[sb.Length - 2] = '.';

            //Console.WriteLine(sb.ToString().TrimEnd());

            foreach (var IPAndMessagesCount in IPAndMessagesPair)
            {
                var ip = IPAndMessagesCount.Key;
                var messagesCount = IPAndMessagesCount.Value;

                if (ip != usernameAndIPPair.Value.Keys.Last())
                {
                    Console.Write("{0} => {1}, ", ip, messagesCount);
                }
                else
                {
                    Console.WriteLine("{0} => {1}.", ip, messagesCount);
                }

            }
        }
    }
}