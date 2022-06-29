using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._4_动态规划._4._2_经典动态规划
{
    internal class Leetcode_53
    {
        public int MaxSubArray(int[] nums)
        {
            if (nums == null)
                return 0;

            // 定义：dp[i] 记录以 nums[i] 为结尾的「最⼤⼦数组和」
            int[] dp = new int[nums.Length];
            // base case
            // 第⼀个元素前⾯没有⼦数组
            dp[0] = nums[0];
            // 状态转移⽅程
            for (int i = 1; i < nums.Length; i++)
            {
                dp[i] = Math.Max(nums[i], nums[i] + dp[i - 1]);
            }
            // 得到 nums 的最⼤⼦数组
            int res = -10001;
            for(int i = 0; i < dp.Length; i++)
            {
                res = Math.Max(res, dp[i]);
            }

            return res;
        }
    }

    internal class Leetcode_53_空间小
    {
        public int MaxSubArray(int[] nums)
        {
            if (nums == null)
                return 0;

            int pre = nums[0];
            int res = pre;

            for (int i = 1; i < nums.Length; i++)
            {
                int cur = Math.Max(nums[i], nums[i] + pre);
                res = Math.Max(res, cur);

                pre = cur;
            }
            return res;
        }
    }
}
