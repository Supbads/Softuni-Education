using System;
using System.Collections.Generic;
using Problem_3.Company_Hierarchy.Interfaces;

namespace Problem_3.Company_Hierarchy.Modules
{
    class SalesEmployee : Employee, ISalesEmployee
    {
        public SalesEmployee(string firstName, string lastName, int id, decimal salary, string department, ISet<Sale> sales = null)
            : base(firstName, lastName, id, salary,department)
        {
            this.Sales = sales ?? new HashSet<Sale>();
        }

        public ISet<Sale> Sales { get; set; }
        public void AddSales(ISet<Sale> sales)
        {
            foreach (var sale in sales)
            {
                this.Sales.Add(sale);
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Number of sales: {0}{1}", this.Sales.Count,Environment.NewLine);
        }
    }
}
