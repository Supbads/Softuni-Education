using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem_5.Parking_Validation
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> peopleAndLinceses = new Dictionary<string, string>();

            string pattern = @"register\s(.*)\s([A-Z]{2}[0-9]{4}[A-Z]{2})";

            Regex rgx = new Regex(pattern);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                var match = rgx.Match(input);

                if (match.Success)
                {
                    var personToRegister = match.Groups[1].ToString();
                    var licenseToRegister = match.Groups[2].ToString();

                    if (peopleAndLinceses.ContainsKey(personToRegister))
                    {
                        var registeredLicensePlate = peopleAndLinceses[personToRegister];

                        Console.WriteLine("ERROR: already registered with plate number {0}", registeredLicensePlate);

                        //registered one or not
                    }
                    else if (peopleAndLinceses.ContainsValue(licenseToRegister))
                    {

                        Console.WriteLine("ERROR: license plate {0} is busy", licenseToRegister);
                    }
                    else
                    {
                        peopleAndLinceses.Add(personToRegister, licenseToRegister);
                        Console.WriteLine("{0} registered {1} successfully", personToRegister, licenseToRegister);
                    }
                }
                else if (input.StartsWith("un"))
                {
                    var tokens = input.Split();
                    string personToUnregister = tokens[1];

                    if (!peopleAndLinceses.ContainsKey(personToUnregister))
                    {
                        Console.WriteLine("ERROR: user {0} not found", personToUnregister);
                    }
                    else
                    {
                        peopleAndLinceses.Remove(personToUnregister);
                        Console.WriteLine("user {0} unregistered successfully", personToUnregister);
                    }
                }
                else
                {
                    var licensePlate = input.Split()[2];
                    
                    Console.WriteLine("ERROR: invalid license plate {0}", licensePlate);
                }
            }
            
            foreach (var personAndLincePair in peopleAndLinceses)
            {
                Console.WriteLine("{0} => {1}",personAndLincePair.Key, personAndLincePair.Value);
            }
        }
    }
}