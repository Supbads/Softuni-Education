using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Bank_of_Kurtovo_Konare
{
    class MortgageAccount : Account
    {
        public MortgageAccount(Customer customer, decimal balance, decimal interestRate) : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterest(decimal money, int months)
        {
            if (months <= 12 && this.Customer.TypeOfCustomer == TypeOfCustomer.Company)
            {
                return (money * (1 + this.InterestRate * months))/2m;
            }
            if (months <= 6 && this.Customer.TypeOfCustomer == TypeOfCustomer.Individual)
            {
                return 0;
            }
            return money * (1 + this.InterestRate * months);
        }
    }
}
