using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.单链表
{
    class Leetcode_876
    {
        public ListNode MiddleNode(ListNode head)
        {
            ListNode fast = head, slow = head;
            while(fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            return slow;
        }
    }
}
