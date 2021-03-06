using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.PrefixAndArray
{
    /// <summary>
    /// Range Sum Query - Immutable
    /// reduce the time complexity from O(N) to O(1): no for loop in SumRange
    /// </summary>
    public class Leetcode_303
    {
        private int[] preSum;

        public Leetcode_303(int[] nums)
        {
            preSum = new int[nums.Length + 1];
            for (int i = 1; i < preSum.Length; i++)
                preSum[i] = preSum[i - 1] + nums[i - 1];
        }
        /// <summary>
        /// TC: O(1)
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public int SumRange(int left, int right)
        {
            return preSum[right + 1] - preSum[left];
        }
    }

    public class Leetcode_303SLOW
    {
        private int[] nums;

        public Leetcode_303SLOW(int[] nums)
        {
            this.nums = nums;
        }
        /// <summary>
        /// TC: O(N)
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public int SumRange(int left, int right)
        {
            int res = 0;
            for (int i = left; i <= right; i++)
                res += nums[i];

            return res;
        }
    }
}
