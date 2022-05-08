using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._1_基础数据结构._1._3_队列and栈.栈和队列的互相实现
{
    class Leetcode_225_OneQ
    {
        Queue<int> q1;
        int top = 0;
        public Leetcode_225_OneQ()
        {
            q1 = new Queue<int>();
        }

        public void Push(int x)
        {
            q1.Enqueue(x);
            top = x;
        }

        public int Pop()
        {
            int size = q1.Count;
            while(size > 2)
            {
                q1.Enqueue(q1.Dequeue());
                size--;
            }
            top = q1.Dequeue();
            q1.Enqueue(top);
            return q1.Dequeue();
        }

        public int Top()
        {
            return top;
        }

        public bool Empty()
        {
            return q1.Count == 0;
        }
    }
}
