namespace Problem_5.Linked_Stack
{
    using System;

    public class LinkedStack<T>
    {
        private Node<T> lastNode;

        public LinkedStack()
        {
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Push(T element)
        {
            var node = new Node<T>(element);

            if (this.Count == 0)
            {
                this.lastNode = node;
            }
            else
            {
                node.PreviousNode = this.lastNode;
                this.lastNode = node;
            }

            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cannot pop from empty stack");
            }

            var node = this.lastNode;
            this.lastNode = node.PreviousNode;
            this.Count--;

            return node.Value;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cannot peek in empty stack");
            }

            return this.lastNode.Value;
        }

        public T[] ToArray()
        {
            int lenght = this.Count;
            var newArray = new T[lenght];

            Node<T> currentNode = this.lastNode;
            for (int i = 0; i < lenght; i++)
            {
                newArray[i] = currentNode.Value;
                currentNode = currentNode.PreviousNode;
            }

            return newArray;
        }

        private class Node<T>
        {
            public Node(T value, Node<T> previousNode = null)
            {
                this.Value = value;
                this.PreviousNode = previousNode;
            }

            public T Value { get; set; }

            public Node<T> PreviousNode { get; set; }
        }
    }
}