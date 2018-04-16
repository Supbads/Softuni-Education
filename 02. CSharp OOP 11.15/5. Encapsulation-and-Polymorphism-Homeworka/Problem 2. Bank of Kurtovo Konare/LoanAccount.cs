namespace Problem_2.Bank_of_Kurtovo_Konare
{
    class LoanAccount : Account
    {
        public LoanAccount(Customer customer, decimal balance, decimal interestRate) : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterest(decimal money, int months)
        {
            if (this.Customer.TypeOfCustomer == TypeOfCustomer.Individual && months<=3)
            {
                return 0;
            }

            if (months < 2 && this.Customer.TypeOfCustomer == TypeOfCustomer.Company)
            {
                return 0;
            }

            return money * (1 + this.InterestRate * months);
        }
    }
}
