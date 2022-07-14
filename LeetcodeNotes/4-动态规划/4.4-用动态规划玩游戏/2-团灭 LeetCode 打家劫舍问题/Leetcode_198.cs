using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._4_动态规划._4._4_用动态规划玩游戏._2_团灭_LeetCode_打家劫舍问题
{
    /// <summary>
    /// 自己写的
    /// </summary>
    internal class Leetcode_198
    {
        public int Rob(int[] nums)
        {
            int n = nums.Length;
            int[] dp = new int[n + 1];

            for(int i = 1; i <= n; i++)
            {
                if(i == 1)
                {
                    dp[i] = Math.Max(dp[0] + nums[0], dp[0]);
                    continue;
                }
                dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i - 1]);
            }
            return dp[n];
        }
    }
    /// <summary>
    /// labuladong
    /// </summary>
    internal class Leetcode_198_labuladon
    {
        public int Rob(int[] nums)
        {
            int n = nums.Length;
            // dp[i] = x 表示：
            // 从第 i 间房子开始抢劫，最多能抢到的钱为 x
            // base case: dp[n] = 0
            int[] dp = new int[n + 2];

            for (int i = n - 1; i >= 0; i--)
            {
                dp[i] = Math.Max(dp[i + 1], dp[i + 2] + nums[i]);
            }
            return dp[0];
        }
    }
    /// <summary>
    /// labuladong
    /// </summary>
    internal class Leetcode_198_labuladon_LessSpace
    {
        public int Rob(int[] nums)
        {
            int n = nums.Length;
            int dp_i_1 = 0, dp_i_2 = 0; // 记录 dp[i+1] 和 dp[i+2]
            int dp_i = 0; // 记录 dp[i]

            for (int i = n - 1; i >= 0; i--)
            {
                dp_i = Math.Max(dp_i_1, dp_i_2 + nums[i]);
                dp_i_2 = dp_i_1;
                dp_i_1 = dp_i;
            }
            return dp_i;
        }
    }
    /// <summary>
    /// time limit exceeds
    /// </summary>
    internal class Leetcode_198_labuladon_backtracking
    {
        public int Rob(int[] nums)
        {
            return dp(nums, 0);
        }
        // 返回 nums[start..] 能抢到的最大值
        public int dp(int[] nums, int start)
        {
            if (start >= nums.Length)
                return 0;

            return Math.Max(
                dp(nums, start + 1), // 不抢，去下家
                nums[start] + dp(nums, start + 2) // 抢，去下下家
                );
        }
    }
    internal class Leetcode_198_labuladon_backtracking_memo
    {
        int[] memo;
        public int Rob(int[] nums)
        {
            memo = new int[nums.Length];
            for (int i = 0; i < memo.Length; i++)
                memo[i] = -1;
            return dp(nums, 0);
        }
        // 返回 nums[start..] 能抢到的最大值
        public int dp(int[] nums, int start)
        {
            if (start >= nums.Length)
                return 0;

            if (memo[start] != -1)
                return memo[start];

            memo[start] = Math.Max(
                dp(nums, start + 1), // 不抢，去下家
                nums[start] + dp(nums, start + 2) // 抢，去下下家
                );

            return memo[start];
        }
    }
}
