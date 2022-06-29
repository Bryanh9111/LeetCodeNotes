using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._3_暴_搜索算法._3._2_BFS._1_BFS解题套路框架
{
    internal class Leetcode_111
    {
        public int MinDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            // root 本身就是⼀层，depth 初始化为 1
            int depth = 1;

            while(q.Count > 0)
            {
                int size = q.Count;
                /* 将当前队列中的所有节点向四周扩散 */
                for (int i = 0; i < size; i++)
                {
                    TreeNode cur = q.Dequeue();
                    /* 判断是否到达终点 */
                    if (cur.left == null && cur.right == null)
                        return depth;
                    /* 将 cur 的相邻节点加⼊队列 */
                    if (cur.left != null)
                        q.Enqueue(cur.left);
                    if (cur.right != null)
                        q.Enqueue(cur.right);
                }
                /* 这⾥增加步数 */
                depth++;
            }
            return depth;
        }
    }
}
