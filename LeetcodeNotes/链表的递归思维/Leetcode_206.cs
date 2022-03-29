using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.链表的递归思维
{
    class Leetcode_206
    {
        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            ListNode last = ReverseList(head.next);
            head.next.next = head;
            head.next = null;
            return last;
        }
    }
}
