using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._3_暴_搜索算法._3._1_DFS._4_岛屿题
{
    internal class Leetcode_694
    {
        public int NumDistinctIslands(int[][] grid)
        {
            // 记录所有岛屿的序列化结果
            HashSet<string> st = new HashSet<string>();
            int rowLength = grid.Length;
            int colLength = grid[0].Length;

            for(int i = 0; i < rowLength; i++)
            {
                for(int j = 0; j < colLength; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        // 淹掉这个岛屿，同时存储岛屿的序列化结果
                        StringBuilder sb = new StringBuilder();
                        Helper(grid, i, j, sb, 666);// 初始的⽅向可以随便写，不影响正确性
                        st.Add(sb.ToString());
                    }
                }
            }
            return st.Count;
        }
        public void Helper(int[][] grid, int i, int j, StringBuilder sb, int direction)
        {
            int rowLength = grid.Length;
            int colLength = grid[0].Length;
            if (i < 0 || i >= rowLength || j < 0 || j >= colLength)
                return;
            if (grid[i][j] == 0)
                return;

            // 前序遍历位置：进⼊ (i, j)
            grid[i][j] = 0;
            sb.Append(direction);

            Helper(grid, i - 1, j, sb, 1);
            Helper(grid, i + 1, j, sb, 2);
            Helper(grid, i, j - 1, sb, 3);
            Helper(grid, i, j + 1, sb, 4);
            // 后序遍历位置：离开 (i, j)
            sb.Append(-direction);
        }
    }
}
