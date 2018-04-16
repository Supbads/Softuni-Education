namespace Problem_4.Ordered_Set
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class OrderedSet<T> : IEnumerable<T>
        where T : IComparable
    {
        private BinaryTree<T> elements;

        public OrderedSet()
        {
            this.elements = new BinaryTree<T>();
        }

        public int Count { get; set; }

        public void Add(T value)
        {
            if (this.elements.Contains(value))
            {
                throw new ArgumentException("element already exists in the ordered set");
            }

            this.elements.Add(value);
        }

        public bool contains(T value)
        {
            return this.elements.Contains(value);
        }

        public void Remove(T value)
        {
            this.elements.Remove(value);
        }

        public void Clear()
        {
            this.elements = new BinaryTree<T>();
            this.Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var values = new Stack<BinaryTreeNode<T>>();
            var node = this.elements.Root;
            while (values.Count > 0 || node != null)
            {
                if (node != null)
                {
                    values.Push(node);
                    node = node.LeftChild;
                }
                else
                {
                    node = values.Pop();
                    yield return node.Value; //where the magic happens
                    node = node.RightChild;
                }
            }
        }

        public void Print()
        {
            this.elements.Print();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}