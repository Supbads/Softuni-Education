using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

class NumberCalculations
{
    static void Main(string[] args)
    {
        //List<int> numbersInt = (Console.ReadLine().Split(' ').Select(int.Parse).ToList());
        //List<decimal> numbersDec = (Console.ReadLine().Split(' ').Select(decimal.Parse).ToList());
        //List<double> numbersDouble = (Console.ReadLine().Split(' ').Select(double.Parse).ToList());

        List<int> numbersInt      = new List<int> {4,20,13,18,0,260,-80 };  
        List<decimal> numbersDec  = new List<decimal> {7.7164324m,-4.45618m, 74891.48919m,-481198161 };
        List<double> numbersDouble = new List<double> {4.9458998f,5641.5641651f,464616175.5646188f, 75119849.456161f };

        NumberCalculation(numbersInt);
        Console.WriteLine();
        NumberCalculation(numbersDec);
        Console.WriteLine();
        NumberCalculation(numbersDouble);
    }

    static void NumberCalculation(List<int> numberSet)
    {

        int product = 1;
        Console.WriteLine("Ints:\n");
        int sum = 0;
        int smallest = int.MaxValue;
        int biggest = int.MinValue;
        foreach (var number in numberSet)
        {
            product *= number;
            sum += number;
            if(number>biggest)
            {
                biggest = number;
            }
            if(number<smallest)
            {
                smallest = number;
            }
        }
        double average = sum / numberSet.Count;
        Console.WriteLine("Min: {0}, Max: {1}, Average: {2}, Sum: {3}", smallest, biggest, average, sum);
        Console.Write("Product: {0}", product);
    }

    static void NumberCalculation(List<decimal> numberSet)
    {
        decimal product = 1;
        decimal sum = 0;
        decimal smallest = decimal.MaxValue;
        decimal biggest = decimal.MinValue;
        Console.WriteLine("Decimals:\n");
        foreach (var number in numberSet)
        {
            product *= number;
            sum += number;
            if (number > biggest)
            {
                biggest = number;
            }
            if (number < smallest)
            {
                smallest = number;
            }
        }
        decimal average = sum / numberSet.Count;
        Console.WriteLine("Min: {0}, Max: {1}, Average: {2}, Sum: {3}", smallest, biggest, average, sum);
        Console.Write("Product: {0}", product);
    }

    static void NumberCalculation(List<double> numberSet)
    {
        double product = 1;
        double smallest = double.MaxValue;
        double biggest = double.MinValue;
        double sum = 0;
        Console.WriteLine("Double:\n");
        foreach (var number in numberSet)
        {
            product *= number;
            sum += number;
            if (number > biggest)
            {
                biggest = number;
            }
            if (number < smallest)
            {
                smallest = number;
            }
        }
        double average = sum / numberSet.Count;
        Console.WriteLine("Min: {0}, Max: {1}, Average: {2}, Sum: {3}", smallest, biggest, average, sum);
        Console.Write("Product: {0}", product);
    }
}