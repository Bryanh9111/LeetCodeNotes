using System;
using System.Collections.Generic;
using System.Text;
using LeetcodeNotes.TwoPointer;

namespace LeetcodeNotes.原地修改数组
{
    public class Leetcode_83
    {
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null) return null;
            ListNode slow = head, fast = head;
            while(fast != null)
            {
                if(fast.val != slow.val)
                {
                    slow.next = fast; //nums[slow] = nums[fast]
                    slow = slow.next; //slow++
                }
                fast = fast.next;
            }
            slow.next = null;
            return head;
        }
    }
}
