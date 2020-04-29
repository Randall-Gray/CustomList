using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListGeneric
{
    public class CustomList<T>
    {
        // Member variables
        private T[] items;
        private int count;
        public int Count { get { return count; } }
        private int capacity;
        public int Capacity { get { return capacity; } }

        // indexer
        public T this[int i]
        {
            get 
            { 
                if (i >= 0 && i < count) 
                    return items[i]; 
                else
                    throw new IndexOutOfRangeException($"Index {i} is out of range.");
            }
            set 
            { 
                if (i >= 0 && i < count)
                   items[i] = value;
                else
                    throw new IndexOutOfRangeException($"Index {i} is out of range.");
            }
        }

        // constructor
        public CustomList()
        {
            items = new T[4];
            count = 0;
            capacity = 4;
        }

        // Member methods
        // Adds item to end of list.
        public void Add(T item)
        {
            if (count == capacity)
            {
                ExpandCapacityOfList();
            }
            items[count] = item;
            count++;
        }

        private void ExpandCapacityOfList()
        {
            T[] tempArray = new T[capacity * 2];        // double capacity each time
            
            for (int i = 0; i < count; i++)
            {
                tempArray[i] = items[i];
            }
            items = tempArray;
            capacity *= 2;
        }

        // Removes first occurance of item from the list.
        // Returns true if item was found and removed from the list.
        public bool Remove(T item)
        {
            int index = FindIndexOfItemInList(item);

            if (index < 0)      // item not found in list
                return false;

            RemoveItemFromListAtIndex(index);

            return true;
        }

        // Returns -1 for the index if the item is not found in the list.
        private int FindIndexOfItemInList(T item)
        {
            bool found = false;
            int index = 0;

            // find item in list
            for (; index < count; index++)
            {
                if (items[index].Equals(item))
                {
                    found = true;
                    break;
                }
            }
            if (!found)
                return -1;
            return index;
        }

        // Item is removed and all subsequent items are moved up.  Capacity of list is unchanged.
        private void RemoveItemFromListAtIndex(int index)
        {
            for (int i = index; i < count - 1; i++)
            {
                items[i] = items[i + 1];
            }
            count--;
            items[count] = default(T);      // "zero" out the item at the end that's no longer part of the list.
        }

        public override string ToString()
        {
            string rtnString = "";

            for (int i = 0; i < count; i++)
            {
                rtnString += items[i].ToString();
            }
            return rtnString;
        }

        // Add two CustomList<T> objects;
        public static CustomList<T> operator + (CustomList<T> list1, CustomList<T> list2)
        {
            CustomList<T> rtnList = new CustomList<T>();

            AppendList(rtnList, list1);
            AppendList(rtnList, list2);

            return rtnList;
        }

        // Appends the items of list2 to the end of list1.
        private static void AppendList(CustomList<T> list1, CustomList<T> list2)
        {
            for (int i = 0; i < list2.Count; i++)
                list1.Add(list2[i]);
        }

        // Subtract two CustomList<T> objects;
        public static CustomList<T> operator -(CustomList<T> list1, CustomList<T> list2)
        {
            CustomList<T> rtnList = new CustomList<T>();

            AppendList(rtnList, list1);
            RemoveList(rtnList, list2);

            return rtnList;
        }

        // Removes the items of list2 from list1 if they exist.
        private static void RemoveList(CustomList<T> list1, CustomList<T> list2)
        {
            for (int i = 0; i < list2.Count; i++)
                list1.Remove(list2[i]);
        }

        // Interlace the items of inList with this CustomList<T> items.
        public void Zip(CustomList<T> inList)
        {
            int itemsIndex = 0;
            int inListIndex = 0;
            bool myList = true;

            CustomList<T> newList = new CustomList<T>();

            while (itemsIndex < count || inListIndex < inList.count)
            {
                if (myList && itemsIndex < count)            // take from items
                {
                    newList.Add(items[itemsIndex]);
                    itemsIndex++;
                }
                else if (inListIndex < inList.count)         // take from inList
                {
                    newList.Add(inList[inListIndex]);
                    inListIndex++;
                }
                myList = !myList;
            }
            CopyList(this, newList);
        }

        // Copies list2 to list1.  ie. list1 = list2
        private void CopyList(CustomList<T> list1, CustomList<T> list2)
        {
            for (int i = list1.count-1; i >= 0; i--)       // clear out list1 from end to prevent shifting objects
                list1.Remove(list1[i]);

            for (int i = 0; i < list2.count; i++)       // copy list2 to list1
                list1.Add(list2[i]);
        }
    }
}
