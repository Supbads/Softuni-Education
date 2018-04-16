namespace Problem_3.Company_Hierarchy.Interfaces
{
    interface ICustomer
    {
        decimal PurchaseAmount { get; set; }
        void AddPurchasePrice(decimal purchasePrice);
        string ToString();
    }
}
