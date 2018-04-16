namespace Problem_3.Collection_of_Products.Interfaces
{
    public interface IProduct
    {
        int Id { get; set; }

        string Title { get; set; }

        Supplier Supplier { get; set; }

        decimal Price { get; set; }
    }
}
