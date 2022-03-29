using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes
{
    //Definition for singly-linked list.
    public class ListNode : IComparable
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
            next = null;
        }

        public int CompareTo(object obj)
        {
            return val.CompareTo(obj);
        }
    }
}
