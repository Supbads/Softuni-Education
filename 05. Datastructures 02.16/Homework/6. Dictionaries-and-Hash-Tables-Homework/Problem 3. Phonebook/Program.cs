namespace Problem_3.Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var phoneBook = new HashTable<string, List<string>>();
            string input = Console.ReadLine();
            /*
            Nakov-+359888001122
            RoYaL(Ivan)-666
            Nakov-0888080808
            Gero-5559393
            Simo-02/987665544
            search
            Simo
            Mariika
            Nakov           
            simo
            RoYaL
            RoYaL(Ivan)           
            */
            while (input != "search")
            {
                var args = input.Split('-');
                if (!phoneBook.ContainsKey(args[0]))
                {
                    phoneBook[args[0]] = new List<string>();
                }

                phoneBook[args[0]].Add(args[1]);

                input = Console.ReadLine();
            }
            
            string contact = Console.ReadLine();
            while (true)
            {
                if (!phoneBook.ContainsKey(contact))
                {
                    Console.WriteLine("Contact {0} does not exist.", contact);
                    continue;
                }

                var info = string.Join(", ", phoneBook[contact]);
                Console.WriteLine("{0} -> {1}", contact, info);
                contact = Console.ReadLine();
            }
        }
    }
}