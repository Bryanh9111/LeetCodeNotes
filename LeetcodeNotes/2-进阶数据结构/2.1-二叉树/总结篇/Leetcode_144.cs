using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._2_进阶数据结构._2._1_二叉树.总结篇
{
    class Leetcode_144
    {
        IList<int> lst = new List<int>();
        public IList<int> PreorderTraversal(TreeNode root)
        {
            Helper(root);
            return lst;
        }
        public void Helper(TreeNode root)
        {
            if (root == null)
                return;

            lst.Add(root.val);
            Helper(root.left);
            Helper(root.right);
        }

        public IList<int> PreorderTraversal2(TreeNode root)
        {
            List<int> lst = new List<int>();
            if (root == null)
                return lst;

            lst.Add(root.val);
            lst.AddRange(PreorderTraversal2(root.left));
            lst.AddRange(PreorderTraversal2(root.right));
            return (IList<int>)lst;
        }
    }
}
