namespace Problem_3.Array_Based_Stack
{
    using System;
    using System.Collections.Generic;

    public class ArrayStack<T>
    {
        private T[] elements;

        private const int DefaultCapacity = 16;

        private int count;

        private int index;

        public ArrayStack(int capacity = DefaultCapacity)
        {
            this.elements = new T[capacity];
            this.index = 0;
            this.count = 0;
        }

        public int Count
        {
            get
            {
                return this.count;
            }

            private set
            {
                this.count = value;
            }
        }

        public void Push(T element)
        {
            if (this.count == elements.Length)
            {
                this.Grow();
            }

            this.elements[this.index] = element;
            this.index++;
            this.count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cannot pop from an empty stack");
            }

            var element = this.elements[this.index - 1];
            this.elements[this.index - 1] = default(T);
            this.index--;
            this.count--;

            return element;
        }

        public T Peak()
        {
            var element = this.elements[this.index - 1];

            return element;
        }

        public T[] ToArray()
        {
            List<T> newList = new List<T>();

            for (int i = this.index - 1; i >= 0; i--)
            {
                newList.Add(this.elements[i]);
            }

            return newList.ToArray();
            //return this.elements.Reverse().ToArray();
        }

        private void Grow()
        {
            T[] enlargedArray = new T[this.elements.Length * 2];
            Array.Copy(this.elements, enlargedArray, this.elements.Length);
            this.elements = enlargedArray;
        }
    }
}