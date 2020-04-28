using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomListGeneric;

namespace UnitTestCustomList
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Add_AddingOneValueToEmptyCustomList_AddedValueGoesToIndexZero()
        {
            // Arrange
            CustomList<int> testList = new CustomList<int>();
            int itemToAdd = 10;
            int expectedItem = itemToAdd;
            int actualItem;

            // Act
            testList.Add(itemToAdd);
            actualItem = testList[0];

            //Assert
            Assert.AreEqual(expectedItem, actualItem);
        }

        [TestMethod]
        public void Add_AddingOneValueToEmptyCustomList_CountOfCustomListGoesToOne()
        {
            // Arrange
            CustomList<int> testList = new CustomList<int>();
            int itemToAdd = 10;
            int expectedValue = 1;
            int actualValue;

            // Act
            testList.Add(itemToAdd);
            actualValue = testList.Count;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void Add_AddingOneValueToCustomListWithOneItem_AddedValueGoesToIndexOne()
        {
            // Arrange
            CustomList<int> testList = new CustomList<int>();
            int itemToAdd = 10;
            int expectedItem = itemToAdd;
            int actualItem;

            // Act
            testList.Add(itemToAdd);
            testList.Add(itemToAdd);
            actualItem = testList[1];

            //Assert
            Assert.AreEqual(expectedItem, actualItem);
        }

        [TestMethod]
        public void Add_AddingOneValueToCustomListWithFullCapacityOfItems_CapacityOfCustomListDoubles()
        {
            // Arrange
            CustomList<int> testList = new CustomList<int>();
            int itemToAdd = 10;
            int expectedValue = testList.Capacity * 2;
            int actualValue;

            // Act
            for (int i = testList.Capacity; i > 0; i--)     // Fill list to capacity.
            {
                testList.Add(itemToAdd);
            }
            testList.Add(itemToAdd);        // Go over capacity
            actualValue = testList.Capacity;

            //Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void Add_AddingOneValueToCustomListWithFullCapacityOfItems_CountOfCustomListIncrements()
        {
            // Arrange
            CustomList<int> testList = new CustomList<int>();
            int itemToAdd = 10;
            int expectedValue = testList.Capacity + 1;
            int actualValue;

            // Act
            for (int i = testList.Capacity; i > 0; i--)     // Fill list to capacity.
            {
                testList.Add(itemToAdd);
            }
            testList.Add(itemToAdd);        // Go over capacity
            actualValue = testList.Count;

            //Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void Remove_RemoveItemFromAnEmptyCustomList_ReturnsFalse()
        {
            // Arrange
            CustomList<int> testList = new CustomList<int>();
            int itemToRemove = 5;
            bool expectedValue = false;
            bool actualValue;

            // Act
            actualValue = testList.Remove(itemToRemove);

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void Remove_RemoveItemNotFoundInNonEmptyCustomList_ReturnsFalse()
        {
            // Arrange
            CustomList<int> testList = new CustomList<int>();
            int firstItem = 1;
            int secondItem = 2;
            int thirdItem = 3;
            int itemToRemove = 5;
            bool expectedValue = false;
            bool actualValue;

            // Act
            testList.Add(firstItem);
            testList.Add(secondItem);
            testList.Add(thirdItem);

            actualValue = testList.Remove(itemToRemove);

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void Remove_RemoveItemFoundAtIndexZeroOfCustomList_IndexOneItemBecomesIndexZeroItem()
        {
            // Arrange
            CustomList<int> testList = new CustomList<int>();
            int firstItem = 1;
            int secondItem = 2;
            int thirdItem = 3;
            int expectedValue = secondItem;
            int actualValue;

            // Act
            testList.Add(firstItem);
            testList.Add(secondItem);
            testList.Add(thirdItem);

            testList.Remove(firstItem);
            actualValue = testList[0];

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void Remove_RemoveItemFoundAtIndexZeroOfCustomList_CountOfCustomListDecrements()
        {
            // Arrange
            CustomList<int> testList = new CustomList<int>();
            int firstItem = 1;
            int secondItem = 2;
            int thirdItem = 3;
            int expectedValue = 2;
            int actualValue;

            // Act
            testList.Add(firstItem);
            testList.Add(secondItem);
            testList.Add(thirdItem);

            testList.Remove(firstItem);
            actualValue = testList.Count;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void Remove_RemoveItemFoundInCustomListOneItemOverCapacity_CapacityOfCustomListDoesNotChange()
        {
            // Arrange
            CustomList<int> testList = new CustomList<int>();
            int itemToAdd = 10;
            int expectedValue = testList.Capacity * 2;
            int actualValue;

            // Act
            for (int i = testList.Capacity; i > 0; i--)     // Fill list to capacity.
            {
                testList.Add(itemToAdd);
            }
            testList.Add(itemToAdd);        // Go over capacity
            testList.Remove(itemToAdd);     // Go back to initial capacity
            actualValue = testList.Capacity;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void Remove_RemoveItemFoundInCustomListMultipleTimes_OnlyFirstInstanceOfItemIsRemoved()
        {
            // Arrange
            CustomList<int> testList = new CustomList<int>();
            int firstItem = 1;
            int secondItem = 2;
            int thirdItem = 1;
            int fourthItem = 3;
            int expectedValue = thirdItem;
            int actualValue;

            // Act
            testList.Add(firstItem);
            testList.Add(secondItem);
            testList.Add(thirdItem);
            testList.Add(fourthItem);

            testList.Remove(thirdItem);
            actualValue = testList[1];

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void ToString_CalledOnNonEmptyIntegerCustomList_ReturnsProperStringOfIntegers()
        {
            // Arrange
            CustomList<int> testList = new CustomList<int>();
            int firstItem = 1;
            int secondItem = 2;
            int thirdItem = 3;
            string expectedValue = "123";
            string actualValue;

            // Act
            testList.Add(firstItem);
            testList.Add(secondItem);
            testList.Add(thirdItem);
            actualValue = testList.ToString();

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void ToString_CalledOnEmptyIntegerCustomList_ReturnsEmptyString()
        {
            // Arrange
            CustomList<int> testList = new CustomList<int>();
            string expectedValue = "";
            string actualValue;

            // Act
            actualValue = testList.ToString();

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void ToString_CalledOnNonEmptyStringCustomList_ReturnsProperStringOfStrings()
        {
            // Arrange
            CustomList<string> testList = new CustomList<string>();
            string firstItem = "Unit ";
            string secondItem = "Testing";
            string thirdItem = " Is ";
            string fourthItem = "Important!";
            string fifthItem = " @#!*($#";
            string expectedValue = "Unit Testing Is Important! @#!*($#";
            string actualValue;

            // Act
            testList.Add(firstItem);
            testList.Add(secondItem);
            testList.Add(thirdItem);
            testList.Add(fourthItem);
            testList.Add(fifthItem);
            actualValue = testList.ToString();

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void ToString_CalledOnNonEmptyBoolCustomList_ReturnsProperStringOfBools()
        {
            // Arrange
            CustomList<bool> testList = new CustomList<bool>();
            bool firstItem = true;
            bool secondItem = false;
            bool thirdItem = true;
            string expectedValue = "TrueFalseTrue";
            string actualValue;

            // Act
            testList.Add(firstItem);
            testList.Add(secondItem);
            testList.Add(thirdItem);
            actualValue = testList.ToString();

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void ToString_CalledOnNonEmptyCharCustomList_ReturnsProperStringOfChars()
        {
            // Arrange
            CustomList<char> testList = new CustomList<char>();
            char firstItem = 'H';
            char secondItem = 'e';
            char thirdItem = 'l';
            char fourthItem = 'l';
            char fifthItem = 'o';
            char sixthItem = ' ';
            char seventhItem = 'W';
            char eighthItem = 'o';
            char ninthItem = 'r';
            char tenthItem = 'l';
            char eleventhItem = 'd';
            string expectedValue = "Hello World";
            string actualValue;

            // Act
            testList.Add(firstItem);
            testList.Add(secondItem);
            testList.Add(thirdItem);
            testList.Add(fourthItem);
            testList.Add(fifthItem);
            testList.Add(sixthItem);
            testList.Add(seventhItem);
            testList.Add(eighthItem);
            testList.Add(ninthItem);
            testList.Add(tenthItem);
            testList.Add(eleventhItem);
            actualValue = testList.ToString();

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
