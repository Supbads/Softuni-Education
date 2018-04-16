namespace Problem_3.Collection_of_Products.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IProductCollection<T>
        where T : IComparable<T>, IProduct
    {
        /*  
        •	Add new product (if the id already exists, the new product replaces the old one)
            Replaces if already exists! Dictionary<string, Product>
        •	Remove product by id – returns true or false
            searches the dictionary above and deletes etc.
        •	Find products in given price range [x…y] – returns the products sorted by id
            OrderedMultiDictionary<decimal price, Product>
            OrderedDictionary<decimal price, OrderedSet<Product>>
        •	Find products by title – returns the products sorted by id
            MultiDictionary<string title, OrderedSet<Product>>
        •	Find products by title + price – returns the products sorted by id
            MultiDictionary<string title, MultiDictinary<decimal, OrderedSet<Product>>>
        •	Find products by title + price range – returns the products sorted by id
            MultiDictionary<string title, OrderedMultiDictionary<decimal, OrderedSet<Product>>>
        •	Find products by supplier + price – returns the products sorted by id
            MultiDictionary<Supplier, MultiDictionary<decimal, OrderedSet<Product>>>
        •	Find products by supplier + price range – returns the products sorted by id       
            MultiDictionary<Supplier, OrderedMultiDictionary<decimal, OrderedSet<Product>>>
        */
        void Add(T product);

        bool Remove(T product);

        IEnumerable<T> Find(decimal startRange, decimal endRange);

        IEnumerable<T> Find(string title);

        IEnumerable<T> Find(string title, decimal price);

        IEnumerable<T> Find(string title, decimal startRange, decimal endRange);

        IEnumerable<T> Find(Supplier supplier, decimal price);

        IEnumerable<T> Find(Supplier supplier, decimal startRange, decimal endRange);
    }
}
