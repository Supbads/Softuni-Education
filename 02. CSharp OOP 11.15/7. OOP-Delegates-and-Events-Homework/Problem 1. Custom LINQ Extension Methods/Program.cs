using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Custom_LINQ_Extension_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            //this part of the lecture was for the people comming to fundamentals from the basics (and thus not yet have seen the linq lecture
            //in Advanced C#
            List<int> intList = new List<int>{ 1, 2, 3, 4, 5, 6, 7, 8, 9};
            var filteredNot = intList.WhereNot(x => x%2 == 0);
            Console.WriteLine(string.Join(", ",filteredNot));
            //
            List<string> strList = new List<string> {"gosho","pesho","pena","goga","raina","mariika","ceca"};
            var filteredNames = strList.WhereNot(n => n.Length == 4);
            Console.WriteLine(string.Join(", ",filteredNames));
        }
    }
}
