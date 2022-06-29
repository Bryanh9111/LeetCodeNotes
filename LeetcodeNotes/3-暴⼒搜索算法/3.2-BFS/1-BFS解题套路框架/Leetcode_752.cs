using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._3_暴_搜索算法._3._2_BFS._1_BFS解题套路框架
{
    internal class Leetcode_752
    {
        public int OpenLock(string[] deadends, string target)
        {
            // 记录需要跳过的死亡密码
            HashSet<string> deads = new HashSet<string>();
            foreach (string s in deadends)
                deads.Add(s);
            // 记录已经穷举过的密码，防⽌⾛回头路
            HashSet<string> visited = new HashSet<string>();

            // 从起点开始启动⼴度优先搜索
            Queue<string> q = new Queue<string>();
            int step = 0;
            q.Enqueue("0000");
            visited.Add("0000");

            while(q.Count > 0)
            {
                int size = q.Count;
                /* 将当前队列中的所有节点向周围扩散 */
                for (int i = 0; i < size; i++)
                {
                    string cur = q.Dequeue();

                    /* 判断是否到达终点 */
                    if (deads.Contains(cur))
                        continue;
                    if (string.Equals(target, cur))
                        return step;

                    /* 将⼀个节点的未遍历相邻节点加⼊队列 */
                    for (int j = 0; j < 4; j++)
                    {
                        string up = PlusOne(cur, j);
                        if (visited.Add(up))
                            q.Enqueue(up);

                        string down = MinusOne(cur, j);
                        if (visited.Add(down))
                            q.Enqueue(down);
                    }
                }
                /* 在这⾥增加步数 */
                step++;
            }
            // 如果穷举完都没找到⽬标密码，那就是找不到了
            return -1;
        }

        public string PlusOne(string s, int j)
        {
            char[] ch = s.ToCharArray();
            if (ch[j] == '9')
                ch[j] = '0';
            else
                ch[j] = (char)(ch[j] + 1);

            return new string(ch);
        }

        public string MinusOne(string s, int j)
        {
            char[] ch = s.ToCharArray();
            if (ch[j] == '0')
                ch[j] = '9';
            else
                ch[j] = (char)(ch[j] - 1);

            return new string(ch);
        }

        /// <summary>
        /// 伪代码(框架)
        /// </summary>
        /// <param name="target"></param>
        public void BFS(string target)
        {
            Queue<string> q = new Queue<string>();
            q.Enqueue("0000");

            while(q.Count > 0)
            {
                int size = q.Count;
                for(int i = 0; i < size; i++)
                {
                    string cur = q.Dequeue();

                    for(int j = 0; j < 4; j++)
                    {
                        string up = PlusOne(cur, j);
                        string down = MinusOne(cur, j);
                        q.Enqueue(up);
                        q.Enqueue(down);
                    }
                }
            }
        }
    }
}
