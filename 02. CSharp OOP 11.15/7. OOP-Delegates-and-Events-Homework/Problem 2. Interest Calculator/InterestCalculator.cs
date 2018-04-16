using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Interest_Calculator
{
    class InterestCalculator
    {
        private decimal sumOfMoney;
        private decimal interest;
        private int years;
        private Program.CalculateInterest calculatInterest;

        public InterestCalculator(decimal sumOfMoney, decimal interest, int years, Program.CalculateInterest calculatInterest)
        {
            this.sumOfMoney = sumOfMoney;
            this.interest = interest;
            this.years = years;
            this.calculatInterest = calculatInterest;
        }

        public decimal CalculateInterest()
        {
            return calculatInterest(sumOfMoney, interest, years);
        }
    }
}
