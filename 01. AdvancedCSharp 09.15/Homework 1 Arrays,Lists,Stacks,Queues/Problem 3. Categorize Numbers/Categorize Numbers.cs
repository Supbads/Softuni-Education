using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ProgramCategorizeNumbers
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string[] split = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

        double[] numbers = new double[split.GetLength(0)];

        for (int i = 0; i < split.Length; i++)
        {
            numbers[i]= double.Parse(split[i]);
        }

        var whole = new List<double>();
        var floating = new List<double>();

        double wholeAvrg, floatingAvrg;
        int wholeSum = 0;
        double floatingSum = 0.0;
        int smallestWhole = int.MaxValue;
        double smallestFloat = double.MaxValue;
        int biggestWhole = int.MinValue;
        double biggestFloat = double.MinValue;

        foreach (var number in numbers)
        {
            if(number%1==0)
            {
                whole.Add(number);
            }
            else
            {
                floating.Add(number);
            }
        }


        foreach (var num in whole)
        {
            if(num<smallestWhole)
            {
                smallestWhole = (int)num;
            }
            if(num>biggestWhole)
            {
                biggestWhole=(int)num;
            }
            wholeSum += (int)num;

        }
        wholeAvrg = (double)wholeSum / whole.Count;

        foreach (var num in floating)
        {
            if(num<smallestFloat)
            {
                smallestFloat = num;
            }
            if (num > biggestFloat)
            {
                biggestFloat = num;
            }
            floatingSum += num;
        }
        floatingAvrg = floatingSum / floating.Count;

        StringBuilder sbFloat = new StringBuilder();
        StringBuilder sbWhole = new StringBuilder();

        foreach (var num in floating)
        {
            sbFloat.Append(num + " ");
        }

        foreach (var num in whole)
        {
            sbWhole.Append(num + " ");
        }

        string wholes = sbWhole.ToString();
        string floats = sbFloat.ToString();
        wholes.Trim();
        floats.Trim();

        Console.WriteLine(string.Format("[" + wholes + "]" + "-> min: {0}, max: {1}, sum: {2}, avg: {3:F2}",smallestWhole,biggestWhole,wholeSum,wholeAvrg));
        Console.WriteLine(string.Format("[" + floats + "]" + "-> min: {0}, max: {1}, sum: {2}, avg: {3:F2}", smallestFloat, biggestFloat, floatingSum, floatingAvrg));
    }
}
