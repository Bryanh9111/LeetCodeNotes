using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._2_进阶数据结构._2._1_二叉树._3
{
    class Leetcode_652
    {
        // 记录所有子树以及出现的次数
        Dictionary<string, int> memo = new Dictionary<string, int>();
        // 记录重复的子树根节点
        IList<TreeNode> res = new List<TreeNode>();
        /// <summary>
        /// 你需要知道以下两点：

        ///1、以我(某一节点)为根的这棵二叉树（子树）长啥样？
        ///其实看到这个问题，就可以判断本题要使用「后序遍历」框架来解决，为什么？很简单呀，我要知道以自己为根的子树长啥样，是不是得先知道我的左右子树长啥样，再加上自己，就构成了整棵子树的样子

        ///2、以其他节点为根的子树都长啥样？二叉树的前序/中序/后序遍历结果可以描述二叉树的结构。
        ///所以，我们可以通过拼接字符串的方式把二叉树序列化
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
        {
            Helper(root);
            return res;
        }
        /// <summary>
        /// 把root为根的子树序列化
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private string Helper(TreeNode root)
        {
            // 对于空节点，可以用一个特殊字符表示
            if (root == null)
                return "#";

            string left = Helper(root.left);
            string right = Helper(root.right);
            // 左右子树加上自己，就是以自己为根的二叉树序列化结果
            string subTree = left + "," + right + "," + root.val;

            int freq = memo.ContainsKey(subTree) ? memo[subTree] : 0;
            if (freq == 1)
                res.Add(root);

            if (memo.ContainsKey(subTree))
                memo[subTree]++;
            else
                memo.Add(subTree, 1);

            return subTree;
        }
    }
}
