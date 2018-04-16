using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Problem_4.Files
{
    class File
    {
        public File(string name, long size)
        {
            Size = size;
            Name = name;
        }

        public long Size { get; set; }

        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is File && obj != null)
            {
                File other = (File)obj;
                return (other.Name == this.Name);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }

    class Program
    {
        static void Main()
        {
            Dictionary<string, HashSet<File>> rootsAndFiles = new Dictionary<string, HashSet<File>>();
            
            string pattern = @"^([^\\]+).*?([^\\]+);([\d]+)$";
            Regex regex = new Regex(pattern);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                var match = regex.Match(input);

                var root = match.Groups[1].ToString();
                var fileName = match.Groups[2].ToString();
                var size = long.Parse(match.Groups[3].ToString());
                
                //same file twice ?
                if (!rootsAndFiles.ContainsKey(root))
                {
                    rootsAndFiles.Add(root, new HashSet<File>());
                }
                
                var file = new File(fileName, size);

                rootsAndFiles[root].Remove(file);
                rootsAndFiles[root].Add(file);
            }

            string dsa = Console.ReadLine();

            var tokens = dsa.Split();
            var searchExt = "." + tokens[0];
            var searchRoot = tokens[2];
            
            bool flag = false;
            foreach (var file in rootsAndFiles
                .Where(x => x.Key == searchRoot)
                .SelectMany(x => x.Value.Where(y => y.Name.EndsWith(searchExt)))
                .OrderByDescending(y => y.Size)
                .ThenBy(y => y.Name))
            {
                flag = true;
                Console.WriteLine("{0} - {1} KB",file.Name, file.Size);

            }

            if (!flag)
            {
                Console.WriteLine("No");
            }

            //You need to print all file names with a given extension that are present in a given root directory sorted by their file size in descending order.
            //If two files have same size, order them by alphabetical order. 


        }
    }
}