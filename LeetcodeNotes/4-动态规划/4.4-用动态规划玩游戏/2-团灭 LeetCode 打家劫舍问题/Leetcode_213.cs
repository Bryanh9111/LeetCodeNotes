using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._4_动态规划._4._4_用动态规划玩游戏._2_团灭_LeetCode_打家劫舍问题
{
    internal class Leetcode_213
    {
        public int Rob(int[] nums)
        {
            int n = nums.Length;
            if (n == 1) return nums[0];
            return Math.Max(
                RobRange(nums, 0, n - 2),
                RobRange(nums, 1, n - 1)
                );
        }
        public int RobRange(int[] nums, int start, int end)
        {
            int n = nums.Length;
            int dp_i_1 = 0, dp_i_2 = 0; // 记录 dp[i+1] 和 dp[i+2]
            int dp_i = 0; // 记录 dp[i]

            for (int i = end; i >= start; i--)
            {
                dp_i = Math.Max(dp_i_1, dp_i_2 + nums[i]);
                dp_i_2 = dp_i_1;
                dp_i_1 = dp_i;
            }
            return dp_i;
        }
    }
}
