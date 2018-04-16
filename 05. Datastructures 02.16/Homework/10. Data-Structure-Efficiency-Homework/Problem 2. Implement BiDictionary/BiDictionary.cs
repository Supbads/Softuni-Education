namespace Problem_2.Implement_BiDictionary
{
    using System;
    using System.Collections.Generic;

    public class BiDictionary<K1, K2, T>
        where T : IComparable<T>
    {
        private Dictionary<K1, List<T>> valuesByFirstKey =
            new Dictionary<K1, List<T>>();

        private Dictionary<K2, List<T>> valuesBySecondKey =
            new Dictionary<K2, List<T>>();

        private Dictionary<Tuple<K1, K2>, List<T>> valuesByBothKeys =
            new Dictionary<Tuple<K1, K2>, List<T>>();

        public void Add(K1 key1, K2 key2, T value)
        {
            this.valuesByFirstKey.AppendValueToKey(key1, value);

            this.valuesBySecondKey.AppendValueToKey(key2, value);

            var combinedKey = this.CombineKeys(key1, key2);

            this.valuesByBothKeys.AppendValueToKey(combinedKey, value);
        }

        public IEnumerable<T> Find(K1 key1, K2 key2)
        {
            var collection = new List<T>();
            var combinedKey = this.CombineKeys(key1, key2);
            this.valuesByBothKeys.TryGetValue(combinedKey, out collection);

            return collection;
        }

        public IEnumerable<T> FindByKey1(K1 key1)
        {
            var collection = new List<T>();
            this.valuesByFirstKey.TryGetValue(key1, out collection);

            return collection;
        }

        public IEnumerable<T> FindByKey2(K2 key2)
        {
            var collection = new List<T>();
            this.valuesBySecondKey.TryGetValue(key2, out collection);

            return collection;
        }

        public bool Remove(K1 key1, K2 key2)
        {
            bool isRemoved = false;

            var combinedKey = this.CombineKeys(key1, key2);

            if (this.valuesByBothKeys.ContainsKey(combinedKey))
            {
                foreach (var value in this.valuesByBothKeys[combinedKey])
                {
                    this.valuesByFirstKey[key1].Remove(value);
                    this.valuesBySecondKey[key2].Remove(value);
                }

                this.valuesByBothKeys.Remove(combinedKey);

                isRemoved = true;
            }

            return isRemoved;
        }

        private Tuple<K1, K2> CombineKeys(K1 key1, K2 key2)
        {
            return new Tuple<K1, K2>(key1, key2);
        }
        //private bool Find(T element)
        //{

        //}
        //private bool CheckForDuplicate(ICollection<T> collection, T value)
        //{

        //}
    }
}