namespace Problem_2.Traverse_Directory_Contents
{
    using System.Collections.Generic;

    public class Tree<T>
    {
        public Tree(T value, Tree<T> parent = null, params Tree<T>[] children)
        {
            this.Value = value;
            this.Parent = parent;
            this.Children  = new List<Tree<T>>();
            this.SeedChildren(children);
        }
      
        public T Value { get; set; }

        public Tree<T> Parent { get; set; }

        public IList<Tree<T>> Children { get; private set; }

        public void AddChild(Tree<T> child)
        {
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
