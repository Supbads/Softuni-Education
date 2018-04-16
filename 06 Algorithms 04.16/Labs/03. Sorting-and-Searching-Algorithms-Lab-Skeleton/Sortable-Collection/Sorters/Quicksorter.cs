namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;
    using Sortable_Collection.Contracts;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.Quicksort(collection, 0, collection.Count - 1);
        }

        private void Quicksort(List<T> arr, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            T pivot = arr[start];
            int storeIndex = start + 1;

            for (int i = start + 1; i <= end; i++)
            {
                if (arr[i].CompareTo(pivot) < 0)
                {
                    this.Swap(arr, i, storeIndex);
                    storeIndex++;
                }
            }

            storeIndex--;
            this.Swap(arr, storeIndex, start); // + 1 ?

            this.Quicksort(arr, start, storeIndex);
            this.Quicksort(arr, storeIndex + 1, end);
        }

        private void Swap(List<T> arr, int first, int second)
        {
            var tmp = arr[first];
            arr[first] = arr[second];
            arr[second] = tmp;
        }
    }
}
