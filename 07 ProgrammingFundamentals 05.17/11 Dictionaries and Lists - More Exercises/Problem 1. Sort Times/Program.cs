using System;
using System.Collections.Generic;

namespace Problem_1.Sort_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputTokens = Console.ReadLine().Split();

            var timesList = new List<TimeSpan>();

            for (int i = 0; i < inputTokens.Length; i++)
            {
                var currentElement = inputTokens[i];

                var parsedTime = DateTime.Parse(currentElement);
                
                TimeSpan attempt = new TimeSpan(parsedTime.Hour, parsedTime.Minute, 00);

                timesList.Add(attempt);
            }

            timesList.Sort();

            for (int i = 0; i < timesList.Count - 1; i++)
            {

                Console.Write("{0}:{1}, ", timesList[i].Hours.ToString().PadLeft(2, '0'), timesList[i].Minutes.ToString().PadLeft(2, '0'));
            }


            if (timesList.Count >= 1)
            {
                Console.WriteLine("{0}:{1}", timesList[timesList.Count - 1].Hours.ToString().PadLeft(2,'0'), timesList[timesList.Count - 1].Minutes.ToString().PadLeft(2, '0'));

            }
        }
    }
}