using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.单链表
{

    public class Leetcode_19
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode dummy = new ListNode(-1);
            dummy.next = head;
            ListNode x = FindFromEnd(dummy, n + 1);
            x.next = x.next.next;
            return dummy.next;
        }

        private ListNode FindFromEnd(ListNode head, int k)
        {
            ListNode p1 = head;
            while (k-- > 0)
                p1 = p1.next;

            ListNode p2 = head;
            while(p1 != null)
            {
                p2 = p2.next;
                p1 = p1.next;
            }
            return p2;
        }
    }
}
