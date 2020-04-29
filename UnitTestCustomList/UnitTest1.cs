using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomListGeneric;

namespace UnitTestCustomList
{
    [TestClass]
    public class UnitTest1
    {
        //*****************Add()*******************************************************************************************
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

        //*****************Remove()*******************************************************************************************
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
            testList.Add(firstItem);        // {1,2,3}
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
            testList.Add(firstItem);    // {1,2,3}
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
            testList.Add(firstItem);    // {1,2,3}
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
            testList.Add(firstItem);    // {1,2,1,3}
            testList.Add(secondItem);
            testList.Add(thirdItem);
            testList.Add(fourthItem);

            testList.Remove(thirdItem);
            actualValue = testList[1];

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        //*****************ToString()*******************************************************************************************
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
            testList.Add(firstItem);    // {1,2,3}
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

        //*****************Plus Operator*******************************************************************************************
        [TestMethod]
        public void PlusOperator_CalledOnTwoNonEmptyIntegerCustomList_ReturnsProperCombinedIntegerCustomList()
        {
            // Arrange
            CustomList<int> testList1 = new CustomList<int>();
            CustomList<int> testList2 = new CustomList<int>();

            int firstItem1 = 1;
            int secondItem1 = 2;
            int thirdItem1 = 3;
            int firstItem2 = 4;
            int secondItem2 = 5;
            int thirdItem2 = 6;

            string expectedValue = "123456";
            string actualValue;

            // Act
            testList1.Add(firstItem1);      // {1,2,3}
            testList1.Add(secondItem1);
            testList1.Add(thirdItem1);
            testList2.Add(firstItem2);      // {4,5,6}
            testList2.Add(secondItem2);
            testList2.Add(thirdItem2);

            actualValue = (testList1 + testList2).ToString();

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void PlusOperator_CalledOnTwoNonEmptyIntegerCustomList_OriginalIntegerCustomListsUnchanged()
        {
            // Arrange
            CustomList<int> testList1 = new CustomList<int>();
            CustomList<int> testList2 = new CustomList<int>();
            CustomList<int> sumList = new CustomList<int>();

            int firstItem1 = 1;
            int secondItem1 = 2;
            int thirdItem1 = 3;
            int firstItem2 = 4;
            int secondItem2 = 5;
            int thirdItem2 = 6;

            string expectedValue = "123";
            string actualValue;

            // Act
            testList1.Add(firstItem1);      // {1,2,3}
            testList1.Add(secondItem1);
            testList1.Add(thirdItem1);
            testList2.Add(firstItem2);      // {4,5,6}
            testList2.Add(secondItem2);
            testList2.Add(thirdItem2);

            sumList = testList1 + testList2;
            actualValue = testList1.ToString();

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void PlusOperator_CalledOnOneEmptyOneNonEmptyIntegerCustomList_SumEqualsTheNonEmptyCustomLists()
        {
            // Arrange
            CustomList<int> testList1 = new CustomList<int>();
            CustomList<int> testList2 = new CustomList<int>();

            int firstItem = 1;
            int secondItem = 2;
            int thirdItem = 3;

            string expectedValue = "123";
            string actualValue;

            // Act
            testList1.Add(firstItem);   // {1,2,3}
            testList1.Add(secondItem);
            testList1.Add(thirdItem);

            actualValue = (testList1 + testList2).ToString();

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void PlusOperator_CalledOnTwoNonEmptyIntegerCustomList_CountIsSumOfCounts()
        {
            // Arrange
            CustomList<int> testList1 = new CustomList<int>();
            CustomList<int> testList2 = new CustomList<int>();

            int firstItem = 1;
            int secondItem = 2;
            int thirdItem = 3;
            int expectedValue = 6;
            int actualValue;

            // Act
            testList1.Add(firstItem);       // {1,2,3}
            testList1.Add(secondItem);
            testList1.Add(thirdItem);
            testList2.Add(firstItem);       // {1,2,3}
            testList2.Add(secondItem);
            testList2.Add(thirdItem);

            actualValue = (testList1 + testList2).Count;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void PlusOperator_CalledOnTwoNonEmptyIntegerCustomList_CapacityIsDouble()
        {
            // Arrange
            CustomList<int> testList1 = new CustomList<int>();
            CustomList<int> testList2 = new CustomList<int>();

            int firstItem = 1;
            int secondItem = 2;
            int thirdItem = 3;
            int expectedValue = testList1.Capacity * 2;
            int actualValue;

            // Act
            testList1.Add(firstItem);       // {1,2,3}
            testList1.Add(secondItem);
            testList1.Add(thirdItem);
            testList2.Add(firstItem);       // {1,2,3}
            testList2.Add(secondItem);
            testList2.Add(thirdItem);

            actualValue = (testList1 + testList2).Capacity;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void PlusOperator_CalledOnThreeNonEmptyIntegerCustomList_ReturnsProperCombinedIntegerCustomList()
        {
            // Arrange
            CustomList<int> testList1 = new CustomList<int>();
            CustomList<int> testList2 = new CustomList<int>();

            int firstItem1 = 1;
            int secondItem1 = 2;
            int thirdItem1 = 3;
            int firstItem2 = 4;
            int secondItem2 = 5;
            int thirdItem2 = 6;

            string expectedValue = "123456123";
            string actualValue;

            // Act
            testList1.Add(firstItem1);      // {1,2,3}
            testList1.Add(secondItem1);
            testList1.Add(thirdItem1);
            testList2.Add(firstItem2);      // {4,5,6}
            testList2.Add(secondItem2);
            testList2.Add(thirdItem2);

            actualValue = (testList1 + testList2 + testList1).ToString();

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        //*****************Minus Operator*******************************************************************************************
        [TestMethod]
        public void MinusOperator_CalledOnTwoNonEmptyIntegerCustomListWithCommonValues_ReturnsProperDiffResultIntegerCustomList()
        {
            // Arrange
            CustomList<int> testList1 = new CustomList<int>();
            CustomList<int> testList2 = new CustomList<int>();

            int firstItem1 = 1;
            int secondItem1 = 2;
            int thirdItem1 = 3;
            int firstItem2 = 4;
            int secondItem2 = 3;
            int thirdItem2 = 1;

            string expectedValue = "2";
            string actualValue;

            // Act
            testList1.Add(firstItem1);      // {1,2,3}
            testList1.Add(secondItem1);
            testList1.Add(thirdItem1);
            testList2.Add(firstItem2);      // {4,3,1}
            testList2.Add(secondItem2);
            testList2.Add(thirdItem2);

            actualValue = (testList1 - testList2).ToString();

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void MinusOperator_CalledOnTwoNonEmptyIntegerCustomListWithRepeatedCommonValues_ItemsOnlyRemovedOnceFromCustomList()
        {
            // Arrange
            CustomList<int> testList1 = new CustomList<int>();
            CustomList<int> testList2 = new CustomList<int>();

            int firstItem1 = 1;
            int secondItem1 = 2;
            int thirdItem1 = 3;
            int firstItem2 = 4;
            int secondItem2 = 3;
            int thirdItem2 = 1;

            string expectedValue = "2123";
            string actualValue;

            // Act
            testList1.Add(firstItem1);      // {1,2,3,1,2,3}
            testList1.Add(secondItem1);
            testList1.Add(thirdItem1);
            testList1.Add(firstItem1);
            testList1.Add(secondItem1);
            testList1.Add(thirdItem1);
            testList2.Add(firstItem2);      // {4,3,1}
            testList2.Add(secondItem2);
            testList2.Add(thirdItem2);

            actualValue = (testList1 - testList2).ToString();

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void MinusOperator_CalledOnTwoNonEmptyIntegerCustomListWithNoCommonValues_ReturnsUnchangedCopyOfIntegerCustomList()
        {
            // Arrange
            CustomList<int> testList1 = new CustomList<int>();
            CustomList<int> testList2 = new CustomList<int>();

            int firstItem1 = 1;
            int secondItem1 = 2;
            int thirdItem1 = 3;
            int firstItem2 = 4;
            int secondItem2 = 5;
            int thirdItem2 = 6;

            string expectedValue = "123";
            string actualValue;

            // Act
            testList1.Add(firstItem1);      // {1,2,3}
            testList1.Add(secondItem1);
            testList1.Add(thirdItem1);
            testList2.Add(firstItem2);      // {4,5,6}
            testList2.Add(secondItem2);
            testList2.Add(thirdItem2);

            actualValue = (testList1 - testList2).ToString();

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void MinusOperator_CalledOnTwoNonEmptyIntegerCustomListWithCommonValues_OriginalIntegerCustomListsUnchanged()
        {
            // Arrange
            CustomList<int> testList1 = new CustomList<int>();
            CustomList<int> testList2 = new CustomList<int>();
            CustomList<int> diffList = new CustomList<int>();

            int firstItem1 = 1;
            int secondItem1 = 2;
            int thirdItem1 = 3;
            int firstItem2 = 1;
            int secondItem2 = 3;
            int thirdItem2 = 6;

            string expectedValue = "123";
            string actualValue;

            // Act
            testList1.Add(firstItem1);      // {1,2,3}
            testList1.Add(secondItem1);
            testList1.Add(thirdItem1);
            testList2.Add(firstItem2);      // {1,3,6}
            testList2.Add(secondItem2);
            testList2.Add(thirdItem2);

            diffList = testList1 - testList2;
            actualValue = testList1.ToString();

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void MinusOperator_SubtractEmptyCustomerListFromNonEmptyCustomerList_DiffEqualsTheNonEmptyCustomList()
        {
            // Arrange
            CustomList<int> testList1 = new CustomList<int>();
            CustomList<int> testList2 = new CustomList<int>();

            int firstItem = 1;
            int secondItem = 2;
            int thirdItem = 3;

            string expectedValue = "123";
            string actualValue;

            // Act
            testList1.Add(firstItem);       // {1,2,3}
            testList1.Add(secondItem);
            testList1.Add(thirdItem);

            actualValue = (testList1 - testList2).ToString();

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void MinusOperator_SubtractNonEmptyCustomerListFromEmptyCustomerList_DiffEqualsEmptyCustomList()
        {
            // Arrange
            CustomList<int> testList1 = new CustomList<int>();
            CustomList<int> testList2 = new CustomList<int>();

            int firstItem = 1;
            int secondItem = 2;
            int thirdItem = 3;

            string expectedValue = "";
            string actualValue;

            // Act
            testList1.Add(firstItem);       // {1,2,3}
            testList1.Add(secondItem);
            testList1.Add(thirdItem);

            actualValue = (testList2 - testList1).ToString();

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void MinusOperator_CalledOnTwoNonEmptyIntegerCustomListWithCommonValues_CountIsProperCountOfDiffCustomerLists()
        {
            // Arrange
            CustomList<int> testList1 = new CustomList<int>();
            CustomList<int> testList2 = new CustomList<int>();

            int firstItem1 = 1;
            int secondItem1 = 2;
            int thirdItem1 = 3;
            int firstItem2 = 1;
            int secondItem2 = 3;
            int thirdItem2 = 6;

            int expectedValue = 1;
            int actualValue;

            // Act
            testList1.Add(firstItem1);      // {1,2,3}
            testList1.Add(secondItem1);
            testList1.Add(thirdItem1);
            testList2.Add(firstItem2);      // {1,3,6}
            testList2.Add(secondItem2);
            testList2.Add(thirdItem2);

            actualValue = (testList1 - testList2).Count;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void MinusOperator_CalledOnThreeNonEmptyIntegerCustomListWithCommonValues_ReturnsProperDiffIntegerCustomList()
        {
            // Arrange
            CustomList<int> testList1 = new CustomList<int>();
            CustomList<int> testList2 = new CustomList<int>();
            CustomList<int> testList3 = new CustomList<int>();

            int firstItem1 = 1;
            int secondItem1 = 2;
            int thirdItem1 = 3;
            int firstItem2 = 4;
            int secondItem2 = 2;
            int thirdItem2 = 6;
            int firstItem3 = 4;
            int secondItem3 = 2;
            int thirdItem3 = 1;

            string expectedValue = "3";
            string actualValue;

            // Act
            testList1.Add(firstItem1);      // {1,2,3}
            testList1.Add(secondItem1);
            testList1.Add(thirdItem1);
            testList2.Add(firstItem2);      // {4,2,6}
            testList2.Add(secondItem2);
            testList2.Add(thirdItem2);
            testList3.Add(firstItem3);      // {4,2,1}
            testList3.Add(secondItem3);
            testList3.Add(thirdItem3);

            actualValue = (testList1 - testList2 - testList3).ToString();

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void MinusOperator_CalledOnThreeNonEmptyIntegerCustomListWithRepeatedCommonValues_ReturnsProperDiffIntegerCustomList()
        {
            // Arrange
            CustomList<int> testList1 = new CustomList<int>();
            CustomList<int> testList2 = new CustomList<int>();
            CustomList<int> testList3 = new CustomList<int>();

            int firstItem1 = 1;
            int secondItem1 = 2;
            int thirdItem1 = 3;
            int firstItem2 = 4;
            int secondItem2 = 2;
            int thirdItem2 = 6;
            int firstItem3 = 4;
            int secondItem3 = 2;
            int thirdItem3 = 1;

            string expectedValue = "313";
            string actualValue;

            // Act
            testList1.Add(firstItem1);      // {1,2,3,1,2,3}
            testList1.Add(secondItem1);
            testList1.Add(thirdItem1);
            testList1.Add(firstItem1);
            testList1.Add(secondItem1);
            testList1.Add(thirdItem1);
            testList2.Add(firstItem2);      // {4,2,6}
            testList2.Add(secondItem2);
            testList2.Add(thirdItem2);
            testList3.Add(firstItem3);      // {4,2,1}
            testList3.Add(secondItem3);
            testList3.Add(thirdItem3);

            actualValue = (testList1 - testList2 - testList3).ToString();

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        //*****************Zip()*******************************************************************************************
        [TestMethod]
        public void Zip_ZipTwoNonEmptyIntegerCustomLists_ReturnsProperZipResultIntegerCustomList()
        {
            // Arrange
            CustomList<int> testList1 = new CustomList<int>();
            CustomList<int> testList2 = new CustomList<int>();

            int firstItem1 = 1;
            int secondItem1 = 3;
            int thirdItem1 = 5;
            int firstItem2 = 2;
            int secondItem2 = 4;
            int thirdItem2 = 6;

            string expectedValue = "123456";
            string actualValue;

            // Act
            testList1.Add(firstItem1);      // {1,3,5}
            testList1.Add(secondItem1);
            testList1.Add(thirdItem1);
            testList2.Add(firstItem2);      // {2,4,6}
            testList2.Add(secondItem2);
            testList2.Add(thirdItem2);

            testList1.Zip(testList2);

            actualValue = testList1.ToString();

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void Zip_ZipLongIntegerCustomListIntoShortIntegerCustomList_ReturnsProperZipResultIntegerCustomList()
        {
            // Arrange
            CustomList<int> testList1 = new CustomList<int>();
            CustomList<int> testList2 = new CustomList<int>();

            int firstItem1 = 1;
            int secondItem1 = 3;
            int thirdItem1 = 5;
            int firstItem2 = 2;
            int secondItem2 = 4;
            int thirdItem2 = 6;

            string expectedValue = "123456246";
            string actualValue;

            // Act
            testList1.Add(firstItem1);      // {1,3,5}
            testList1.Add(secondItem1);
            testList1.Add(thirdItem1);
            testList2.Add(firstItem2);      // {2,4,6,2,4,6}
            testList2.Add(secondItem2);
            testList2.Add(thirdItem2);
            testList2.Add(firstItem2);
            testList2.Add(secondItem2);
            testList2.Add(thirdItem2);

            testList1.Zip(testList2);

            actualValue = testList1.ToString();

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void Zip_ZipShortIntegerCustomListIntoLongIntegerCustomList_ReturnsProperZipResultIntegerCustomList()
        {
            // Arrange
            CustomList<int> testList1 = new CustomList<int>();
            CustomList<int> testList2 = new CustomList<int>();

            int firstItem1 = 1;
            int secondItem1 = 3;
            int thirdItem1 = 5;
            int firstItem2 = 2;
            int secondItem2 = 4;
            int thirdItem2 = 6;

            string expectedValue = "214365246";
            string actualValue;

            // Act
            testList1.Add(firstItem1);      // {1,3,5}
            testList1.Add(secondItem1);
            testList1.Add(thirdItem1);
            testList2.Add(firstItem2);      // {2,4,6,2,4,6}
            testList2.Add(secondItem2);
            testList2.Add(thirdItem2);
            testList2.Add(firstItem2);
            testList2.Add(secondItem2);
            testList2.Add(thirdItem2);

            testList2.Zip(testList1);

            actualValue = testList2.ToString();

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void Zip_ZipNonEmptyIntegerCustomListIntoEmptyIntegerCustomList_ReturnsProperZipResultIntegerCustomList()
        {
            // Arrange
            CustomList<int> testList1 = new CustomList<int>();
            CustomList<int> testList2 = new CustomList<int>();

            int firstItem2 = 2;
            int secondItem2 = 4;
            int thirdItem2 = 6;

            string expectedValue = "246";
            string actualValue;

            // Act
            testList2.Add(firstItem2);      // {2,4,6}
            testList2.Add(secondItem2);
            testList2.Add(thirdItem2);

            testList1.Zip(testList2);

            actualValue = testList1.ToString();

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void Zip_ZipEmptyIntegerCustomListIntoNonEmptyIntegerCustomList_ReturnsProperZipResultIntegerCustomList()
        {
            // Arrange
            CustomList<int> testList1 = new CustomList<int>();
            CustomList<int> testList2 = new CustomList<int>();

            int firstItem1 = 1;
            int secondItem1 = 3;
            int thirdItem1 = 5;

            string expectedValue = "135";
            string actualValue;

            // Act
            testList1.Add(firstItem1);      // {1,3,5}
            testList1.Add(secondItem1);
            testList1.Add(thirdItem1);

            testList1.Zip(testList2);

            actualValue = testList1.ToString();

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void Zip_ZipNonEmptyIntegerCustomerListIntoItself_ReturnsProperZipResultIntegerCustomList()
        {
            // Arrange
            CustomList<int> testList1 = new CustomList<int>();

            int firstItem1 = 1;
            int secondItem1 = 3;
            int thirdItem1 = 5;

            string expectedValue = "113355";
            string actualValue;

            // Act
            testList1.Add(firstItem1);      // {1,3,5}
            testList1.Add(secondItem1);
            testList1.Add(thirdItem1);

            testList1.Zip(testList1);

            actualValue = testList1.ToString();

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        //*****************Iterable*******************************************************************************************
        [TestMethod]
        public void Iterable_IterateOverNonEmptyIntegerCustomList_IterationProducesProperStringOfIntegers()
        {
            // Arrange
            CustomList<int> testList1 = new CustomList<int>();

            int firstItem1 = 1;
            int secondItem1 = 3;
            int thirdItem1 = 5;

            string expectedValue = "135135";
            string actualValue = "";

            // Act
            testList1.Add(firstItem1);      // {1,3,5,1,3,5}
            testList1.Add(secondItem1);
            testList1.Add(thirdItem1);
            testList1.Add(firstItem1);
            testList1.Add(secondItem1);
            testList1.Add(thirdItem1);

            foreach (int i in testList1)
                actualValue += i.ToString();

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void Iterable_IterateOverEmptyIntegerCustomList_IterationProducesProperEmptyStringOfIntegers()
        {
            // Arrange
            CustomList<int> testList1 = new CustomList<int>();

            string expectedValue = "";
            string actualValue = "";

            // Act
            foreach (int i in testList1)
                actualValue += i.ToString();

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void Iterable_IterateOverNonEmptyStringCustomList_IterationProducesProperStringOfStrings()
        {
            // Arrange
            CustomList<string> testList1 = new CustomList<string>();

            string firstItem1 = "Hello";
            string secondItem1 = " World";
            string thirdItem1 = "!";

            string expectedValue = "Hello World!";
            string actualValue = "";

            // Act
            testList1.Add(firstItem1);      // {"Hello", " World", "!"}
            testList1.Add(secondItem1);
            testList1.Add(thirdItem1);

            foreach (string i in testList1)
                actualValue += i;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void Iterable_IterateOverNonEmptyIntegerCustomListTwice_IterationProducesProperStringOfIntegers()
        {
            // Arrange
            CustomList<int> testList1 = new CustomList<int>();

            int firstItem1 = 1;
            int secondItem1 = 2;
            int thirdItem1 = 3;

            string expectedValue = "123123";
            string actualValue = "";

            // Act
            testList1.Add(firstItem1);      // {1,2,3}
            testList1.Add(secondItem1);
            testList1.Add(thirdItem1);

            foreach (int i in testList1)
                actualValue += i.ToString();
            foreach (int i in testList1)
                actualValue += i.ToString();

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void Iterable_NestedIterationOverNonEmptyIntegerCustomList_IterationProducesProperStringOfIntegers()
        {
            // Arrange
            CustomList<int> testList1 = new CustomList<int>();

            int firstItem1 = 1;
            int secondItem1 = 2;
            int thirdItem1 = 3;

            string expectedValue = "112321233123";
            string actualValue = "";

            // Act
            testList1.Add(firstItem1);      // {1,2,3}
            testList1.Add(secondItem1);
            testList1.Add(thirdItem1);

            foreach (int i in testList1)
            {
                actualValue += i.ToString();
                foreach (int j in testList1)
                    actualValue += j.ToString();
            }

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
