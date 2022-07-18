using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._4_动态规划._4._4_用动态规划玩游戏._4_动态规划之最小路径和
{
    internal class Leetcode_64
    {
        public int MinPathSum(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int[,] dp = new int[m, n];

            dp[0, 0] = grid[0][0];

            for (int i = 1; i < m; i++)
                dp[i, 0] = dp[i - 1, 0] + grid[i][0];
            for (int j = 1; j < n; j++)
                dp[0, j] = dp[0, j - 1] + grid[0][j];

            for(int i = 1; i < m; i++)
            {
                for(int j = 1; j < n; j++)
                {
                    dp[i, j] = grid[i][j] + Math.Min(dp[i, j - 1], dp[i - 1, j]);
                }
            }


            return dp[m - 1, n - 1];
        }
    }

    internal class Leetcode_64_bt
    {
        int[,] memo;
        public int MinPathSum(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            memo = new int[m, n];

            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    memo[i, j] = -1;

            return dp(grid, m - 1, n - 1);
        }
        public int dp(int[][] grid, int i, int j)
        {
            if (i == 0 && j == 0)
                return grid[0][0];

            if (i < 0 || j < 0)
                return int.MaxValue;

            if (memo[i, j] != -1)
                return memo[i, j];

            memo[i, j] =  grid[i][j] + Math.Min(dp(grid, i - i, j), dp(grid, i, j - 1));

            return memo[i, j];
        }
    }

    internal class Leetcode_64_bt2
    {
        int[,] memo;
        public int MinPathSum(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            memo = new int[m, n];

            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    memo[i, j] = -1;

            return dp(grid, 0, 0);
        }
        public int dp(int[][] grid, int i, int j)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            if (i == m - 1 && j == n - 1)
                return grid[i][j];

            if (i >= m || j >= n)
                return int.MaxValue;

            if (memo[i, j] != -1)
                return memo[i, j];

            memo[i, j] = grid[i][j] + Math.Min(dp(grid, i + 1, j), dp(grid, i, j + 1));

            return memo[i, j];
        }
    }
}
