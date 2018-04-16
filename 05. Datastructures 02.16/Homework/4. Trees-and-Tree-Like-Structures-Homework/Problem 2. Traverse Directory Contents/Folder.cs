namespace Problem_2.Traverse_Directory_Contents
{
    using System.Collections.Generic;

    public class Folder
    {
        public Folder(string name, List<File> files, List<Folder> childFolders = null)
        {
            this.Name = name;
            this.Files = files;
            this.ChildFolders = childFolders;
        }

        public string Name { get; set; }

        public List<File> Files { get; set; }

        public List<Folder> ChildFolders { get; set; } 
    }
}