namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class HeapSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.HeapSort(collection);
        }

        private void HeapSort(IList<T> collection)
        {
            for (int index = collection.Count / 2; index >= 0; index--)
            {
                this.HeapifyDown(collection, index, collection.Count);
            }

            this.OrderElements(collection, collection.Count - 1);
        }

        private void OrderElements(IList<T> collection, int lastIndex)
        {
            if (lastIndex < 1)
            {
                return;
            }

            T currentMax = collection[0];
            collection[0] = collection[lastIndex];
            collection[lastIndex] = currentMax;
            this.HeapifyDown(collection, 0, lastIndex);
            this.OrderElements(collection, lastIndex - 1);
        }

        private void HeapifyDown(IList<T> collection, int index, int endIndex)
        {
            int leftChild = (2 * index) + 1;
            int rightChild = (2 * index) + 2;

            int largest = index;

            if (leftChild < endIndex && collection[leftChild].CompareTo(collection[largest]) > 0)
            {
                largest = leftChild;
            }
            if (rightChild < endIndex && collection[rightChild].CompareTo(collection[largest]) > 0)
            {
                largest = rightChild;
            }

            if (largest != index)
            {
                T old = collection[index];
                collection[index] = collection[largest];
                collection[largest] = old;
                this.HeapifyDown(collection, largest, endIndex);
            }
        }
    }
}
