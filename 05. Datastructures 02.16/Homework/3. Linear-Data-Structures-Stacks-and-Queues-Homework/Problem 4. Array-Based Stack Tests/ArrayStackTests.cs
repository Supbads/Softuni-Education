namespace Problem_4.Array_Based_Stack_Tests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Problem_3.Array_Based_Stack;

    [TestClass]
    public class ArrayStackTests
    {

        [TestMethod]
        public void TestPushPop_ShouldCorrectlyIncrementDecrementCount()
        {
            ArrayStack<int> collection = new ArrayStack<int>();

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
            ArrayStack<string> collection = new ArrayStack<string>();

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
            ArrayStack<int> collection = new ArrayStack<int>();

            collection.Pop();
        }

        [TestMethod]
        public void TestToArray_ShouldCorrectlyReturnElementsInReversedOrder()
        {
            ArrayStack<int> collection = new ArrayStack<int>();
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
            ArrayStack<DateTime> dates = new ArrayStack<DateTime>();

            var datesToArray = dates.ToArray();

            Assert.AreEqual(datesToArray.Length, 0);
        }

        /*
             * 
             •	Push / pop element: create a stack of numbers; assert Count == 0; push element; assert Count == 1; pop element; assert the element is the same like the pushed element; assert Count == 0.
             •	Push / pop 1000 elements: create a stack of strings; assert Count == 0; repeat 1000 times: { push element; assert the Count is correct; }; repeat 1000 times: { pop an element; assert the element is correct; assert the Count is correct }. Pushing 1000 elements will indirectly test the auto-grow functionality several times.
             •	Pop from empty stack: create a stack; pop an element; expect an exception;
             •	Push / pop with initial capacity 1: create a stack of numbers with initial capacity of 1; assert Count == 0; push element; assert Count == 1; push another element; assert Count == 2; pop element; assert the element is correct; assert Count == 1; pop element; assert the element is correct; assert Count == 0.
             •	ToArray(): create a stack of numbers; push a few numbers, e.g. { 3, 5, -2, 7 }; convert the stack to array; assert the results holds the pushed numbers in reversed order, e.g. { 7, -2, 5, 3 }.
             •	Empty stack ToArray(): create a stack of dates; convert the stack to array; expect empty array.
             * 
             */
    }
}
