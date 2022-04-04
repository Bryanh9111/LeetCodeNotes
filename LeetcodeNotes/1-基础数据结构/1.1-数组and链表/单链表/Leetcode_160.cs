using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.单链表
{
    class Leetcode_160
    {
        /// <summary>
        /// TC: O(N)   SC: O(1)
        /// </summary>
        /// <param name="headA"></param>
        /// <param name="headB"></param>
        /// <returns></returns>
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            ListNode p1 = headA;
            ListNode p2 = headB;
            while(p1 != p2)
            {
                if (p1 == null) p1 = headB;
                else p1 = p1.next;

                if (p2 == null) p2 = headA;
                else p2 = p2.next;
            }
            return p1;
        }
    }
}
