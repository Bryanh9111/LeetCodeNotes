using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.单调队列解决滑动窗口
{
    class Leetcode_239
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            MonotonicQueue_DESC window = new MonotonicQueue_DESC();
            IList<int> res = new List<int>();

            for(int i = 0; i < nums.Length; i++)
            {
                if (i < k - 1)//先填满窗口
                    window.Push(nums[i]);
                else
                {
                    //窗口向前移动，移入新元素
                    window.Push(nums[i]);
                    res.Add(window.Max());
                    window.Pop(nums[i - k + 1]);
                }
            }
            int[] arr = new int[res.Count];
            for (int i = 0; i < res.Count; i++)
                arr[i] = res[i];
            return arr;
        }

        public int[] MinSlidingWindow(int[] nums, int k)
        {
            MonotonicQueue_ASC window = new MonotonicQueue_ASC();
            IList<int> res = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (i < k - 1)//先填满窗口
                    window.Push(nums[i]);
                else
                {
                    //窗口向前移动，移入新元素
                    window.Push(nums[i]);
                    res.Add(window.Min());
                    window.Pop(nums[i - k + 1]);
                }
            }
            int[] arr = new int[res.Count];
            for (int i = 0; i < res.Count; i++)
                arr[i] = res[i];
            return arr;
        }
    }
}
