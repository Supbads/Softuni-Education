namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.Quicksort(collection, 0, collection.Count - 1);
        }

        private void Quicksort(IList<T> collection, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int pivotIndex = this.Partition(collection, start, end);
            this.Quicksort(collection, start, pivotIndex);
            this.Quicksort(collection, pivotIndex + 1, end);
        }

        private int Partition(IList<T> collection, int start, int end)
        {
            T pivot = collection[start];
            int storeIndex = start + 1;

            for (int index = storeIndex; index <= end; index++)
            {
                if (collection[index].CompareTo(pivot) <= 0)
                {
                    this.Swap(collection, index, storeIndex);
                    storeIndex++;
                }
            }

            storeIndex--;
            this.Swap(collection, start, storeIndex);
            return storeIndex;
        }

        private void Swap(IList<T> collection, int index, int storeIndex)
        {
            if (index == storeIndex)
            {
                return;
            }

            T temp = collection[index];
            collection[index] = collection[storeIndex];
            collection[storeIndex] = temp;
        }
    }
}
