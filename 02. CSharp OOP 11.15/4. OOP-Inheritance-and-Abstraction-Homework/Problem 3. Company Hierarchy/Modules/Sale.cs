using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Problem_3.Company_Hierarchy.Interfaces;

namespace Problem_3.Company_Hierarchy.Modules
{
    class Sale : ISale
    {
        private string _productName;
        private DateTime _saleDate;
        private decimal _productPrice;

        public Sale(string productName, DateTime saleDate, decimal productPrice)
        {
            this.ProductName = productName;
            this.SaleDate = saleDate;
            this.ProductPrice = productPrice;
        }

        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        public DateTime SaleDate
        {
            get { return _saleDate; }
            set { _saleDate = value; }
        }

        public decimal ProductPrice
        {
            get { return _productPrice; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Sale's price cannot be negative");
                }
                _productPrice = value;
            }
        }
    }
}
