using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._2_进阶数据结构._2._2_二叉搜索树
{
    class Leetcode_230
    {
        int res = 0;
        int rank = 0;
        public int KthSmallest(TreeNode root, int k)
        {
            Helper(root, k);
            return res;
        }
        public void Helper(TreeNode root, int k)
        {
            if (root == null)
                return;

            Helper(root.left, k);

            rank++;
            if(rank == k)
            {
                res = root.val;
                return;
            }

            Helper(root.right, k);
        }
    }
}
