namespace Problem_6.Linked_Stack_Tests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Problem_5.Linked_Stack;

    [TestClass]
    public class LinkedStackTests
    {
        [TestMethod]
        public void TestPushPop_ShouldCorrectlyIncrementDecrementCount()
        {
            LinkedStack<int> collection = new LinkedStack<int>();

            Assert.AreEqual(0, collection.Count);

            int elementToAdd = 5;
            collection.Push(elementToAdd);
            Assert.AreEqual(1, collection.Count);

            var element = collection.Pop();
            Assert.AreEqual(element, elementToAdd);
            Assert.AreEqual(collection.Count, 0);
        }

        [TestMethod]
        public void TestPushPop_ShouldCorrectlyResize()
        {
            LinkedStack<string> collection = new LinkedStack<string>();

            Assert.AreEqual(0, collection.Count);

            for (int i = 1; i <= 1000; i++)
            {
                collection.Push(i.ToString());
                Assert.AreEqual(collection.Count, i);
            }

            for (int i = 1000; i > 0; i--)
            {
                var element = collection.Pop();
                Assert.AreEqual(element, i.ToString());
                Assert.AreEqual(collection.Count, i - 1);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPop_PopFromEmptyStack_ShouldThrow()
        {
            LinkedStack<int> collection = new LinkedStack<int>();

            collection.Pop();
        }

        [TestMethod]
        public void TestToArray_ShouldCorrectlyReturnElementsInReversedOrder()
        {
            LinkedStack<int> collection = new LinkedStack<int>();
            int[] testNumbers = new[] { 3, 5, -2, 7 };

            for (int i = 0; i < testNumbers.Length; i++)
            {
                collection.Push(testNumbers[i]);
            }

            int[] numbersReversed = collection.ToArray();

            testNumbers = testNumbers.Reverse().ToArray();

            for (int i = 0; i < testNumbers.Length; i++)
            {
                int numberFromFirstArray = testNumbers[i];
                int numberFromSecondArray = numbersReversed[i];
                Assert.AreEqual(numberFromFirstArray, numberFromSecondArray);
            }
        }

        [TestMethod]
        public void TestToArray_EmptyStack_ShouldCreateAnEmptyArray()
        {
            LinkedStack<DateTime> dates = new LinkedStack<DateTime>();

            var datesToArray = dates.ToArray();

            Assert.AreEqual(datesToArray.Length, 0);
        }
    }
}
