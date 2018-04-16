namespace Problem_4.Ordered_Set
{

    class Program
    {
        static void Main(string[] args)
        {
            var set = new OrderedSet<int>();
            set.Add(17);
            set.Add(9);
            set.Add(12);
            set.Add(19);
            set.Add(6);
            set.Add(25);
            set.Add(18);

            set.Print();


            //set.Add(25);
        }
    }
}
