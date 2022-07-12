using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._4_动态规划._4._4_用动态规划玩游戏._1_团灭_LeetCode_股票买卖问题
{
    /// <summary>
    /// Out of memory. 通不过test
    /// </summary>
    internal class Leetcode_121
    {
        public int MaxProfit(int[] prices)
        {
            int n = prices.Length;
            int[,] dp = new int[n, n];
            int res = 0;
            for(int i = 0; i < n; i++)
            {
                for(int j = i + 1; j < n; j++)
                {
                    dp[i, j] = prices[j] - prices[i];
                    res = Math.Max(res, dp[i, j]);
                }
            }
            return res;
        }
    }
    internal class Leetcode_121_框架解法
    {
        public int MaxProfit(int[] prices)
        {
            int n = prices.Length;
            int[,] dp = new int[n, 2];
            for (int i = 0; i < n; i++)
            {
                if(i == 0)
                {
                    //base case
                    dp[i, 0] = 0;
                    dp[i, 1] = -prices[i];
                    continue;
                }
                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
                dp[i, 1] = Math.Max(dp[i - 1, 1], -prices[i]);
            }
            return dp[n - 1, 0];
        }
    }
    internal class Leetcode_121_lessSpace
    {
        public int MaxProfit(int[] prices)
        {
            int n = prices.Length;
            // base case: dp[-1][0] = 0, dp[-1][1] = -infinity
            int dp_i_0 = 0, dp_i_1 = Int32.MinValue;
            for (int i = 0; i < n; i++)
            {
                dp_i_0 = Math.Max(dp_i_0, dp_i_1 + prices[i]);
                dp_i_1 = Math.Max(dp_i_1, -prices[i]);
            }
            return dp_i_0;
        }
    }
}
