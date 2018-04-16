namespace Problem_4.Tower_of_Hanoi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TowerOfHanoi
    {
        static int steps;

        private static Stack<int> source;

        private static Stack<int> destination;

        private static Stack<int> spare;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of disks: ");
            int disks = int.Parse(Console.ReadLine());

            source = new Stack<int>(Enumerable.Range(1, disks).Reverse());
            destination = new Stack<int>();
            spare = new Stack<int>();

            PrintPegs();

            MoveDisks(disks, source, destination, spare);
        }

        private static void Print(Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            Console.WriteLine();
            Console.Write("Source:  ");
            Console.Write(String.Join(" ", source.Reverse()));
            Console.WriteLine();
            Console.Write("Destination: ");
            Console.Write(String.Join(" ", destination.Reverse()));
            Console.WriteLine();
            Console.Write("Spare: ");
            Console.Write(String.Join(" ", spare.Reverse()));
            Console.WriteLine();
        }

        static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            steps++;
            if (bottomDisk == 1)
            {
                destination.Push(source.Pop());
                PrintPegs();
                //Console.WriteLine("Steps #{0}: Moved disk {1}", steps, bottomDisk);
            }
            else
            {
                //TODO: Move all disks from bottomDisk-1 from source to spare  source->spare
                //2) move the bottomDisk from source to destination             source -> destination
                //3) move all disks from bottomDisk – 1 from spare to destination  spare -> desination
                MoveDisks(bottomDisk - 1, source, spare, destination);
                destination.Push(source.Pop());
                PrintPegs();
                MoveDisks(bottomDisk - 1, spare, destination, source);
            }
        }

        static void PrintPegs()
        {
            Print(TowerOfHanoi.source, TowerOfHanoi.destination, TowerOfHanoi.spare);
        }
    }

}
