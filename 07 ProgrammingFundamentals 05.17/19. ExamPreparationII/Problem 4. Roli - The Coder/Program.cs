using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {

        //id -> event -> participants
        Dictionary<string , string> idsAndEvents = new Dictionary<string, string>();
        Dictionary<string, HashSet<string>> eventsAndPeople = new Dictionary<string, HashSet<string>>();

        string input = Console.ReadLine();
        while (input != "Time for Code")
        {
            if (!input.Contains("#"))
            {
                input = Console.ReadLine();
                continue;
            }

            var tokens = input.Split(new []{' '},StringSplitOptions.RemoveEmptyEntries).ToArray();
            string id = tokens[0].Trim();
            string eventName = tokens[1].Trim();

            var participants = new HashSet<string>();

            for (int i = 2; i < tokens.Length; i++)
            {
                participants.Add(tokens[i]);
            }

            if (!idsAndEvents.ContainsKey(id))
            {
                idsAndEvents.Add(id, eventName);

                eventsAndPeople.Add(eventName, participants);
            }
            else // validate
            {
                if (idsAndEvents[id] == eventName)
                {
                    foreach (var participant in participants)//this logic may not be neccessary if we move the upper forloop
                    {
                        eventsAndPeople[eventName].Add(participant);
                    }
                }
                //else ignore
            }


            input = Console.ReadLine();
        }

        //All events must be sorted by participant count in descending order and then by alphabetical order.
        foreach (var eventAndPeople in eventsAndPeople.OrderByDescending(x => x.Value.Count).ThenBy(y => y.Key))
        {
            var eventName = eventAndPeople.Key;
            var participants = eventAndPeople.Value;

            Console.WriteLine("{0} - {1}", eventName.Substring(1), participants.Count);

            //For each event, the participants must be sorted in alphabetical order.
            foreach (var participant in participants.OrderBy(x => x))
            {
                Console.WriteLine(participant);
            }

        }

    }
}