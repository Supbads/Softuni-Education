using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_7.Linked_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<int>();
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);

            var arr = queue.ToArray();
            foreach (var e in arr)
            {
                Console.WriteLine(e);
            }

        }
    }
}
