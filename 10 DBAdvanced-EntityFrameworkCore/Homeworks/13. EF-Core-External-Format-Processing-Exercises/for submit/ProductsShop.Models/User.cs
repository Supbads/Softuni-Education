namespace ProductsShop.Models
{
    using System.Collections.Generic;

    public class User
    {
        public int Id { get; set; }

        public int? Age { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Product> ProductsBought { get; set; }

        public ICollection<Product> ProductsSold { get; set; }
    }
}