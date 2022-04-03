using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes
{
    /// <summary>
    /// O(1)
    /// </summary>
    public class MonotonicQueue_DESC
    {
        //双链表，⽀持头部和尾部增删元素
        private LinkedList<int> q;
        public MonotonicQueue_DESC()
        {
            q = new LinkedList<int>();
        }

        //在队尾添加元素
        public void Push(int n)
        {
            // 将前⾯⼩于⾃⼰的元素都删除
            while (q.Count > 0 && q.Last.Value < n)
                q.RemoveLast();
            q.AddLast(n);
        }
        //返回当前队列的最大值
        public int Max()
        {
            // 队头的元素肯定是最⼤的
            return q.First.Value;
        }
        //对头元素如果是n，删除它
        public void Pop(int n)
        {
            //是因为我们想删除的队头元素 n 可能已经被「压扁」了，可能已经不
            //存在了，所以这时候就不⽤删除了
            if (n == q.First.Value)
                q.RemoveFirst();
        }
    }
}
