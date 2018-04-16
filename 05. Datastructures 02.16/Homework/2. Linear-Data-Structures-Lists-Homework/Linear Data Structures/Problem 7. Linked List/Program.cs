namespace Problem_7.Reverse_List
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            ReverseList<int> reverseList = new ReverseList<int>();

            for (int i = 0; i < 15; i++)
            {
                reverseList.Add(i);
            }

            Console.WriteLine(string.Join(" ", reverseList));

            foreach (var i in reverseList)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            reverseList.Remove(4);
            reverseList.Remove(7);

            Console.WriteLine(string.Join(" ", reverseList));
        }
    }
}
