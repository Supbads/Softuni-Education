namespace Problem_1.Find_the_Root
{
    using System;
    using System.Collections.Generic;

    public class Tree<T>
    {
        public Tree(T value, Tree<T> parent = null, params Tree<T>[] children)
        {
            this.Value = value;
            this.Parent = parent;
            this.Children = new List<Tree<T>>();

            if (children.Length > 0)
            {
                this.SeedChildren(children);
            }
        }

        public T Value { get; set; }

        public Tree<T> Parent { get; set; }

        public IList<Tree<T>> Children { get; private set; }

        public void AddChild(Tree<T> child)
        {
            if (child == null)
            {
                throw new ArgumentException("child node cannot be null ");
            }

            this.Children.Add(child);
        }

        private void SeedChildren(Tree<T>[] children)
        {
            foreach (Tree<T> child in children)
            {
                this.Children.Add(child);
                child.Parent = this;
            }
        }
    }
}