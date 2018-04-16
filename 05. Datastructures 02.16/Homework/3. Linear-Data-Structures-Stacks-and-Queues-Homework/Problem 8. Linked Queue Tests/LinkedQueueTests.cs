namespace Problem_8.Linked_Queue_Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Problem_7.Linked_Queue;

    [TestClass]
    public class LinkedQueueTests
    {
        [TestMethod]
        public void TestEnqueueDequeue_EmptyCollection_ShouldCorrectlyIncrementDecrementCount()
        {
            DoublyLinkedQueue<int> collection = new DoublyLinkedQueue<int>();

            Assert.AreEqual(0, collection.Count);

            int elementToAdd = 5;
            collection.Enqueue(elementToAdd);
            Assert.AreEqual(1, collection.Count);

            var element = collection.Dequeue();
            Assert.AreEqual(element, elementToAdd);
            Assert.AreEqual(collection.Count, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestDequeue_DequeueFromEmptyQueue_ShouldThrow()
        {
            DoublyLinkedQueue<int> collection = new DoublyLinkedQueue<int>();

            collection.Dequeue();
        }

        [TestMethod]
        public void TestToArray_ShouldCorrectlyReturnElementsAsArray()
        {
            DoublyLinkedQueue<int> collection = new DoublyLinkedQueue<int>();
            int[] testNumbers = new[] { 3, 5, -2, 7 };

            for (int i = 0; i < testNumbers.Length; i++)
            {
                collection.Enqueue(testNumbers[i]);
            }

            int[] generatedArray = collection.ToArray();

            for (int i = 0; i < testNumbers.Length; i++)
            {
                int numberFromFirstArray = testNumbers[i];
                int numberFromSecondArray = generatedArray[i];
                Assert.AreEqual(numberFromFirstArray, numberFromSecondArray);
            }
        }

        [TestMethod]
        public void TestToArray_EmptyQueue_ShouldCreateAnEmptyArray()
        {
            DoublyLinkedQueue<DateTime> dates = new DoublyLinkedQueue<DateTime>();

            var datesToArray = dates.ToArray();

            Assert.AreEqual(datesToArray.Length, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPeek_EmptyQueue_ShouldThrow()
        {
            DoublyLinkedQueue<DateTime> dates = new DoublyLinkedQueue<DateTime>();

            dates.Peek();
        }

        [TestMethod]
        public void TestPeek_NonEmptyQueue_ShouldReturnElementCorrectlyAndNotDecrementCount()
        {
            DoublyLinkedQueue<int> collection = new DoublyLinkedQueue<int>();

            var element = -8;
            collection.Enqueue(element);

            for (int i = 0; i < 200; i++)
            {
                collection.Enqueue(i);
            }
            int count = collection.Count;

            var peekedElement = collection.Peek();
            Assert.AreEqual(peekedElement, element);
            Assert.AreEqual(count, collection.Count);
        }
    }
}
