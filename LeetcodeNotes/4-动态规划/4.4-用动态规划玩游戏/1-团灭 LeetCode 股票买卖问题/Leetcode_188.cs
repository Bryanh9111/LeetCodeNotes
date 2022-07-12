using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._4_动态规划._4._4_用动态规划玩游戏._1_团灭_LeetCode_股票买卖问题
{
    internal class Leetcode_188
    {
        public int MaxProfit(int k, int[] prices)
        {
            int n = prices.Length;
            if (n == 0) 
                return 0;
            int[,,] dp = new int[n, k + 1, 2];
            for(int i = 0; i < n; i++)
            {
                for(int j = k; j >= 1; j--)
                {
                    if(i == 0)
                    {
                        dp[i, j, 0] = 0;
                        dp[i, j, 1] = -prices[i];
                        continue;
                    }
                    dp[i, j, 0] = Math.Max(dp[i - 1, j, 0], dp[i - 1, j, 1] + prices[i]);
                    dp[i, j, 1] = Math.Max(dp[i - 1, j, 1], dp[i - 1, j - 1, 0] - prices[i]);
                }
            }
            return dp[n - 1, k, 0];
        }
    }
}
