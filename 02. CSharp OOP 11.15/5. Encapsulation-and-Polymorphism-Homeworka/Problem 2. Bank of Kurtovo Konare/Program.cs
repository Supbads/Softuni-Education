using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Bank_of_Kurtovo_Konare
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer shell = new Customer(TypeOfCustomer.Company);
            DepositAccount bankaDSK = new DepositAccount(shell, 12112m, 3.4m);

            Console.WriteLine("shell balance: " + bankaDSK.Balance);
            bankaDSK.DepositMoney(100m);
            Console.WriteLine("shell balance: " + bankaDSK.Balance);
            bankaDSK.WithdrawMoney(1000m);
            Console.WriteLine("shell balance: " + bankaDSK.Balance);
            Console.WriteLine("shell interest rate for 2months 1k (company): " + bankaDSK.CalculateInterest(1000,2));
            Console.WriteLine();

            Customer gosho = new Customer(TypeOfCustomer.Individual);
            LoanAccount fiBank = new LoanAccount(gosho,28.60m,1m);
            Console.WriteLine("fibank balance: " + fiBank.Balance);
            fiBank.DepositMoney(24m);
            Console.WriteLine("fibank balance: " + fiBank.Balance);
            Console.WriteLine("fibank interest rate for 4months 290 (individual): " + fiBank.CalculateInterest(290, 4));
        }
    }
}
