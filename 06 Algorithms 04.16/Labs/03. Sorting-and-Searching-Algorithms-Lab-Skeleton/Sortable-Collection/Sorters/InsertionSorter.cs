namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;
    using Sortable_Collection.Contracts;

    public class InsertionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            // not sure if the task is insertion sort since it should be swapping: https://en.wikipedia.org/wiki/Insertion_sort
            // insertion sort swaps elements until they are at the right place while
            // also doing 2N operations is pretty costy (insertAt, removeAt)

            for (int i = 1; i < collection.Count; i++)
            {
                var element = collection[i];
                int targetIndex = i;

                while (targetIndex > 0 && collection[targetIndex - 1].CompareTo(element) > 0)
                {
                    collection[targetIndex] = collection[targetIndex - 1];
                    targetIndex--;
                }

                collection[targetIndex] = element;
            }
        }
    }
}