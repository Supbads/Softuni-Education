namespace Problem_7.Linked_Queue
{
    using System;

    public class DoublyLinkedQueue<T>
    {
        private QueueNode<T> tailNode;

        private QueueNode<T> headNode;

        public DoublyLinkedQueue()
        {

        }

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            var node = new QueueNode<T>(element);

            if (this.Count == 0)
            {
                this.headNode = node;
                this.tailNode = node;
            }
            else if (this.Count == 1)
            {
                this.headNode.NextNode = node;
                this.tailNode = node;
            }
            else
            {
                this.tailNode.NextNode = node;
                this.tailNode = node;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cannot Dequeue from empty queue");
            }

            var node = this.headNode;
            this.headNode = node.NextNode;
            this.Count--;

            return node.Value;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cannot peek in empty queue");
            }
            return this.headNode.Value;
        }

        public T[] ToArray()
        {
            int length = this.Count;
            var newArray = new T[length];

            var node = this.headNode;

            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = node.Value;
                node = node.NextNode;
            }
            
            return newArray;
        }
        
        private class QueueNode<T>
        {
            public QueueNode(T value, QueueNode<T> nextNode = null, QueueNode<T> previousNode = null)
            {
                this.Value = value;
                this.NextNode = nextNode;
                this.PrevNode = previousNode;
            }

            public T Value { get; private set; }
            public QueueNode<T> NextNode { get; set; }
            public QueueNode<T> PrevNode { get; set; }
        }
    }
}
