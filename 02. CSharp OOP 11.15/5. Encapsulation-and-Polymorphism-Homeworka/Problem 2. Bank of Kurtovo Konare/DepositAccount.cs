using System;

namespace Problem_2.Bank_of_Kurtovo_Konare
{
    class DepositAccount : Account
    {
        public DepositAccount(Customer customer, decimal balance, decimal interestRate) : base(customer, balance, interestRate)
        {
        }
         public override decimal CalculateInterest(decimal money, int months)
        {
            if (money < 1000)
            {
                return 0;
            }
            return money * (1 + this.InterestRate * months);
        }

        public decimal WithdrawMoney(decimal amount)
        {
            if (this.Balance < amount)
            {
                throw new ArgumentException("balance","Cannot withdraw more money than the current balance"); //redundant but more specfic in this case
            }
            else
            {
                this.Balance -= amount;
                return amount;
            }
        }
    }
}
