using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._3_暴_搜索算法._3._1_DFS._4_岛屿题
{
    internal class Leetcode_200
    {
        public int NumIslands(char[][] grid)
        {
            int res = 0;
            int rowLength = grid.Length;
            int colLength = grid[0].Length;
            // 遍历 grid
            for (int i = 0; i < rowLength; i++)
            {
                for(int j = 0; j < colLength; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        // 每发现⼀个岛屿，岛屿数量加⼀
                        res++;
                        // 然后使⽤ DFS 将岛屿淹了
                        Helper(grid, i, j);
                    }
                }
            }
            return res;
        }
        // 从 (i, j) 开始，将与之相邻的陆地都变成海⽔
        public void Helper(char[][] grid, int i, int j)
        {
            int rowLength = grid.Length;
            int colLength = grid[0].Length;

            // 超出索引边界
            if (i < 0 || j < 0 || i >= rowLength || j >= colLength)
                return;
            // 已经是海⽔了
            if (grid[i][j] == '0')
                return;

            // 将 (i, j) 变成海⽔
            grid[i][j] = '0';
            // 淹没上下左右的陆地
            Helper(grid, i - 1, j);
            Helper(grid, i + 1, j);
            Helper(grid, i, j - 1);
            Helper(grid, i, j + 1);
        }
    }
}
