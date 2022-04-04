using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.链表的递归思维
{
    public class Leetcode_206
    {
        /// <summary>
        /// 反转整个链表
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            ListNode last = ReverseList(head.next);
            head.next.next = head;
            head.next = null;
            return last;
        }



        ListNode successor = null; //后驱节点第n+1个节点
        /// <summary>
        /// 1->2->3->4->5->6->NULL    (N = 3)
        /// 3->2->1->4->5->6->NULL
        /// </summary>
        /// <param name="head"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public ListNode ReverseN(ListNode head, int n)
        {
            if(n == 1)
            {
                //第n+1个节点
                successor = head.next;
                return head;
            }
            //以head.next为起点，需要反转前n-1个节点
            ListNode last = ReverseN(head.next, n - 1);
            head.next.next = head;
            head.next = successor;
            return last;
        }
    }
}
