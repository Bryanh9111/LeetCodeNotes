using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._2_进阶数据结构._2._2_二叉搜索树
{
    class Leetcode_538
    {
        int sum = 0;
        public TreeNode ConvertBST(TreeNode root)
        {
            Helper(root);
            return root;
        }
        public void Helper(TreeNode root)
        {
            if (root == null)
                return;
            //这样可以降序排列
            Helper(root.right);

            sum += root.val;
            root.val = sum;

            Helper(root.left);
        }
    }
}
