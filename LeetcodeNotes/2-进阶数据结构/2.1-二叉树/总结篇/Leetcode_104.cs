using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._2_进阶数据结构._2._1_二叉树.总结篇
{
    class Leetcode_104
    {
        int res = 0;// 记录最⼤深度
        int depth = 0;// 记录遍历到的节点的深度
        public int MaxDepth(TreeNode root)
        {
            Helper(root);
            return res;
        }
        /// <summary>
        /// 因为前⾯说了，前序位置是进⼊⼀个节点的时候，后序位置是离开⼀个节点的时候，depth 记录当前递归到
        /// 的节点深度，所以要这样维护
        /// </summary>
        /// <param name="root"></param>
        public void Helper(TreeNode root)
        {
            if (root == null)// 到达叶⼦节点，更新最⼤深度
            {
                res = Math.Max(res, depth);
                return;
            }
            // 前序位置
            depth++;
            Helper(root.left);
            Helper(root.right);
            // 后序位置
            depth--;
        }

        /// <summary>
        /// 分解问题解法
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepth2(TreeNode root)
        {
            if (root == null)
                return 0;

            int leftMax = MaxDepth2(root.left);
            int rightMax = MaxDepth2(root.right);
            // 整棵树的最⼤深度等于左右⼦树的最⼤深度取最⼤值，
            // 然后再加上根节点⾃⼰
            return Math.Max(leftMax, rightMax) + 1;
        }
    }
}
