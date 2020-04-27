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
            get { return items[i]; }
            set { items[i] = value; }
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
            if (count == capacity)    // expand capacity of internal array
            {
                T[] tempArray = new T[capacity * 2];
                for (int i = 0; i < count; i++)
                {
                    tempArray[i] = items[i];
                }
                items = tempArray;
                capacity *= 2;
            }
            items[count] = item;
            count++;
        }

        // Removes first occurance of item from the list.
        // Returns true if item was found and removed from the list.
        public bool Remove(T item)
        {
            return false;
        }

    }
}
