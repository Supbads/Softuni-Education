namespace CustomLinkedList.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DynamicListTests
    {
        [TestMethod]
        public void TestAdd_AddingToEmptyList_ShouldAddValueToHead()
        {
            // Arrange
            DynamicList<string> list = new DynamicList<string>();
            
            // Act -> shouldn't throw
            list.Add("Pesho");
        }

        [TestMethod]
        public void TestAdd_AddingToNonEmptyList_ShouldChainPointers()
        {
            // Arrange
            DynamicList<string> list = new DynamicList<string>();

            // Act -> shouldn't throw, should chain
            list.Add("Dimitri");
            list.Add("Stamat");
        }

        [TestMethod]
        public void TestIndexation_IndexingValidElement_ShouldReturnItsValue()
        {
            // Arrange
            DynamicList<string> list = new DynamicList<string>();

            for (int i = 0; i < 5; i++)
            {
                list.Add(i.ToString());
            }
            
            // Act
            var element = list[4];
            
            // Assert
            Assert.AreEqual(element, "4", "Indexing a valid element doesn't return the proper value");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIndexation_IndexingInvalidElement_ShouldThrow()
        {
            // Arrange
            DynamicList<string> list = new DynamicList<string>();

            for (int i = 0; i < 5; i++)
            {
                list.Add(i.ToString());
            }

            // Act -> should throw
            var element = list[9];
        }

        [TestMethod]
        public void TestRemove_RemoveExistingElement_ShouldReturnTheIndexOfElement()
        {
            // Arrange
            DynamicList<string> list = new DynamicList<string>();

            for (int i = 0; i < 5; i++)
            {
                list.Add(i.ToString());
            }
            
            // Act
            int removingElementIndex = 4;
            var element = list.Remove(removingElementIndex.ToString());

            // Assert
            Assert.AreEqual(element, removingElementIndex, "removing an element doesn't return the proper element");
        }
        
        [TestMethod]
        public void TestRemove_RemoveExistingElement_ShouldRemoveTheElementFromTheCollection()
        {
            // Arrange
            DynamicList<string> list = new DynamicList<string>();

            for (int i = 0; i < 5; i++)
            {
                list.Add(i.ToString());
            }

            // Act
            string removingElement = "4";
            list.Remove(removingElement);
            
            // Assert
            var cointainsRemovedElement = list.Contains(removingElement);
            Assert.IsFalse(cointainsRemovedElement, "list still contains element after removal");
        }

        [TestMethod]
        public void TestRemove_RemoveNotStoredElement_ShouldReturnNegativeOne()
        {
            // Arrange
            DynamicList<string> list = new DynamicList<string>();

            for (int i = 0; i < 5; i++)
            {
                list.Add(i.ToString());
            }

            // Act
            string removingElement = "10";
            int indexOfRemovedElement = list.Remove(removingElement);

            // Assert
            Assert.AreEqual(indexOfRemovedElement, -1, "list still contains element after removal");
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void TestRemove_RemoveAtInvalidIndex_ShouldThrow()
        {
            // Arrange
            DynamicList<string> list = new DynamicList<string>();

            for (int i = 0; i < 5; i++)
            {
                list.Add(i.ToString());
            }

            // Act -> throws
            int removingIndex = 15;
            list.RemoveAt(removingIndex);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void TestRemove_RemoveAtZeroIndexOnEmptyList_ShouldThrow()
        {
            // Arrange
            DynamicList<string> list = new DynamicList<string>();
            
            // Act
            int removingIndex = 0;
            list.RemoveAt(removingIndex);
        }
		
        [TestMethod]
        public void TestRemove_RemoveMiddleElement_ShouldRearrangeOtherElements()
        {
            // Arrange
            DynamicList<string> list = new DynamicList<string>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(i.ToString());
            }

            // Act
            int removingElementIndex = 5;
            list.RemoveAt(5);

            // Assert
            for (int i = 0; i < list.Count; i++)
            {
                if (i != removingElementIndex)
                {
                    var containsTheOtherElements = list.Contains(i.ToString());
                    Assert.IsTrue(containsTheOtherElements, "Removing screws up the chaining of the elements");
                }
            }
        }

        //contains an existing element should return true -> is covered at: DynamicList_RemoveElement_ShouldDeletePointer()
        //contains a non-existing element should return false -> is covered at: DynamicList_RemoveElement_ShouldRemoveTheElementFromTheCollection()
    }
}
