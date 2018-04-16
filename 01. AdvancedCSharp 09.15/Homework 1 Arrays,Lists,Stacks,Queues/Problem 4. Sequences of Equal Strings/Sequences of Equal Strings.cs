using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SequancesOfEqualStrings
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string[] strings = input.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < strings.Length - 1; i++)
        {
            Console.Write(strings[i] + " ");
            if (!strings[i].Equals(strings[i + 1]))
            {
                Console.WriteLine();
            }
        }
        Console.Write(strings[strings.Length - 1]);
        Console.WriteLine();



        //    int[] max = seq.Select((n, i) => new { Value = n, Index = i })
        //    .OrderBy(s => s.Value)
        //    .Select((o, i) => new { Value = o.Value, Diff = i - o.Index })
        //    .GroupBy(s => new { s.Value, s.Diff })
        //    .OrderByDescending(g => g.Count())
        //    .First()
        //    .Select(f => f.Value)
        //    .ToArray();

    }
}
