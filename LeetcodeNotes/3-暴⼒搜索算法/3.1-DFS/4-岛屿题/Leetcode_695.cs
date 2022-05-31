using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._3_暴_搜索算法._3._1_DFS._4_岛屿题
{
    internal class Leetcode_695
    {
        public int MaxAreaOfIsland(int[][] grid)
        {
            int max = 0;// 记录岛屿的最⼤⾯积
            int rowLength = grid.Length;
            int colLength = grid[0].Length;

            for(int i = 0; i < rowLength; i++)
            {
                for(int j = 0; j < colLength; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        // 淹没岛屿，并更新最⼤岛屿⾯积
                        max = Math.Max(Helper(grid, i, j), max);
                    }
                }
            }
            return max;
        }
        public int Helper(int[][] grid, int i, int j)
        {
            int rowLength = grid.Length;
            int colLength = grid[0].Length;

            if (i < 0 || i >= rowLength || j < 0 || j >= colLength)
            {
                // 超出索引边界
                return 0;
            }

            if (grid[i][j] == 0)
            {
                // 已经是海⽔了
                return 0 ;
            }
            // 将 (i, j) 变成海⽔
            grid[i][j] = 0;

            // (i, j) 本身加上下左右四个方向
            return 1 + Helper(grid, i - 1, j)
                      + Helper(grid, i + 1, j)
                      + Helper(grid, i, j - 1)
                      + Helper(grid, i, j + 1);
        }
    }
}
