using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._2_进阶数据结构._2._2_二叉搜索树._3
{
    class Leetcode_95
    {
        public IList<TreeNode> GenerateTrees(int n)
        {
            if (n == 0)
                return null;
            // 构造闭区间 [1, n] 组成的 BST 
            return Helper(1, n);
        }
        /* 构造闭区间 [lo, hi] 组成的 BST */
        public IList<TreeNode> Helper(int low, int high)
        {
            IList<TreeNode> res = new List<TreeNode>();
            if (low > high)
            {
                res.Add(null);
                return res;
            }
            // 1、穷举 root 节点的所有可能。
            for (int i = low; i <= high; i++)
            {
                // 2、递归构造出左右子树的所有合法 BST。
                IList<TreeNode> leftTree = Helper(low, i - 1);
                IList<TreeNode> rightTree = Helper(i + 1, high);
                // 3、给 root 节点穷举所有左右子树的组合。
                foreach (var left in leftTree)
                {
                    foreach(var right in rightTree)
                    {
                        // i 作为根节点 root 的值
                        TreeNode root = new TreeNode(i);
                        root.left = left;
                        root.right = right;
                        res.Add(root);
                    }
                }
            }
            return res;
        }
    }
}
