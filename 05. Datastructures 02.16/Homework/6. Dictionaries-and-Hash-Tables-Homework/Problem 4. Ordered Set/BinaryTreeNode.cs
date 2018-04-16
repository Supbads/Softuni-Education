namespace Problem_4.Ordered_Set
{
    public class BinaryTreeNode<T>
    {
        public BinaryTreeNode(T value, BinaryTreeNode<T> parent = null , BinaryTreeNode<T> leftChild = null, BinaryTreeNode<T> rightChild = null)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
            this.Parent = parent;
        }

        public BinaryTreeNode<T> Parent { get; set; }

        public BinaryTreeNode<T> LeftChild { get; set; }

        public BinaryTreeNode<T> RightChild { get; set; }
        public T Value { get; set; }
    }
}
