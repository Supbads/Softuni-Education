using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Phonebook
{
    class Phonebook
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> phonebook = new Dictionary<string, string>();

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

                input = Console.ReadLine();
            }

        }
    }
}
