using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._3_暴_搜索算法._3._1_DFS._4_岛屿题
{
    internal class Leetcode_1254
    {
        public int ClosedIsland(int[][] grid)
        {
            int rowLength = grid.Length;
            int colLength = grid[0].Length;
            for(int i = 0; i < rowLength; i++)
            {
                // 把靠左边的岛屿淹掉
                Helper(grid, i, 0);
                // 把靠右边的岛屿淹掉
                Helper(grid, i, colLength - 1);
            }
            for(int j = 0; j < colLength; j++)
            {
                // 把靠上边的岛屿淹掉
                Helper(grid, 0, j);
                // 把靠下边的岛屿淹掉
                Helper(grid, rowLength - 1, j);
            }
            // 遍历 grid，剩下的岛屿都是封闭岛屿
            int res = 0;
            for(int i = 0; i < rowLength; i++)
            {
                for(int j = 0; j < colLength; j++)
                {
                    if (grid[i][j] == 0)
                    {
                        res++;
                        Helper(grid, i, j);
                    }  
                }
            }
            return res;
        }
        // 从 (i, j) 开始，将与之相邻的陆地都变成海⽔
        public void Helper(int[][] grid, int i, int j)
        {
            int rowLength = grid.Length;
            int colLength = grid[0].Length;
            if (i < 0 || i >= rowLength || j < 0 || j >= colLength)
                return;
            if (grid[i][j] == 1)// 已经是海⽔了
                return;
            grid[i][j] = 1;// 将 (i, j) 变成海⽔
            // 淹没上下左右的陆地
            Helper(grid, i - 1, j);
            Helper(grid, i + 1, j);
            Helper(grid, i, j - 1);
            Helper(grid, i, j + 1);
        }
    }
}
