using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._2_进阶数据结构._2._1_二叉树.总结篇
{
    /// <summary>
    /// 综上，遇到⼀道⼆叉树的题⽬时的通⽤思考过程是：
    ///是否可以通过遍历⼀遍⼆叉树得到答案？如果不能的话，是否可以定义⼀个递归函数，通过⼦问题（⼦树）
    ///的答案推导出原问题的答案？
    ///
    /// 那么换句话说，⼀旦你发现题⽬和⼦树有关，那⼤概率要给函数设置合理的定义和返回值，在后序位置写代
    ///码了。
    ///最坏O(N^2)
    /// </summary>
    class Leetcode_543
    {
        int res = 0;
        public int DiameterOfBinaryTree(TreeNode root)
        {
            Helper(root);
            return res;
        }

        public void Helper(TreeNode root)
        {
            if (root == null)
                return;

            int leftMax = MaxDepth(root.left);
            int rightMax = MaxDepth(root.right);
            int d = leftMax + rightMax;

            res = Math.Max(res, d);

            Helper(root.left);
            Helper(root.right);
        }

        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            int left = MaxDepth(root.left);
            int right = MaxDepth(root.right);
            return 1 + Math.Max(left, right);
        }
    }
    /// <summary>
    /// O(N)
    /// </summary>
    class Leetcode_543_2
    {
        int res = 0;
        public int DiameterOfBinaryTree(TreeNode root)
        {
            MaxDepth(root);
            return res;
        }

        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            int left = MaxDepth(root.left);
            int right = MaxDepth(root.right);

            int d = left + right;
            res = Math.Max(res, d);

            return 1 + Math.Max(left, right);
        }
    }
}
