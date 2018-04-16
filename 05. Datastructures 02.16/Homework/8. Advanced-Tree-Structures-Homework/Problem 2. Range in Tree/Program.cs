namespace Problem_2.Range_in_Tree
{
    using System;
    using System.Linq;
    using Part_I___Implement_an_AVL_Tree;

    class Program
    {
        static void Main()
        {
            const string EmptyCollectionOutput = "(empty)";
            //20 30 5 8 14 18 -2 0 50 50 
            //4 34
            var tree = new AVLTree<int>();
            var input = ToIntArray(Console.ReadLine());
            var range = ToIntArray(Console.ReadLine());

            foreach (var token in input)
            {
                tree.Add(token);
            }
            

            //for the indexing part
            //for (int i = 0; i < tree.Count; i++)
            //{
            //    Console.WriteLine("tester " + tree[i]);
            //}

            var collection = tree.Range(range[0], range[1]);
            string output = collection.Count > 0 ? string.Join(", ", collection) : EmptyCollectionOutput;
            Console.WriteLine(output);

            //5 40 3 8 2 2 2 1 0 50 80 33 -70
            //8 40
            tree = new AVLTree<int>();
            input = ToIntArray(Console.ReadLine());
            range = ToIntArray(Console.ReadLine());

            foreach (var token in input)
            {
                tree.Add(token);
            }

            collection = tree.Range(range[0], range[1]);
            output = collection.Count > 0 ? string.Join(", ", collection) : EmptyCollectionOutput;
            Console.WriteLine(output);

            //0 0 -10 20 3 4 5 6 7 8 9 10 11 12 13
            //21 10000
            tree = new AVLTree<int>();
            input = ToIntArray(Console.ReadLine());
            range = ToIntArray(Console.ReadLine());

            foreach (var token in input)
            {
                tree.Add(token);
            }

            collection = tree.Range(range[0], range[1]);
            output = collection.Count > 0 ? string.Join(", ", collection) : EmptyCollectionOutput;
            Console.WriteLine(output);
        }

        public static int[] ToIntArray(string input)
        {
            return input.Split(' ')
                .Select(int.Parse)
                .Distinct()
                .ToArray();
        }

    }
}
