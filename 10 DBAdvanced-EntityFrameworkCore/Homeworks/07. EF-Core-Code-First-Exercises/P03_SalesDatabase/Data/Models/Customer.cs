using System.Collections.Generic;

namespace P03_SalesDatabase.Data.Models
{
    public class Customer
    {
        public Customer()
        {
        }

        public Customer(string name, string email, string creditCardNumber)
        {
            this.Name = name;
            this.Email = email;
            this.CreditCardNumber = creditCardNumber;
        }

        public int CustomerId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string CreditCardNumber { get; set; }

        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}