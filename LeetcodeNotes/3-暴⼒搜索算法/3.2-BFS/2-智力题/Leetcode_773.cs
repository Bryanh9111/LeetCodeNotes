using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._3_暴_搜索算法._3._2_BFS._2_智力题
{
    internal class Leetcode_773
    {
        public int SlidingPuzzle(int[][] board)
        {
            int rowLength = 2;
            int colLength = 3;

            StringBuilder sb = new StringBuilder();
            string target = "123450";

            // 将 2x3 的数组转化成字符串作为 BFS 的起点
            for (int i = 0; i < rowLength; i++)
            {
                for(int j = 0; j < colLength; j++)
                {
                    sb.Append(board[i][j]);
                }
            }

            string start = sb.ToString();

            // 记录⼀维字符串的相邻索引
            int[][] neighbor = new int[][]
            {
                new int[]{ 1, 3},
                new int[]{ 0, 4, 2},
                new int[]{ 1, 5},
                new int[]{ 0, 4},
                new int[]{ 3, 1, 5},
                new int[]{ 4, 2}
            };


            /******* BFS 算法框架开始 *******/
            Queue<string> q = new Queue<string>();
            HashSet<string> visited = new HashSet<string>();
            int step = 0;
            q.Enqueue(start);
            visited.Add(start);

            while(q.Count > 0)
            {
                int size = q.Count;
                for(int i = 0; i < size; i++)
                {
                    string cur = q.Dequeue();

                    if (string.Equals(cur, target))
                        return step;

                    // 找到数字 0 的索引
                    int index_zero = 0;
                    while (cur[index_zero] != '0')
                        index_zero++;

                    foreach(int adj in neighbor[index_zero])
                    {
                        string new_board = Swap(cur, adj, index_zero);
                        if (visited.Add(new_board))
                            q.Enqueue(new_board);
                    }
                }
                step++;
            }

            return -1;
        }

        public string Swap(string s, int i, int j)
        {
            char[] ch = s.ToCharArray();
            char temp = ch[i];
            ch[i] = ch[j];
            ch[j] = temp;
            return new string(ch);
        }
    }
}
