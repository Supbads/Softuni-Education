using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Most_Frequent_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputDirecotry = @"../../input.txt";
            string outputDirecotry = @"../../output.txt";

            Dictionary<string, int> map = new Dictionary<string, int>();

            var input = File.ReadAllText(inputDirecotry).Split().ToArray();

            foreach (var number in input)
            {
                if (!map.ContainsKey(number))
                {
                    map.Add(number, 0);
                }

                map[number]++;
            }


            var mostFrequentNumber = map.OrderByDescending(x => x.Value).Select(x => x.Key).FirstOrDefault();
            File.WriteAllText(outputDirecotry, mostFrequentNumber);

        }
    }
}
