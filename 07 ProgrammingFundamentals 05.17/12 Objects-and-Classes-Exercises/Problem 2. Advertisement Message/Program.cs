using System;

namespace Problem_2.Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            var phrases = new[]
            {
                "Excellent product.", "Such a great product.", "I always use that product.",
                "Best product of its category.", "Exceptional product.", "I can’t live without this product."
            };
            var events = new[]
            {"Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"
            };

            var authors = new[] { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

            var cities = new[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };


            int numberOfRandomMessages = int.Parse(Console.ReadLine());


            Random rnd = new Random();

            for (int i = 0; i < numberOfRandomMessages; i++)
            {
                var phrasesIndex = rnd.Next(0, phrases.Length);
                var eventsIndex = rnd.Next(0, events.Length);
                var authoursIndex = rnd.Next(0, authors.Length);
                var citiesIndex = rnd.Next(0, cities.Length);

                Console.WriteLine("{0}{1} {2} – {3}", phrases[phrasesIndex], events[eventsIndex], authors[authoursIndex], cities[citiesIndex]);
            }
        }
    }
}
