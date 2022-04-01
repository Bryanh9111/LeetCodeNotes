using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes
{
    public class MonotonicQueue_ASC
    {
        private LinkedList<int> q;
        public MonotonicQueue_ASC()
        {
            q = new LinkedList<int>();
        }
        public void Push(int n)
        {
            //删除窗口中所有比n大的元素
            while (q.Count > 0 && q.Last.Value >= n)
                q.RemoveLast();
            q.AddLast(n);
        }
        public int Min()
        {
            return q.First.Value;
        }
        public void Pop(int n)
        {
            if (n == q.First.Value)
                q.RemoveFirst();
        }
    }
}
