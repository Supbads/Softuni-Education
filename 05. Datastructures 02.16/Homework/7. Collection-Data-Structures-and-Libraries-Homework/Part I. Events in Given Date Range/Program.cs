namespace Part_I.Events_in_Given_Date_Range
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;

    using Wintellect.PowerCollections;

    class Program
    {
        static void Main()
        {
            //program works in debugger but breaks when executed without debugging
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var events = new OrderedMultiDictionary<DateTime, string>(true);
            var eventsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < eventsCount; i++)
            {
                var inputArguments = Console.ReadLine()
                    .Split('|');
                string eventName = inputArguments[0].Trim();
                DateTime eventDate = DateTime.Parse(inputArguments[1].Trim());
                events.Add(eventDate, eventName);
            }

            int numberOfRequests = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfRequests; i++)
            {
                var requestArguments = Console.ReadLine().Split('|');
                var startingDate = DateTime.Parse(requestArguments[0].Trim());
                var endingDate = DateTime.Parse(requestArguments[1].Trim());
                var eventsInGivenRange = events.Range(startingDate, true, endingDate, true);
                Console.WriteLine(eventsInGivenRange.KeyValuePairs.Count);
                foreach (KeyValuePair<DateTime, ICollection<string>> timeEvent in eventsInGivenRange)
                {
                    foreach (var eventName in timeEvent.Value)
                    {
                        Console.WriteLine("{0} | {1}", eventName, timeEvent.Key);
                    }
                }
            }
        }
    }
}