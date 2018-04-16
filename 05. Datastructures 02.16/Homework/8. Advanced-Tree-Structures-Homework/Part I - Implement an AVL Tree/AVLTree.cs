namespace Part_I___Implement_an_AVL_Tree
{
    using System;
    using System.Collections.Generic;

    public class AVLTree<T> //: Ienumerable<T>
        where T : IComparable
    {
        private AVLNode<T> rootNode;

        private T indexHelper;

        public AVLTree(AVLNode<T> rootNode = null)
        {
            this.rootNode = rootNode;
        }

        public T this[int index]
        {
            get
            {
                if (index >= this.Count || index < 0)
                {
                    throw new ArgumentException("index cannot be bigger than the tree count, or negative");
                }

                this.indexHelper = default(T);
                int startIndex = 0;
                this.IndexationHelper(this.rootNode, ref startIndex, index);

                return this.indexHelper;

                //if (this.indexHelper.Equals(default(T)))
                //{
                //    return 
                //}
            }
        }

        public AVLNode<T> RootNode
        {
            get
            {
                return this.rootNode;
            }
            set
            {
                this.rootNode = value;
            }
        }

        public int Count { get; set; }

        public void Add(T item)
        {
            var inserted = true;

            if (this.rootNode == null)
            {
                this.rootNode = new AVLNode<T>(item);
                this.rootNode.Parent = null;
            }
            else
            {
                inserted = this.InsertInternal(this.rootNode, item);
            }

            if (inserted == true)
            {
                this.Count++;
            }
        }

        public bool Contains(T item)
        {
            var node = this.rootNode;

            while (node != null)
            {
                if (node.Value.CompareTo(item) > 0)
                {
                    node = node.LeftChild;
                }
                else if (node.Value.CompareTo(item) < 0)
                {
                    node = node.RightChild;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public void ForeachDfs(Action<int, T> action)
        {
            if (this.Count == 0)
            {
                return;
            }

            this.InOrderDFS(this.rootNode, 1, action);
        }

        public ICollection<T> Range(T startValue, T endValue)
        {
            var elementsInRange = new List<T>();
            var node = this.rootNode;
            this.InRangeDFS(node, elementsInRange, startValue, endValue);

            return elementsInRange;
        }

        private void InRangeDFS(AVLNode<T> currentNode,List<T> items, T startRange, T endRange)
        {
            var greaterThanStart = currentNode.Value.CompareTo(startRange) > 0;
            var smallerThanEnd = currentNode.Value.CompareTo(endRange) < 0;

            if (currentNode.LeftChild != null && greaterThanStart)
            {
                this.InRangeDFS(currentNode.LeftChild, items, startRange, endRange);
            }

            if (greaterThanStart && smallerThanEnd)
            {
                items.Add(currentNode.Value);
            }

            if (currentNode.RightChild != null && smallerThanEnd)
            {
                this.InRangeDFS(currentNode.RightChild, items, startRange, endRange);
            }
        }

        private void InOrderDFS(AVLNode<T> currentNode, int depth, Action<int, T> action)
        {
            if (currentNode.LeftChild != null)
            {
                this.InOrderDFS(currentNode.LeftChild, depth + 1, action);
            }

            action(depth, currentNode.Value);

            if (currentNode.RightChild != null)
            {
                this.InOrderDFS(currentNode.RightChild, depth + 1, action);
            }
        }

        private bool InsertInternal(AVLNode<T> node, T item)
        {
            var currentNode = node;
            var newNode = new AVLNode<T>(item);
            var shouldRetrace = false;

            while (true)
            {
                if (currentNode.Value.CompareTo(item) == 0)
                {
                    return false;
                }

                if (currentNode.Value.CompareTo(item) < 0)
                {
                    if (currentNode.RightChild == null)
                    {
                        currentNode.RightChild = newNode;
                        newNode.IsRightChild = true;
                        newNode.IsLeftChild = false;
                        currentNode.BalanceFactor--;
                        shouldRetrace = currentNode.BalanceFactor != 0;
                        break;
                    }

                    currentNode = currentNode.RightChild;
                }
                else
                {
                    if (currentNode.LeftChild == null)
                    {
                        currentNode.LeftChild = newNode;
                        newNode.IsLeftChild = true;
                        newNode.IsRightChild = false;
                        currentNode.BalanceFactor++;
                        shouldRetrace = currentNode.BalanceFactor != 0;
                        break;
                    }

                    currentNode = currentNode.LeftChild;
                }
            }

            if (shouldRetrace)
            {
                this.RetraceInsert(currentNode);
            }

            return true;
        }

        private void RetraceInsert(AVLNode<T> node)
        {
            var parent = node.Parent;
            while (parent != null)
            {
                if (node.IsLeftChild)
                {
                    // parent's left subtree has grown
                    if (parent.BalanceFactor == 1)
                    {
                        parent.BalanceFactor++;

                        if (node.BalanceFactor == -1)
                        {
                            //making the branch straight 
                            this.RotateLeft(node);
                        }
                        //rotating the branch
                        this.RotateRight(parent);
                        break;
                    }

                    if (parent.BalanceFactor == -1)
                    {
                        parent.BalanceFactor++;
                        break;
                    }

                    parent.BalanceFactor = 1;
                }
                else
                {
                    // parent's right subtree has grown
                    if (parent.BalanceFactor == -1)
                    {
                        parent.BalanceFactor--;
                        if (node.BalanceFactor == 1)
                        {
                            // making the brnach straight
                            this.RotateRight(node);
                        }

                        this.RotateLeft(parent);
                        break;
                    }

                    if (parent.BalanceFactor == 1)
                    {
                        parent.BalanceFactor = 0;
                        break;
                    }

                    parent.BalanceFactor = -1;
                }

                node = parent;
                parent = node.Parent;
            }
        }

        private void RotateRight(AVLNode<T> node)
        {
            var parent = node.Parent;
            var child = node.LeftChild;

            if (parent != null)
            {
                if (node.IsLeftChild)
                {
                    parent.LeftChild = child;
                    child.IsLeftChild = true;
                }
                else
                {
                    parent.RightChild = child;
                    child.IsRightChild = true;
                }
            }
            else
            {
                this.rootNode = child;
                this.rootNode.Parent = null;
            }

            node.LeftChild = child.RightChild;
            if (node.LeftChild != null)
            {
                node.LeftChild.IsLeftChild = true;
            }

            child.RightChild = node;
            node.IsRightChild = true;

            node.BalanceFactor -= 1 + Math.Max(child.BalanceFactor, 0);
            child.BalanceFactor -= 1 - Math.Min(node.BalanceFactor, 0);
        }

        private void IndexationHelper(AVLNode<T> currentNode, ref int index, int targetIndex)
        {
            if (currentNode.LeftChild != null)
            {
                this.IndexationHelper(currentNode.LeftChild, ref index, targetIndex);
            }

            if (index == targetIndex)
            {
                this.indexHelper = currentNode.Value;
            }

            index++;

            if (currentNode.RightChild != null)
            {
                this.IndexationHelper(currentNode.RightChild, ref index, targetIndex);
            }
        }

        private void RotateLeft(AVLNode<T> node)
        {
            var parent = node.Parent;
            var child = node.RightChild;

            if (parent != null)
            {
                if (node.IsLeftChild)
                {
                    parent.LeftChild = child;
                    child.IsLeftChild = true;
                }
                else // node is right child
                {
                    parent.RightChild = child;
                    child.IsRightChild = true;
                }
            }
            else
            {
                this.rootNode = child;
                this.rootNode.Parent = null;
            }

            node.RightChild = child.LeftChild;
            if (node.RightChild != null)
            {
                node.RightChild.IsRightChild = true;
            }

            child.LeftChild = node;
            node.IsLeftChild = true;

            node.BalanceFactor += 1 - Math.Min(child.BalanceFactor, 0);
            child.BalanceFactor += 1 + Math.Min(child.BalanceFactor, 0);
        }
    }
}