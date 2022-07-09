using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._4_动态规划._4._3_背包问题._2_完全背包问题
{
    internal class Leetcode_518
    {
        public int Change(int amount, int[] coins)
        {
            int[,] dp = new int[amount + 1, coins.Length + 1];
            for (int i = 1; i <= amount; i++)
                dp[i, 0] = 0;
            for (int j = 1; j <= coins.Length; j++)
                dp[0, j] = 1;

            for (int i = 1; i <= amount; i++)
            {
                for (int j = 1; j <= coins.Length; j++)
                {
                    if (i - coins[j - 1] >= 0)
                        dp[i, j] = dp[i, j - 1] + dp[i - coins[j - 1], j];
                    else
                        dp[i, j] = dp[i, j - 1];
                }
            }
            return dp[amount, coins.Length];
        }
    }

    internal class Leetcode_518_lessspace
    {
        public int Change(int amount, int[] coins)
        {
            int[] dp = new int[amount + 1];
            dp[0] = 1;
            for (int i = 0; i < coins.Length; i++)
            {
                for (int j = 1; j <= amount; j++)
                {
                    if (j - coins[i] >= 0)
                        dp[j] = dp[j] + dp[j - coins[i]];
                }
            }
            return dp[amount];
        }
    }
}
