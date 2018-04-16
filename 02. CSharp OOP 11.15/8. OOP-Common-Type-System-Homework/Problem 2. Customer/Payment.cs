namespace Problem_2.Customer
{
    public class Payment
    {
        public Payment(string productName, decimal price)
        {
            ProductName = productName;
            Price = price;
        }

        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
