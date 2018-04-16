using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Interest_Calculator
{
    class Program
    {
        public delegate decimal CalculateInterest(decimal sumOfMoney ,decimal interest, int years);
        //4 places 
        static void Main(string[] args)
        {
            CalculateInterest compound = GetCompoundInterest;
            InterestCalculator forTheCompound = new InterestCalculator(500, 0.056m, 10, compound);
            Console.WriteLine(forTheCompound.CalculateInterest());

            CalculateInterest simple = GetSimpleInterest;
            InterestCalculator forTheSimple = new InterestCalculator(2500.0000m,0.072m,15,simple);   //without the 4 zeroes it will try to round but will run out of digits
            Console.WriteLine(forTheSimple.CalculateInterest());

        }

        public static decimal GetSimpleInterest(decimal sumOfMoney, decimal interest, int years)
        {
            decimal amount = sumOfMoney*(1 + (interest*years));
            amount = decimal.Round(amount, 4);
            return amount;
            //amount = decimal.Parse(amount.ToString("#.####"));
            //Console.WriteLine(string.Format("{0:F4}", amount));
        }

        public static decimal GetCompoundInterest(decimal sumOfMoney, decimal interest, int years)
        {
            decimal amount = sumOfMoney * (decimal)Math.Pow((1.0 + ((double)interest)/12.0), years*12);
            amount = decimal.Round(amount, 4, MidpointRounding.AwayFromZero);
            return amount;

            //amount = decimal.Parse(amount.ToString("#.####"));
            //Console.WriteLine(string.Format("{0:F4}", amount));
        }
    }
}
