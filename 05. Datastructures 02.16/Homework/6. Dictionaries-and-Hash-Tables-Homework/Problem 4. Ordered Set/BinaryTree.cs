namespace Problem_4.Ordered_Set
{
    using System;

    public class BinaryTree<T> where T : IComparable
    {
        private BinaryTreeNode<T> root;

        //public BinaryTree(BinaryTreeNode<T> root)
        //{
        //    this.root = root;
        //}

        public BinaryTreeNode<T> Root
        {
            get
            {
                return this.root;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Root node cannot be null");
                }

                this.root = value;
            }
        }
       
        public void Add(T value)
        {
            if (value == null)
            {
                throw new ArgumentException("The value to add cannot be null");
            }

            this.root = this.Insert(value, null, this.root);
        }

        public void Remove(T value)
        {
            BinaryTreeNode<T> nodeToDelete = this.Search(value);

            if (nodeToDelete == null)
            {
                throw new InvalidOperationException("Cannot remove a node that doesn't exist in the current tree");
            }
            
            this.Remove(nodeToDelete);
        }

        public BinaryTreeNode<T> Search(T value)
        {
            BinaryTreeNode<T> currentNode = this.root;

            while (currentNode != null)
            {
                if (value.CompareTo(currentNode.Value) < 0)
                {
                    currentNode = currentNode.LeftChild;
                }
                else if (value.CompareTo(currentNode.Value) > 0)
                {
                    currentNode = currentNode.RightChild;
                }
                else
                {
                    break;
                }
            }

            return currentNode;
        }

        public bool Contains(T value)
        {
            var node = Search(value);

            return node != null;
        }

        private BinaryTreeNode<T> Insert(T value, BinaryTreeNode<T> parentNode, BinaryTreeNode<T> currentNode)
        {
            if (currentNode == null)
            {
                currentNode = new BinaryTreeNode<T>(value);
                currentNode.Parent = parentNode;
            }
            else
            {
                if (value.CompareTo(currentNode.Value) < 0)
                {
                    currentNode.LeftChild = this.Insert(value, currentNode, currentNode.LeftChild);
                }
                else if (value.CompareTo(currentNode.Value) > 0)
                {
                    currentNode.RightChild = this.Insert(value, currentNode, currentNode.RightChild);
                }
                else
                {
                    currentNode.Value = value;
                }
            }

            return currentNode;
        }
        
        public void Print()
        {
            this.Print(this.root, 0);
        }
        
        private void Remove(BinaryTreeNode<T> nodeToDelete)
        {
            if (nodeToDelete.LeftChild != null && nodeToDelete.RightChild != null)
            {
                BinaryTreeNode<T> replacementNode = nodeToDelete.RightChild;
                replacementNode = this.FindMinimalElement(replacementNode);
                nodeToDelete.Value = replacementNode.Value;
                nodeToDelete.Value = replacementNode.Value;
                nodeToDelete = replacementNode;
            }

            BinaryTreeNode<T> tempNode;

            if (nodeToDelete.LeftChild != null)
            {
                tempNode = nodeToDelete.LeftChild;
            }
            else
            {
                tempNode = nodeToDelete.RightChild;
            }

            if (tempNode != null)
            {
                tempNode.Parent = nodeToDelete.Parent;

                if (nodeToDelete.Parent == null)
                {
                    this.root = tempNode;
                }
                else
                {
                    if (nodeToDelete.Parent.LeftChild == nodeToDelete)
                    {
                        nodeToDelete.Parent.LeftChild = tempNode;
                    }
                    else
                    {
                        nodeToDelete.Parent.RightChild = tempNode;
                    }
                }
            }
            else
            {
                if (nodeToDelete.Parent == null)
                {
                    this.root = null;
                }
                else
                {
                    if (nodeToDelete.Parent.LeftChild == nodeToDelete)
                    {
                        nodeToDelete.Parent.LeftChild = null;
                    }
                    else
                    {
                        nodeToDelete.Parent.RightChild = null;
                    }
                }
            }
        }

        public void Each(Action<T> action)
        {
            this.Each(action, this.root);
        }

        private void Each(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node.LeftChild != null)
            {
                this.Each(action, node.LeftChild);
            }

            action(node.Value);

            if (node.RightChild != null)
            {
                this.Each(action, node.RightChild);
            }
        }

        private BinaryTreeNode<T> FindMinimalElement(BinaryTreeNode<T> node)
        {
            while (node.LeftChild != null)
            {
                node = node.LeftChild;
            }

            return node;
        }

        private BinaryTreeNode<T> FindMaximumElement(BinaryTreeNode<T> node)
        {
            while (node.RightChild != null)
            {
                node = node.LeftChild;
            }

            return node;
        }

        private void Print(BinaryTreeNode<T> node, int depth)
        {
            if (node == null)
            {
                return;
            }

            this.Print(node.LeftChild, depth + 1);

            Console.WriteLine(new string('#', depth) + "{0} ", node.Value);

            this.Print(node.RightChild, depth + 1);
        }
    }
}