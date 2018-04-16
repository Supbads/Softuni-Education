using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Order_by_Age
{
    class Person
    {
        public Person(string name, int age, string id)
        {
            Name = name;
            Age = age;
            ID = id;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string ID { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            IList<Person> people = new List<Person>();

            string input = Console.ReadLine();

            while (input!="End")
            {
                var tokens = input.Split();

                string name = tokens[0];
                string id = tokens[1];
                int age = int.Parse(tokens[2]);

                var person = new Person(name, age, id);

                people.Add(person);

                input = Console.ReadLine();
            }

            foreach (var person in people.OrderBy(x => x.Age))
            {
                Console.WriteLine("{0} with ID: {1} is {2} years old.", person.Name, person.ID, person.Age);
            }

        }
    }
}