using System;
using System.Collections.Generic;


class Program
{
    static void Main()
    {
        Dictionary<string, string> nameAndEmail = new Dictionary<string, string>();
        string name = Console.ReadLine();

        while (name != "stop")
        {
            string email = Console.ReadLine();

            var endsWithUS = email.ToLower().EndsWith("us");
            var endsWithUK = email.ToLower().EndsWith("uk");

            if (endsWithUS || endsWithUK) 
            {
                name = Console.ReadLine();
                continue;
            }

            if (!nameAndEmail.ContainsKey("name"))
            {
                nameAndEmail.Add(name, email);
            }
            else
            {
                nameAndEmail[name] = email; //overwrite needed ?
            }

            name = Console.ReadLine();
        }
        
        foreach (var nameAndEmailPair in nameAndEmail)
        {
            Console.WriteLine("{0} -> {1}",nameAndEmailPair.Key, nameAndEmailPair.Value);
        }

    }
}