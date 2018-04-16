using System;


namespace P03_SalesDatabase.Data.Models
{
    public class Sale
    {
        public Sale()
        {
        }

        public Sale(DateTime date, int productId, int customerId, int storeId)
        {
            this.Date = date;
            this.ProductId = productId;
            this.CustomerId = customerId;
            this.StoreId = storeId;
        }

        public int SaleId { get; set; }
        public DateTime Date { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int StoreId { get; set; }
        public Store Store { get; set; }
    }
}