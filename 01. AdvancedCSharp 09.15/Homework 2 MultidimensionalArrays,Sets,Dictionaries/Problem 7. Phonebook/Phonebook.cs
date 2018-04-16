using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Phonebook
{
    static void Main(string[] args)
    {
        Dictionary<string, string> phonebook = new Dictionary<string, string>();
        string input = Console.ReadLine();
        while (input != "search")
        {
            string name = input.Split('-')[0];
            string phoneNumber = input.Split('-')[1];
            if (phonebook.Keys.Contains(name))
            {
                phonebook[name] = phonebook[name] + " , " + phoneNumber;
            }
            else
            {
                phonebook.Add(name, phoneNumber);
            }
            input = Console.ReadLine();
        }
        input = Console.ReadLine();
        while (!input.Equals(String.Empty))
        {
            if (phonebook.Keys.Contains(input))
            {
                Console.WriteLine("{0} -> {1}", input, phonebook[input]);
            }
            else
            {
                Console.WriteLine("Contact {0} does not exist.", input);
            }
            input = Console.ReadLine();
        }
    }
}
