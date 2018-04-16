using System;
using System.Collections.Generic;

namespace Problem_2.Customer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Payment> peshoPayments = new List<Payment>();
            {
                peshoPayments.Add(new Payment("bozica",2.40m));
                peshoPayments.Add(new Payment("tarator",1.80m));
                peshoPayments.Add(new Payment("marulq",4.33m));
                peshoPayments.Add(new Payment("ShkembeChorba",6.99m));

            }
            Customer pesho = new Customer("pesho","peshev","peshevski","065411","CarBorisNeshtoSi","088056165","pesho@mail.bg",peshoPayments,CustomerType.Regular);

            var gosho = (Customer)pesho.Clone();

            var petri = (Customer) gosho.Clone();
            petri.FirstName = "Petri";

            CompareCustomers(pesho, gosho);

            CompareCustomers(pesho,petri);
        }

        private static void CompareCustomers(Customer pesho, Customer gosho)
        {
            if (pesho.CompareTo(gosho) == 0)
            {
                Console.WriteLine(string.Format("{0} is equal to {1}", pesho.FirstName, gosho.FirstName));
            }
            else
            {
                Console.WriteLine(string.Format("{0} isn't equal to {1}", pesho.FirstName, gosho.FirstName));
            }
        }
    }
}
