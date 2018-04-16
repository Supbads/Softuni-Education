using System;

namespace Problem_3.Company_Hierarchy.Interfaces
{
    interface ISale
    {       
        string ProductName { get; set; }
        DateTime SaleDate { get; set; }
        decimal ProductPrice { get; set; }
    }
}
