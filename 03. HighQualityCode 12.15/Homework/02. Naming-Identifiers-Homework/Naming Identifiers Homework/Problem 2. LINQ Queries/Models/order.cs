namespace Orders.Models
{
    public class Order
    {
        public int ID { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public decimal Discount { get; set; }
    }
}
