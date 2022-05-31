using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._3_暴_搜索算法._3._1_DFS._4_岛屿题
{
    internal class Leetcode_1905
    {
        public int CountSubIslands(int[][] grid1, int[][] grid2)
        {
            int rowLength = grid1.Length;
            int colLength = grid1[0].Length;
            for(int i = 0; i < rowLength; i++)
            {
                for(int j = 0; j < colLength; j++)
                {
                    if (grid1[i][j] == 0 && grid2[i][j] == 1)
                        Helper(grid2, i , j);// 这个岛屿肯定不是⼦岛，淹掉
                }
            }
            // 现在 grid2 中剩下的岛屿都是⼦岛，计算岛屿数量
            int res = 0;
            for(int i = 0; i < rowLength; i++)
            {
                for(int j = 0; j < colLength; j++)
                {
                    if (grid2[i][j] == 1)
                    {
                        res++;
                        Helper(grid2, i, j);
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
