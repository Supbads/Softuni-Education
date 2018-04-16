using System.Collections.Generic;
using Problem_3.Company_Hierarchy.Modules;

namespace Problem_3.Company_Hierarchy.Interfaces
{
    interface ISalesEmployee
    {
        ISet<Sale> Sales { get; set; }
        void AddSales(ISet<Sale> sales);
        string ToString();
    }
}
