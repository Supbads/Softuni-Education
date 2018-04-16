using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.Search_for_a_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split().Select(int.Parse).ToList();

            int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();


            var takenElementsFromArray = array.Take(tokens[0]);

            //Console.WriteLine(string.Join(" ", takenElementsFromArray));

            var removedElementsFromTaken = takenElementsFromArray.Skip(tokens[1]);

            //Console.WriteLine(string.Join(" ", removedElementsFromTaken));

            if (removedElementsFromTaken.Contains(tokens[2]))
            {
                Console.WriteLine("YES!");
            }
            else
            {
                Console.WriteLine("NO!");
            }
              
        }
    }
}
