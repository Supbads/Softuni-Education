namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sortable_Collection.Contracts;

    public class BucketSorter : ISorter<int>
    {
        public double Max { get; set; }

        public void Sort(IList<int> collection)
        {
            var buckets = new List<int>[collection.Count];
            this.StoreNumbersInBuckets(collection, buckets);

            var sorter = new InsertionSorter<int>();
            this.SortBuckets(buckets, sorter);

            this.SaveSortedNumbers(collection, buckets);
        }

        private void StoreNumbersInBuckets(IList<int> collection, IList<int>[] buckets)
        {
            foreach (var element in collection)
            {
                int bucketIndex = (int)((element / this.Max) * collection.Count);

                if (buckets[bucketIndex] == null)
                {
                    buckets[bucketIndex] = new List<int>();
                }

                buckets[bucketIndex].Add(element);
            }
        }

        private void SaveSortedNumbers(IList<int> collection, IList<int>[] buckets)
        {
            int index = 0;
            foreach (var bucket in buckets)
            {
                if (bucket == null)
                {
                    continue;
                }

                foreach (var num in bucket)
                {
                    collection[index] = num;
                    index++;
                }
            }
        }

        private void SortBuckets(IList<int>[] buckets, ISorter<int> sorter)
        {
            foreach (var bucket in buckets)
            {
                if (bucket == null)
                {
                    continue;
                }

                sorter.Sort(bucket);
            }
        }
    }
}
