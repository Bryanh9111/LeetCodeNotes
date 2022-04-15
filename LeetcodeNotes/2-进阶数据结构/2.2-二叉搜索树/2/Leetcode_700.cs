using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._2_进阶数据结构._2._2_二叉搜索树._2
{
    class Leetcode_700
    {
        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null)
                return null;

            if (root.val == val)
                return root;
            else if (root.val > val)
                return SearchBST(root.left, val);
            else if (root.val < val)
                return SearchBST(root.right, val);

            return null;
        }
    }
}
