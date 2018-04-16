using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_1.Phonebook
{
    class Phonebook
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> phonebook = new Dictionary<string, string>();
            //could also use sortedDictionary

            string input = Console.ReadLine();

            while (input != "END")
            {
                var tokens = input.Split();
                var command = tokens[0];

                if (command == "A")
                {
                    var name = tokens[1];
                    var number = tokens[2];

                    if (!phonebook.ContainsKey(name))
                    {
                        phonebook.Add(name, number);
                    }
                    else
                    {
                        phonebook[name] = number;
                    }
                }
                else if (command == "S")
                {
                    var name = tokens[1];

                    if (!phonebook.ContainsKey(name))
                    {
                        Console.WriteLine($"Contact {name} does not exist.");
                    }
                    else
                    {
                        Console.WriteLine("{0} -> {1}", name, phonebook[name]);
                    }
                }
                else //ListAll  
                {
                    foreach (var pair in phonebook.OrderBy(x => x.Key))
                    {
                        Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
                    }
                }

                input = Console.ReadLine();
            }

        }
    }
}
