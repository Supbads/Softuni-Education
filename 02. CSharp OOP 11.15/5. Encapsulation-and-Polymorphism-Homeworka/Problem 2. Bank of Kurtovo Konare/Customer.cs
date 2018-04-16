using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Bank_of_Kurtovo_Konare
{
    public class Customer
    {
        public Customer(TypeOfCustomer typeOfCustomer)
        {
            this.TypeOfCustomer = typeOfCustomer;
        }
        public TypeOfCustomer TypeOfCustomer { get; set; }
    }
}
