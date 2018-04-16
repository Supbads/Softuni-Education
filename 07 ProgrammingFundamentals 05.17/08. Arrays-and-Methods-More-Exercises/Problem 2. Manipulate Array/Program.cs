using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] array = Console.ReadLine().Split();

        string input = Console.ReadLine();
        
        while(input != "END") //problem 3 safe manipulate
        {
            if (input == "Distinct")
            {
                array = array.Distinct().ToArray();
            }
            else if (input == "Reverse")
            {
                Array.Reverse(array);
            }
            else if (input.StartsWith("Replace"))
            {
                string[] tokens = input.Split();
                int index = int.Parse(tokens[1]);

                if (index < 0 || index >= array.Length)
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    string replacementString = tokens[2];
                    array[index] = replacementString;
                }
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }

            input = Console.ReadLine();
        }

        Console.WriteLine(string.Join(", ", array));
    }
}