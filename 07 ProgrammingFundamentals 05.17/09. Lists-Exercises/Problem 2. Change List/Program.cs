using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();

            while (command != "Odd" && command != "Even")
            {
                var tokens = command.Split();
                if (tokens[0] == "Delete")
                {
                    int numberToRemove = int.Parse(tokens[1]);

                    array.RemoveAll(x => x == numberToRemove);
                }
                else if (tokens[0] == "Insert")
                {
                    int element = int.Parse(tokens[1]);
                    int insertionIndex = int.Parse(tokens[2]);

                    array.Insert(insertionIndex, element);
                }
                command = Console.ReadLine();
            }

            if (command == "Even")
            {
                foreach (var i in array.Where(x => x % 2 == 0))
                {
                    Console.Write(i + " ");

                }
            }
            else//odd
            {
                foreach (var i in array.Where(x => x % 2 == 1))
                {
                    Console.Write(i + " ");

                }
            }

        }
    }
}
