namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class InsertionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (int firstUnsortedIndex = 0; firstUnsortedIndex < collection.Count; firstUnsortedIndex++)
            {
                int index = firstUnsortedIndex;
                while (index > 0 && collection[index - 1].CompareTo(collection[index]) > 0)
                {
                    this.Swap(collection, index, index - 1);
                    index--;
                }
            }
        }

        private void Swap(IList<T> collection, int first, int second)
        {
            T temp = collection[first];
            collection[first] = collection[second];
            collection[second] = temp;
        }
    }
}
