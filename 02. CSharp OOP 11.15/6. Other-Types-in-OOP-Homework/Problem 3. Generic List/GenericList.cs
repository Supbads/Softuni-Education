using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.Generic_List
{
    [Version(13, 37)]
    class GenericList<T>
        where T:IComparable
    {
        private const int DefaultCapacity = 16;

        private T[] array;
        private int index;
        public GenericList(int capacity = DefaultCapacity)
        {
            this.Size = capacity;
            array = new T[this.Size];
            this.index = 0;
        }

        public int Size
        {
            get
            {
                return this.array.Length;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("GenericList size can not be negative!");
                }
                array=new T[value];
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= array.Length)
                {
                    throw new IndexOutOfRangeException(String.Format(
                        "Invalid index: {0}.", index));
                }
                return array[index];
            }
            set
            {
                if (index < 0 || index >= array.Length)
                {
                    throw new IndexOutOfRangeException(String.Format(
                        "Invalid index: {0}.", index));
                }
                this.array[index] = value;
            }
        }

        public void Add(T element)
        {
            if (index > array.Length)
            {
                this.array = ResizeArray();
            }
            array[index] = element;

            index++;
        }
        public void Insert(T element, int position)
        {
            T[] newArr = new T[this.array.Length];

            Array.Copy(this.array, newArr, position);
            Array.Copy(new T[1] { element }, 0, newArr, position, 1);
            Array.Copy(this.array, position, newArr, position + 1, this.array.Length - position - 2);

            this.array = newArr;
        }

        public void RemoveAt(int removeIndex)
        {
            if (removeIndex >= array.Length) 
            {
                throw new IndexOutOfRangeException(String.Format(
                    "The list capacity of {0} was exceeded.", array.Length));
            }

            array[removeIndex] = default(T);
            //fill spots
            RefillArray();
        }

        public void Remove(T element)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (element.CompareTo(array[i]) == 0)
                {
                    array[i] = default(T);
                    break;
                }
            }
            //fill spots
            RefillArray();
        }
        public void RemoveAll(T element)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (element.CompareTo(array[i])==0)
                {
                    array[i] = default(T);
                }
            }
            //fill spots
            RefillArray();
        }

        public T Min<B>()
        {
            return this.array.Min();
        }

        public T Max<B>()
        {
            return this.array.Max();
        }

        private void RefillArray()
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].CompareTo(default(T)) == 0)
                {
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[j].CompareTo(default(T)) < 0)
                        {
                            array[i] = array[j];
                            array[j] = default(T);
                            break;
                        }
                    }
                }
            }
        }

        public long IndexOf(T element)
        {
            long idx = -1;
            for (long i = 0; i < array.Length; i++)
            {
                if (array[i].CompareTo(element) == 0)
                {
                    idx = i;
                }
            }
            return idx;
        }
        public bool Contains(T element)
        {
            return this.array.Contains(element);
        }
        private T[] ResizeArray()
        {
            T[] arr = new T[array.Length << 1];
            for (int i = 0; i < array.Length; i++)
            {
                arr[i] = array[i];
            }
            return arr;
        }

        public void Clear()
        {
            T[] clearedArr = new T[DefaultCapacity];
            array = clearedArr;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            for (int i = 0; i < array.Length-1; i++)
            {
                if (array[i] == null)
                {
                    break;
                }
                sb.AppendFormat("{0}, ", array[i]);
            }
            sb.Append(array[array.Length - 1]);
            sb.Append("]");
            return sb.ToString();
        }
    }
}
