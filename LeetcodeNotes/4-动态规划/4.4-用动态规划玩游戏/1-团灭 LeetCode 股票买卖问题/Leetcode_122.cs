using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._4_动态规划._4._4_用动态规划玩游戏._1_团灭_LeetCode_股票买卖问题
{
    internal class Leetcode_122
    {
        public int MaxProfit(int[] prices)
        {
            int n = prices.Length;
            int[,] dp = new int[n, 2];

            for(int i = 0; i < n; i++)
            {
                if(i == 0)
                {
                    dp[i, 0] = 0;
                    dp[i, 1] = -prices[i];
                    continue;
                }
                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
                dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 0] - prices[i]);
            }

            return dp[n - 1, 0];
        }
    }
    internal class Leetcode_122_LessSpace
    {
        public int MaxProfit(int[] prices)
        {
            int n = prices.Length;
            int dp_i_0 = 0;
            int dp_i_1 = -prices[0];

            for (int i = 0; i < n; i++)
            {
                dp_i_0 = Math.Max(dp_i_0, dp_i_1 + prices[i]);
                dp_i_1 = Math.Max(dp_i_1, dp_i_0 - prices[i]);
            }

            return dp_i_0;
        }
    }
}
