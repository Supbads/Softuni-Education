namespace P01_BillsPaymentSystem
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Data;
    using System;
    using Data.Models;
    using Data.Models.enums;

    class StartUp
    {
        static void Main(string[] args)
        {

            using (var context = new BillsPaymentSystemContext())
            {
                context.Database.EnsureDeleted();
                context.Database.Migrate();
                Seed(context);

                //User Details
                UserDetails(context);

                //Pay bills
                Console.Write("Enter userId: ");
                var userId = int.Parse(Console.ReadLine());
                Console.Write("Enter amount for bill pays: ");
                var amount = decimal.Parse(Console.ReadLine());

                try
                {
                    PayBills(userId, amount, context);
                    Console.WriteLine("Bills have been successfully paid.");
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }


            }

        }

        private static void UserDetails(BillsPaymentSystemContext context)
        {
            Console.Write("Enter a UserId to view Details: ");
            int id = int.Parse(Console.ReadLine());

            var userDetails = context.Users.Where(u => u.UserId == id)
                .Select(u => new
                {
                    Name = $"{u.FirstName} {u.LastName}",
                    CreditCards = u.PaymentMethods
                        .Where(pm => pm.Type == PaymentType.CreditCard).Select(pm => pm.CreditCard).ToList(),
                    BankAccounts = u.PaymentMethods
                        .Where(pm => pm.Type == PaymentType.BankAccount).Select(pm => pm.BankAccount).ToList()
                }).SingleOrDefault();


            if (userDetails == null)
            {
                Console.WriteLine($"User with id {id} not found!");
            }

            Console.WriteLine($@"User: {userDetails.Name}");

            if (userDetails.BankAccounts.Any())
            {
                Console.WriteLine("Bank Accounts: ");

                foreach (BankAccount bankAccount in userDetails.BankAccounts)
                {
                    Console.WriteLine($"-- ID: {bankAccount.BankAccountId}");
                    Console.WriteLine($"--- Balance: {bankAccount.Balance:F2}");
                    Console.WriteLine($"--- Bank: {bankAccount.BankName}");
                    Console.WriteLine($"--- SWIFT: {bankAccount.SwiftCode}");
                }
            }
            if (userDetails.CreditCards.Any())
            {
                Console.WriteLine("Credit Cards: ");

                foreach (CreditCard creditCard in userDetails.CreditCards)
                {
                    Console.WriteLine($"-- ID: {creditCard.CreditCardId}");
                    Console.WriteLine($"--- Money Owed: {creditCard.MoneyOwed:F2}");
                    Console.WriteLine($"--- Limit Left: {creditCard.LimitLeft}");
                    Console.WriteLine($"--- Expiration Date: {creditCard.ExpirationDate}");
                }
            }
        }

        private static void Seed(BillsPaymentSystemContext context)
        {
            var firstAcc = new BankAccount
            {
                BankName = "First Investment Bank",
                SwiftCode = "FINVBGSF",
            };
            firstAcc.Deposit(1000);

            var secondAcc = new BankAccount
            {
                BankName = "Unicredit Bulbank",
                SwiftCode = "UNCRBGSF"
            };
            secondAcc.Deposit(5000);

            context
                .BankAccounts
                .AddRange(firstAcc, secondAcc);

            context.SaveChanges();

            var firstCreditCard = new CreditCard(1000, 200) {ExpirationDate = new DateTime(2020, 01, 01)};

            var secondCreditCard = new CreditCard(2000, 500) {ExpirationDate = new DateTime(2020, 01, 01)};

            context
                .CreditCards
                .AddRange(firstCreditCard, secondCreditCard);

            context.SaveChanges();

            var ivan = new User
            {
                FirstName = "Ivan",
                LastName = "Ivanov",
                Email = "ivan@abv.bg",
                Password = "123456"
            };

            var pesho = new User
            {
                FirstName = "Petur",
                LastName = "Petrov",
                Email = "petur@abv.bg",
                Password = "123456"
            };

            context
                .Users
                .AddRange(ivan, pesho);

            context.SaveChanges();

            var firstPayment = new PaymentMethod
            {
                BankAccount = firstAcc,
                User = ivan,
                Type = PaymentType.BankAccount,
            };

            var secondPayment = new PaymentMethod
            {
                BankAccount = secondAcc,
                User = pesho,
                Type = PaymentType.BankAccount
            };

            var thirdPayment = new PaymentMethod
            {
                CreditCard = firstCreditCard,
                User = pesho,
                Type = PaymentType.CreditCard
            };

            var fourthPayment = new PaymentMethod
            {
                CreditCard = secondCreditCard,
                User = ivan,
                Type = PaymentType.CreditCard
            };

            context
                .PaymentMethods
                .AddRange(firstPayment, secondPayment, thirdPayment, fourthPayment);
            context.SaveChanges();
        }

        private static void PayBills(int userId, decimal amount, BillsPaymentSystemContext context)
        {

            var user = context.Users.Find(userId);

            if (user == null)
            {
                Console.WriteLine($"User with id {userId} not found!");
                return;
            }

            decimal TotalMoneyAvailableForUser = 0m;

            var bankAccounts = context
                .BankAccounts.Join(context.PaymentMethods,
                    (ba => ba.BankAccountId),
                    (p => p.BankAccountId),
                    (ba, p) => new
                    {
                        UserId = p.UserId,
                        BankAccountId = ba.BankAccountId,
                        Balance = ba.Balance
                    })
                .Where(ba => ba.UserId == userId)
                .ToList();


            var creditCards = context
                .CreditCards.Join(context.PaymentMethods,
                    (c => c.CreditCardId),
                    (p => p.CreditCardId),
                    (c, p) => new
                    {
                        UserId = p.UserId,
                        CreditCardId = c.CreditCardId,
                        LimitLeft = c.LimitLeft
                    })
                .Where(c => c.UserId == userId)
                .ToList();

            TotalMoneyAvailableForUser += bankAccounts.Sum(b => b.Balance);
            TotalMoneyAvailableForUser += creditCards.Sum(c => c.LimitLeft);

            if (TotalMoneyAvailableForUser < amount)
            {
                throw new InvalidOperationException("Insufficient funds!");
            }

            bool isBillPayed = false;
            foreach (var bankAccount in bankAccounts.OrderBy(b => b.BankAccountId))
            {
                var currentAccount = context.BankAccounts.Find(bankAccount.BankAccountId);

                if (amount <= currentAccount.Balance)
                {
                    currentAccount.Withdraw(amount);
                    isBillPayed = true;
                }
                else
                {
                    amount -= currentAccount.Balance;
                    currentAccount.Withdraw(currentAccount.Balance);
                }

                if (isBillPayed)
                {
                    context.SaveChanges();
                    return;
                }
            }

            foreach (var creditCard in creditCards.OrderBy(c => c.CreditCardId))
            {
                var currentCreditCard = context.CreditCards.Find(creditCard.CreditCardId);

                if (amount <= currentCreditCard.LimitLeft)
                {
                    currentCreditCard.Withdraw(amount);
                    isBillPayed = true;
                }
                else
                {
                    amount -= currentCreditCard.LimitLeft;
                    currentCreditCard.Withdraw(currentCreditCard.LimitLeft);
                }

                if (isBillPayed)
                {
                    context.SaveChanges();
                    return;
                }
            }

        }


    }
}