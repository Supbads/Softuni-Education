using System;
using System.Text;
using Problem_3.Company_Hierarchy.Interfaces;

namespace Problem_3.Company_Hierarchy.Modules
{
    class Customer : Person, ICustomer
    {
        private decimal _purchaseAmount;
        public Customer(string firstName, string lastName, int id)
            : base(firstName, lastName, id)
        {
        }

        public decimal PurchaseAmount
        {
            get { return _purchaseAmount; }
            set
            {
                if (value < 0m)
                {
                    throw new ArgumentOutOfRangeException("Purchase ammount cannot be negative");
                }
                _purchaseAmount = value;
            }
        }

        public void AddPurchasePrice(decimal purchasePrice)
        {
            this.PurchaseAmount += purchasePrice;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            result.AppendFormat("Purchases ammount: {0}{1}", this._purchaseAmount,Environment.NewLine);

            return result.ToString();
        }
    }
}
