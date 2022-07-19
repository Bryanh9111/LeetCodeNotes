using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._4_动态规划._4._4_用动态规划玩游戏._6_动态规划帮我通关了魔塔
{
    internal class Leetcode_174
    {
        /// <summary>
        /// 自己写的没跑通，维持两个状态
        /// </summary>
        /// <param name="dungeon"></param>
        /// <returns></returns>
        public int CalculateMinimumHP(int[][] dungeon)
        {
            int n = dungeon.Length;
            //int initial = 1;
            int[,] dp = new int[n, n];
            int[,] initial = new int[n, n];
            initial[0, 0] = 1;
            //base
            dp[0, 0] = initial[0, 0] + dungeon[0][0];
            if (dp[0, 0] <= 0)
            {
                initial[0, 0] = initial[0, 0] + (-dp[0, 0]) + 1;
                dp[0, 0] = 1;
            }
            //base
            for (int i = 1; i < n; i++)
            {
                dp[0, i] = dp[0, i - 1] + dungeon[0][i];
                if (dp[0, i] <= 0)
                {
                    initial[0, i] = initial[0, i - 1] + (-dp[0, i]) + 1;
                    dp[0, i] = 1;
                }
                else
                {
                    initial[0, i] = initial[0, i - 1];
                }

                dp[i, 0] = dp[i - 1, 0] + dungeon[i][0];
                if (dp[i, 0] <= 0)
                {
                    initial[i, 0] = initial[i - 1, 0] + (-dp[i, 0]) + 1;
                    dp[i, 0] = 1;
                }
                else
                {
                    initial[i, 0] = initial[i - 1, 0];
                }
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    int up =  dp[i - 1, j] - initial[i - 1, j];
                    int left = dp[i, j - 1] - initial[i, j - 1];
                    if(up > left)
                    {
                        dp[i, j] = dp[i - 1, j] + dungeon[i][j];
                        if (dp[i, j] <= 0)
                        {
                            initial[i, j] = initial[i - 1, j] + (-dp[i, j]) + 1;
                            dp[i, j] = 1;
                        }
                        else
                        {
                            initial[i, j] = initial[i - 1, j];
                        }
                    }
                    else
                    {
                        dp[i, j] = dp[i, j - 1] + dungeon[i][j];
                        if (dp[i, j] <= 0)
                        {
                            initial[i, j] = initial[i, j - 1] + (-dp[i, j]) + 1;
                            dp[i, j] = 1;
                        }
                        else
                        {
                            initial[i, j] = initial[i, j - 1];
                        }
                    } 
                }
            }

            return initial[n - 1, n - 1];
        }
    }
    /// <summary>
    /// 倒推也有些小错误
    /// </summary>
    internal class Leetcode_174_self_try_2
    {
        public int CalculateMinimumHP(int[][] dungeon)
        {
            int n = dungeon.Length;
            int[,] dp = new int[n, n];
            //base
            dp[n - 1, n - 1] = dungeon[n - 1][n - 1] > 0 ? 1 : -dungeon[n - 1][n - 1] + 1;
            //base
            for (int i = n - 2; i >= 0; i--)
            {
                dp[n - 1, i] = dp[n - 1, i + 1] - dungeon[n - 1][i];
                if (dp[n - 1, i] <= 0)
                    dp[n - 1, i] = 1;

                dp[i, n - 1] = dp[i + 1, n - 1] - dungeon[i][n - 1];
                if (dp[i, n - 1] <= 0)
                    dp[i, n - 1] = 1;
            }

            for (int i = n - 2; i >= 0; i--)
            {
                for (int j = n - 2; j >= 0; j--)
                {
                    dp[i, j] = Math.Min(dp[i + 1, j], dp[i, j + 1]) - dungeon[i][j];
                    if (dp[i, j] <= 0)
                        dp[i, j] = 1;
                }
            }

            return dp[0, 0];
        }
    }

    internal class Leetcode_174_labuladong
    {
        int[,] memo;
        public int CalculateMinimumHP(int[][] dungeon)
        {
            int m = dungeon.Length;
            int n = dungeon[0].Length;
            memo = new int[m, n];

            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    memo[i, j] = -1;

            return dp(dungeon, 0, 0);
        }
        /* 定义：从 (i, j) 到达右下⻆，需要的初始⾎量⾄少是多少 */
        public int dp(int[][] dungeon, int i, int j)
        {
            int m = dungeon.Length;
            int n = dungeon[0].Length;
            //base
            if (i == m - 1 && j == n - 1)
                return dungeon[i][j] >= 0 ? 1 : -dungeon[i][j] + 1;
            if (i == m || j == n)
                return int.MaxValue;

            if (memo[i, j] != -1)
                return memo[i, j];

            int res = Math.Min(dp(dungeon, i, j + 1), dp(dungeon, i + 1, j))
                      - dungeon[i][j];

            // 骑⼠的⽣命值⾄少为 1
            memo[i, j] = res <= 0 ? 1 : res;

            return memo[i, j];
        }
    }
}
