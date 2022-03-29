using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.Collections
{
    public interface IPriorityQueue_BySortedList<T>
    {
        void Add(T item);
        T PopFirst();
        T PopLast();
        int Size();
        T PeekFirst();
        T PeekLast();
    }
}
