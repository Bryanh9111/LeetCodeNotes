using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._2_进阶数据结构._2._2_二叉搜索树._2
{
    class Leetcode_701
    {
        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            if (root == null)
                return new TreeNode(val);
            if (root.val < val)
                root.right = InsertIntoBST(root.right, val);
            if (root.val > val)
                root.left = InsertIntoBST(root.left, val);

            return root;
        }
    }
}
