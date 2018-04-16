namespace Sortable_Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Sortable_Collection.Contracts;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private List<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public SortableCollection(params T[] items)
            : this(items.AsEnumerable())
        {
        }

        public List<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public int Count
        {
            get
            {
                return this.items.Count;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.Items);
        }

        public int BinarySearch(T item)
        {
            var index = this.BinarySearchProcedure(item, 0, this.items.Count - 1);

            return index;
        }

        public int InterpolationSearch(T item)
        {
            if (typeof(T) != typeof(int) && typeof(T) != typeof(long) && typeof(T)!= typeof(decimal))
            {
                throw new NotSupportedException("Current type doesn't support the - operator");
            }

            // collection should be sorted
            // in order for the interploation to work the elements should support
            // the "-" operator
            int low = 0;
            int high = this.items.Count - 1;
            while (this.items[low].CompareTo(item) <= 0 && this.items[high].CompareTo(item) >= 0)
            {
                int mid = low + Convert.ToInt32((Convert.ToDecimal(item) - Convert.ToDecimal(this.items[low])) * (high - low)
                    / (Convert.ToDecimal(this.items[high]) - Convert.ToDecimal(this.items[low])));

                if (this.items[mid].CompareTo(item) < 0)
                {
                    low = mid + 1;
                }
                else if (this.items[mid].CompareTo(item) > 0)
                {
                    high = mid - 1;
                }
                else
                {
                    return mid;
                }
            }

            if (this.items[low].CompareTo(item) == 0)
            {
                return low;
            }
            
            return -1;
        }

        public void Shuffle()
        {
            Random random = new Random();
            var length = this.items.Count;
            for (int i = 0; i < length; i++)
            {
                int randomedIndex = i + random.Next(0, length - i);
                var tmp = this.items[i];
                this.items[i] = this.items[randomedIndex];
                this.items[randomedIndex] = tmp;
            }
        }

        public T[] ToArray()
        {
            return this.Items.ToArray();
        }

        public override string ToString()
        {
            return "[" + string.Join(", ", this.items) + "]";
        }

        private int BinarySearchProcedure(T item, int startIndex, int endIndex)
        {
            if (endIndex < startIndex)
            {
                return -1;
            }

            int midPoint = startIndex + (endIndex - startIndex) / 2;
            
            if (this.Items[midPoint].CompareTo(item) > 0)
            {
                return this.BinarySearchProcedure(item, startIndex, midPoint - 1);
            }

            if (this.Items[midPoint].CompareTo(item) < 0)
            {
                return this.BinarySearchProcedure(item, midPoint + 1, endIndex);
            }
           
            return midPoint;
        }
    }
}