namespace Problem_2.Traverse_Directory_Contents
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class Program
    {
        static Dictionary<FileInfo, Tree<FileInfo>> nodeByValue = new Dictionary<FileInfo, Tree<FileInfo>>(); 

        static void Main(string[] args)
        {
            const string StartDirectory = "C:\\Windows";
            DirectoryInfo rootDirecotry = new DirectoryInfo(StartDirectory);
            var startingFolder = TraverseHDD(rootDirecotry);


        }

        static Folder TraverseHDD(DirectoryInfo directory)
        {
            FileInfo[] files = directory.GetFiles();
            List<File> filesCollection = new List<File>();
            foreach (FileInfo file in files)
            {
                File convertedFile = new File(file.Name, file.Length);
                filesCollection.Add(convertedFile);
            }
            
            Folder folder = new Folder(directory.FullName, filesCollection);

            List<Folder> subFolders = new List<Folder>();
            DirectoryInfo[] direcoties = directory.GetDirectories();
            foreach (DirectoryInfo childDirecotries in direcoties)
            {
                subFolders.Add(TraverseHDD(childDirecotries));
            }

            folder.ChildFolders = subFolders;

            return folder;
        }
    }
}
