namespace Sortable_Collection
{
    using System;

    using Sortable_Collection.Sorters;

    public class SortableCollectionPlayground
    {
        private static Random Random = new Random();

        public static void Main(string[] args)
        {
            const int NumberOfElementsToSort = 22;
            const int MaxValue = 150;

            var array = new int[NumberOfElementsToSort];

            for (int i = 0; i < NumberOfElementsToSort; i++)
            {
                array[i] = Random.Next(MaxValue);
            }

            var collectionToSort = new SortableCollection(array);
            collectionToSort.Sort(new BucketSorter { Max = MaxValue });

            Console.WriteLine(collectionToSort);

            var collection = new SortableCollection(2, -1, 5, 0, -3, 10, 8, -5, 12, 9, -2);
            Console.WriteLine(collection);

            collection.Sort(new Quicksorter<int>());
            Console.WriteLine(collection);

            collection.Shuffle();
            Console.WriteLine(collection);
        }
    }
}
