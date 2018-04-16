namespace Problem_3.Collection_of_Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Problem_3.Collection_of_Products.Interfaces;
    using Wintellect.PowerCollections;

    public class ProductCollection<T> : IProductCollection<T>
        where T : IProduct, IComparable<T>
    {
        private Dictionary<int, T> productsById =
            new Dictionary<int, T>();

         private OrderedDictionary<decimal, SortedSet<T>> productsByPriceRange =
            new OrderedDictionary<decimal, SortedSet<T>>();

         private Dictionary<string, SortedSet<T>> productsByTitle =
             new Dictionary<string, SortedSet<T>>();

         private Dictionary<string, OrderedDictionary<decimal, SortedSet<T>>> productsByTitleAndPriceRange =
            new Dictionary<string, OrderedDictionary<decimal, SortedSet<T>>>(); // could try and combine this with the next
         //MultiDictionary<string, OrderedMultiDictionary<decimal, OrderedSet<Product>>> productsByTitleAndPriceRange

         private Dictionary<Supplier, OrderedDictionary<decimal, SortedSet<T>>> productsBySupplierAndPriceRange =
            new Dictionary<Supplier, OrderedDictionary<decimal, SortedSet<T>>>(); // again combining the datastructures for less memory drain
        
        public ProductCollection()
        {
            
        }

        public int Count { get; set; }

        public void Add(T product)
        {
            if (this.productsById.ContainsKey(product.Id))
            {
                //should overwrite all
                var previousProduct = this.productsById[product.Id];
                this.Remove(previousProduct);
            }

            this.productsById[product.Id] = product;

            this.productsByPriceRange.AppendValueToKey(product.Price, product);

            this.productsByTitle.AppendValueToKey(product.Title, product);

            this.productsByTitleAndPriceRange.EnsureKeyExists(product.Title);
            this.productsByTitleAndPriceRange[product.Title].EnsureKeyExists(product.Price);
            this.productsByTitleAndPriceRange[product.Title].AppendValueToKey(product.Price, product);

            this.productsBySupplierAndPriceRange.EnsureKeyExists(product.Supplier);
            this.productsBySupplierAndPriceRange[product.Supplier].EnsureKeyExists(product.Price);
            this.productsBySupplierAndPriceRange[product.Supplier].AppendValueToKey(product.Price, product);
            this.productsBySupplierAndPriceRange[product.Supplier][product.Price].Add(product);

            this.Count++;
        }

        public bool Remove(T product)
        {
            if (!this.productsById.ContainsKey(product.Id))
            {
                return false;
            }

            this.productsById.Remove(product.Id);

            this.productsByTitle[product.Title].Remove(product);

            this.productsByTitleAndPriceRange[product.Title][product.Price].Remove(product);

            this.productsByPriceRange[product.Price].Remove(product);

            this.productsBySupplierAndPriceRange[product.Supplier][product.Price].Remove(product);

            this.Count--;
            return true;
        }

        public IEnumerable<T> Find(decimal startRange, decimal endRange)
        {
            //shouldCheckforexception
            var productsInRange = this.productsByPriceRange.Range(startRange, true, endRange, true);

            return productsInRange.SelectMany(priceProductSet => priceProductSet.Value);
        }

        public IEnumerable<T> Find(string title)
        {
            //shouldCheckforexception
            return this.productsByTitle.GetValuesForKey(title);
        }

        public IEnumerable<T> Find(string title, decimal price)
        {
            //shouldCheckforexception
            return this.productsByTitleAndPriceRange[title][price];
        }

        public IEnumerable<T> Find(string title, decimal startRange, decimal endRange)
        {
            //shouldCheckforexception
            var productsOfSameTitle = this.productsByTitleAndPriceRange[title].Range(startRange,true, endRange, true);

            return productsOfSameTitle.SelectMany(priceProductSet => priceProductSet.Value);
        }

        public IEnumerable<T> Find(Supplier supplier, decimal price)
        {
            //shouldCheckforexception
            return this.productsBySupplierAndPriceRange[supplier][price];
        }

        public IEnumerable<T> Find(Supplier supplier, decimal startRange, decimal endRange)
        {
            //shouldCheckforexception
            var productsOfSameSupplier = this.productsBySupplierAndPriceRange[supplier].Range(startRange, true, endRange, true);
            
            var selectedItemsInRange = new List<T>();

            foreach (KeyValuePair<decimal, SortedSet<T>> priceAndProducts in productsOfSameSupplier)
            {
                selectedItemsInRange.AddRange(priceAndProducts.Value);
            }

            return selectedItemsInRange;
        }
    }
}
