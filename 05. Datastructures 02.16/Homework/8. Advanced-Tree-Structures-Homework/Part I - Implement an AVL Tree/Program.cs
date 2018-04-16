namespace Part_I___Implement_an_AVL_Tree
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            //no idea why
            //Foreach_AddedManyRandomElements_ShouldReturnSortedAscending()
            //^this test doesn't work out ;=;
            //nvm fixed it, isLeft/isRight weren't changing in the rotation as they should be (also,
            //could throw a null reference exception so a sentinel node comes in handy but i'm lazy)
            // which wasn't added in the excercise as info but it's crucial.


            var tree = new AVLTree<int>();

            for (int i = 0; i < 50; i++)
            {
                tree.Add(i);
            }

            var element = tree[37];

            Console.WriteLine(element);
        }
    }
}
