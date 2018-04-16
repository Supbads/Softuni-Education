namespace Part_I___Implement_an_AVL_Tree
{
    using System;

    public class AVLNode<T>
    {
        private AVLNode<T> rightChild;

        private AVLNode<T> leftChild;

        private bool isLeft;

        private bool isRight;

        public AVLNode(T value, int balanceFactor = 0, AVLNode<T> parent = null, AVLNode<T> leftChild = null, AVLNode<T> rightChild = null)
        {
            this.Value = value;
            this.BalanceFactor = balanceFactor;
            this.Parent = parent;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public T Value { get; set; }

        public int BalanceFactor { get; set; }

        public AVLNode<T> Parent { get; set; }

        public AVLNode<T> LeftChild
        {
            get
            {
                return this.leftChild;
            }

            set
            {
                if (value != null)
                {
                    value.Parent = this;
                }

                this.leftChild = value;
            }
        }

        public AVLNode<T> RightChild
        {
            get
            {
                return this.rightChild;
            }

            set
            {
                if (value != null)
                {
                    value.Parent = this;
                }

                this.rightChild = value;
            }
        }

        public bool IsLeftChild 
        {
            get
            {
                if (this.Parent == null)
                {
                    return false;
                }

                return this.isLeft;
            }

            set
            {
                this.isLeft = value;
                this.isRight = !value;
            }
        }

        public bool IsRightChild
        {
            get
            {
                if (this.Parent == null)
                {
                    return false;
                }

                return this.isRight;
            }
            set
            {
                this.isRight = value;
                this.isLeft = !value;
            }
        }

        public int ChildrenCount { get; set; }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}