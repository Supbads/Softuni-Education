using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SubsetSums
{
    static void Main(string[] args)
    {
        int sum = int.Parse(Console.ReadLine());
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        List<int> noDuplicates = numbers.ToList();
        noDuplicates = noDuplicates.Distinct().ToList();
        // generate subsets
        var subsets = from m in Enumerable.Range(0, 1 << noDuplicates.Count)
                      select
                          from i in Enumerable.Range(0, noDuplicates.Count)
                          where (m & (1 << i)) != 0
                          select noDuplicates[i];
        // check subsets' sums and print them
        bool noOutput = true;
     
        foreach (var item in subsets)
        {
            int sumTemp = 0;
            foreach (var number in item)
            {
                sumTemp += Convert.ToInt32(number);
            }
            if (sumTemp == sum && item.Count() > 0)
            {
                Console.WriteLine(string.Join(" + ", item) + " = {0}", sum);
                noOutput = false;
            }
        }
        if (noOutput)
            Console.WriteLine("No matching subsets.");

    }
}
