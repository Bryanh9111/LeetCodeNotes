using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._2_进阶数据结构._2._2_二叉搜索树._2
{
    class Leetcode_98
    {
        public bool IsValidBST(TreeNode root)
        {
            return Helper(root, null, null);
        }

        public bool Helper(TreeNode root, TreeNode min, TreeNode max)
        {
            if (root == null)
                return true;
            // 若 root.val 不符合 max 和 min 的限制，说明不是合法 BST
            if (min != null && root.val <= min.val)
                return false;
            if (max != null && root.val >= max.val)
                return false;

            // 限定左⼦树的最⼤值是 root.val，右⼦树的最⼩值是 root.val
            return Helper(root.left, min, root) && Helper(root.right, root, max);
        }
    }
}
