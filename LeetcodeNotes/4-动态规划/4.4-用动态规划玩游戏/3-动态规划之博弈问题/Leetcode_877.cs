using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._4_动态规划._4._4_用动态规划玩游戏._3_动态规划之博弈问题
{
    internal class Leetcode_877
    {
        /* 返回游戏最后先⼿和后⼿的得分之差 */
        public bool StoneGame(int[] piles)
        {
            int n = piles.Length;
            int[,,] dp = new int[n, n, 2];
            // 填⼊ base case
            for (int i = 0; i < n; i++)
            {
                dp[i, i, 0] = piles[i];
                dp[i, i, 1] = 0;
            }
            // 倒着遍历数组
            for (int i = n - 2; i >= 0; i--)
            {
                for(int j = i + 1; j < n; j++)
                {
                    // 先⼿选择最左边或最右边的分数
                    int left = piles[i] + dp[i + 1, j, 1];
                    int right = piles[j] + dp[i, j - 1, 1];
                    // 套⽤状态转移⽅程
                    // 先⼿肯定会选择更⼤的结果，后⼿的选择随之改变
                    if (left > right)
                    {
                        dp[i, j, 0] = left;
                        dp[i, j, 1] = dp[i + 1, j, 0];
                    }
                    else
                    {
                        dp[i, j, 0] = right;
                        dp[i, j, 1] = dp[i, j - 1, 0];
                    }
                }
            }
            return (dp[0, n - 1, 0] - dp[0, n - 1, 1]) > 0;
        }
    }
}
