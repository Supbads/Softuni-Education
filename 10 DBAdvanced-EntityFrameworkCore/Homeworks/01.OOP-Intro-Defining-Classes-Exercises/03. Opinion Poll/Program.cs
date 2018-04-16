using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Opinion_Poll
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<Person> people = new HashSet<Person>();

            for (int i = 0; i < n; i++)
            {
                var personArgs = Console.ReadLine().Split().ToArray();
                Person currentPerson = new Person(personArgs[0], int.Parse(personArgs[1]));

                people.Add(currentPerson);
            }

            people.Where(p => p.Age > 30)
                .OrderBy(p => p.Name).ToList()
                .ForEach(p => Console.WriteLine(p.Name + " - " + p.Age));
        }
    }
}