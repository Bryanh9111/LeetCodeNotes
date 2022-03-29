using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.Collections
{
    public class PriorityQueue_BySortedList<T>: IPriorityQueue_BySortedList<T> where T: IComparable<T>
    {
        private SortedList<T, int> lst;
        private int count;
        public PriorityQueue_BySortedList()
        {
            lst = new SortedList<T, int>();
            count = 0;
        }
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            if (lst.ContainsKey(item))
                lst[item]++;
            else
                lst.Add(item, 1);
            count++;
        }
        public int Size()
        {
            return count;
        }
        public T PopFirst()
        {
            if (Size() == 0) return default(T);
            T result = lst.Keys[0];
            if (--lst[result] == 0)
                lst.RemoveAt(0);

            count--;
            return result;
        }
        public T PopLast()
        {
            if (Size() == 0) return default(T);
            int index = lst.Count - 1;
            T result = lst.Keys[index];
            if (--lst[result] == 0)
                lst.RemoveAt(index);
            count--;
            return result;
        }
        public T PeekFirst()
        {
            if (Size() == 0) return default(T);
            return lst.Keys[0];
        }
        public T PeekLast()
        {
            if (Size() == 0) return default(T);
            int index = lst.Count - 1;
            return lst.Keys[index];
        }
    }
}
