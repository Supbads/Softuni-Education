namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;
    using Sortable_Collection.Contracts;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.MergeSort(collection, 0, collection.Count - 1);
        }

        private void MergeSort(IList<T> collection, int startIndex, int endIndex)
        {
            if (endIndex <= startIndex)
            {
                return;
            }

            int middle = (endIndex + startIndex) / 2;
            this.MergeSort(collection, startIndex, middle);
            this.MergeSort(collection, middle + 1, endIndex);

            int left = startIndex;
            int right = middle + 1;
            int result = 0;
            T[] temp = new T[endIndex - startIndex + 1];

            while (left <= middle && right <= endIndex)
            {
                if (collection[left].CompareTo(collection[right]) <= 0)
                {
                    temp[result++] = collection[left++];
                }
                else
                {
                    temp[result++] = collection[right++];
                }
            }
            while (left <= middle)
            {
                temp[result++] = collection[left++];
            }
            while (right <= endIndex)
            {
                temp[result++] = collection[right++];
            }

            for (int i = startIndex; i < startIndex + temp.Length; i++)
            {
                collection[i] = temp[i - startIndex];
            }
        }
    }
}
