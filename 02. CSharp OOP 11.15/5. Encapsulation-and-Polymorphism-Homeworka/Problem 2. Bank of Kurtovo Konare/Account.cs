using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Bank_of_Kurtovo_Konare
{
    public abstract class Account
    {
        private Customer customer;
        private decimal balance;
        private decimal interestRate; //monthly
        protected Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public Customer Customer
        {
            get { return customer; }
            private set { customer = value; }
        }

        public decimal Balance
        {
            get { return balance; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("balance", "Balance cannot be negative");
                }
                balance = value;
            }
        }

        public decimal InterestRate
        {
            get { return interestRate; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("interestRate", "Interest rate cannot be negative");
                }
                interestRate = value;
            }
        }

        public abstract decimal CalculateInterest(decimal money, int months);
        protected virtual decimal WithrawMoney(decimal amount)
        {
            if (this.Balance < amount)
            {
                throw new ArgumentException("balance", "Cannot withdraw more money than the current balance"); //redundant but more specfic in this case
            }
            else
            {
                this.Balance -= amount;
                return amount;
            }
        }

        public virtual void DepositMoney(decimal amount)
        {
            this.Balance += amount;
        }

    }
}
