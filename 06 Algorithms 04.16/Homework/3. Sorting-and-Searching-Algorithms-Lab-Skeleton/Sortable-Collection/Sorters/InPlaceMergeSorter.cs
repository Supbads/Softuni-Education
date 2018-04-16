namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;
    using Sortable_Collection.Contracts;

    public class InPlaceMergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.InPlaceMergeSort(collection, 0, collection.Count - 1);
        }

        private void InPlaceMergeSort(IList<T> collection, int startIndex, int endIndex)
        {
            if (endIndex <= startIndex)
            {
                return;
            }

            int middle = (startIndex + endIndex) / 2;
            this.InPlaceMergeSort(collection, startIndex, middle);
            this.InPlaceMergeSort(collection, middle + 1, endIndex);

            this.MergeInPlace(collection, startIndex, middle, middle + 1, endIndex, startIndex);
        }

        private void MergeInPlace(IList<T> collection, int left, int middle, int right, int last, int index)
        {
            if (collection[middle].CompareTo(collection[right]) <= 0)
            {
                return;
            }

            while (left <= middle && right <= last)
            {
                if (collection[left].CompareTo(collection[right]) <= 0)
                {
                    left++;
                    index++;
                }
                else
                {
                    T temp = collection[right];
                    collection.RemoveAt(right);
                    collection.Insert(left, temp);

                    left++;
                    middle++;
                    index++;
                    right++;
                }
            }
        }

        private void Swap(IList<T> collection, int original, int indexToSwap)
        {
            if (original == indexToSwap)
            {
                return;
            }

            T temp = collection[original];
            collection[original] = collection[indexToSwap];
            collection[indexToSwap] = temp;
        }
    }
}
