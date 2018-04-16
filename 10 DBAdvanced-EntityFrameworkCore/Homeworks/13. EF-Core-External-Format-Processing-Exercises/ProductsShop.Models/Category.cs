using System.ComponentModel.DataAnnotations;

namespace ProductsShop.Models
{
    using System.Collections.Generic;

    public class Category
    {
        public int Id { get; set; }

        [StringLength(15, MinimumLength = 3)]
        public string Name { get; set; }

        public ICollection<CategoryProduct> CategoryProducts { get; set; } = new List<CategoryProduct>();
    }
}