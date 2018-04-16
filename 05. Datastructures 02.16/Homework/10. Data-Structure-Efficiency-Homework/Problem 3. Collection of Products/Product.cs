namespace Problem_3.Collection_of_Products
{
    using System;
    using Problem_3.Collection_of_Products.Interfaces;

    public class Product : IProduct, IComparable<Product>
    {
        public Product(int id, string title, Supplier supplier, decimal price)
        {
            this.Id = id;
            this.Title = title;
            this.Supplier = supplier;
            this.Price = price;
        }

        public Product()
        {
            
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public Supplier Supplier { get; set; }

        public decimal Price { get; set; }

        public int CompareTo(Product other)
        {
            return this.Id.CompareTo(other.Id);
        }

        public override string ToString()
        {
            string representation = "Product: " + this.Title + " with id: " + this.Id + " and price: " + this.Price;
            return representation;
        }
    }
}
