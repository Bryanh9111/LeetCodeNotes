using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._3_暴_搜索算法._3._1_DFS._4_岛屿题
{
    internal class Leetcode_1020
    {
        public int NumEnclaves(int[][] grid)
        {
            int rLength = grid.Length;
            int cLength = grid[0].Length;

            for(int i = 0; i < rLength; i++)
            {
                // 淹掉左边的陆地
                Helper(grid, i, 0);
                // 淹掉右边的陆地
                Helper(grid, i, cLength - 1);
            }
            for(int j = 0; j< cLength; j++)
            {
                // 淹掉上边的陆地
                Helper(grid, 0, j);
                // 淹掉下边的陆地
                Helper(grid, rLength - 1, j);
            }

            int res = 0;
            for(int i = 0; i < rLength; i++)
            {
                for(int j = 0; j < cLength; j++)
                {
                    if (grid[i][j] == 1)
                        res++;
                }
            }
            return res;
        }
        public void Helper(int[][] grid, int i, int j)
        {
            int rLength = grid.Length;
            int cLength = grid[0].Length;
            if (i < 0 || i >= rLength || j < 0 || j >= cLength)
                return;
            if (grid[i][j] == 0)
                return;

            grid[i][j] = 0;
            Helper(grid, i - 1, j);
            Helper(grid, i + 1, j);
            Helper(grid, i, j - 1);
            Helper(grid, i, j + 1);
        }
    }
}
