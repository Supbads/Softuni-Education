namespace Sortable_Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sortable_Collection.Contracts;

    public class SortableCollection
    {
        public SortableCollection() : this(Enumerable.Empty<int>())
        {
        }

        public SortableCollection(IEnumerable<int> items)
        {
            this.Items = new List<int>(items);
        }

        public SortableCollection(params int[] items)
            : this(items.AsEnumerable())
        {
        }

        public List<int> Items { get; private set; }

        public int Count => this.Items.Count;

        public void Sort(ISorter<int> sorter)
        {
            sorter.Sort(this.Items);
        }

        public int BinarySearch(int item)
        {
            return this.BinarySearchProcedure(item, 0, this.Count - 1);
        }

        public int InterpolationSearch(int item)
        {
            return this.InterpolationSearchProcedure(item, 0, this.Count - 1);
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            for (int i = 0; i < this.Count; i++)
            {
                int index = i + rnd.Next(0, this.Count - i);
                var temp = this.Items[i];
                this.Items[i] = this.Items[index];
                this.Items[index] = temp;
            }
        }

        public int[] ToArray()
        {
            return this.Items.ToArray();
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", this.Items)}]";
        }

        private int BinarySearchProcedure(int item, int startIndex, int endIndex)
        {
            if (endIndex < startIndex)
            {
                return -1;
            }

            int midPoint = (endIndex + startIndex) / 2;

            if (this.Items[midPoint].CompareTo(item) > 0)
            {
                return BinarySearchProcedure(item, startIndex, midPoint - 1);
            }
            if (this.Items[midPoint].CompareTo(item) < 0)
            {
                return BinarySearchProcedure(item, midPoint + 1, endIndex);
            }

            return midPoint;
        }

        private int InterpolationSearchProcedure(int item, int start, int end)
        {
            if (end < start)
            {
                return -1;
            }

            if (this.Items[start].CompareTo(item) > 0 || this.Items[end].CompareTo(item) < 0)
            {
                if (this.Items[start].Equals(item))
                {
                    return start;
                }

                return -1;
            }

            int mid = start + ((item - this.Items[start]) * (end - start)) / (this.Items[end] - this.Items[start]);
            if (this.Items[mid].CompareTo(item) < 0)
            {
                return this.InterpolationSearchProcedure(item, mid + 1, end);
            }
            if (this.Items[mid].CompareTo(item) > 0)
            {
                return this.InterpolationSearchProcedure(item, start, mid - 1);
            }

            return mid;
        }
    }
}