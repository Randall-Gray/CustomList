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
            return new CustomList<T>();
        }
    }
}
