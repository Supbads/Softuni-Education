//namespace CustomLinkedList
//{
//    using System;

//    class DynamicListTest
//    {
//        public static void Main(string[] args)
//        {
//            var dynamicList = new DynamicList<int>();

//            for (int i = 0; i < 9; i++)
//            {
//                dynamicList.Add(i);
//            }

//            var firstRemoved = dynamicList.Remove(5);
//            var secondRemoved = dynamicList.Remove(3);

//            Console.WriteLine(firstRemoved);

//            Console.WriteLine(secondRemoved);

//            var indexRemoval = dynamicList.RemoveAt(3);
//            Console.WriteLine(indexRemoval);

//            for (int i = 0; i < dynamicList.Count; i++)
//            {
//                var cycleRemoval = dynamicList.RemoveAt(i);
//                Console.WriteLine(cycleRemoval);
//            }

//        }
//    }
//}
