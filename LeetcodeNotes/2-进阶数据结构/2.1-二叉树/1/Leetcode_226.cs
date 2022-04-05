using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._2_进阶数据结构._2._1_二叉树._1
{
    /// <summary>
    /// void traverse(TreeNode root){
    ///     前序遍历
    ///     traverse(root.left);
    ///     中序遍历
    ///     traverse(root.right);
    ///     后序遍历
    /// }
    /// </summary>
    class Leetcode_226
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
                return null;
            TreeNode temp = root.left;
            root.left = root.right;
            root.right = temp;

            InvertTree(root.left);
            InvertTree(root.right);

            return root;
        }
    }
}
