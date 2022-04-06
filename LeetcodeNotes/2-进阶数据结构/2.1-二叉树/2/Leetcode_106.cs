using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._2_进阶数据结构._2._1_二叉树._2
{
    class Leetcode_106
    {
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            return Helper(inorder, 0, inorder.Length - 1, postorder, 0, postorder.Length - 1);
        }

        private TreeNode Helper(int[] inorder, int inStart, int inEnd, int[] postorder, int postStart, int postEnd)
        {
            if (postStart > postEnd)
                return null;

            int rootVal = postorder[postEnd];
            int index = 0;
            for(int i = inStart; i <= inEnd; i++)
            {
                if(inorder[i] == rootVal)
                {
                    index = i;
                    break;
                }
            }

            TreeNode root = new TreeNode(rootVal);
            int leftsize = index - inStart;
            root.left = Helper(inorder, inStart, index - 1, postorder, postStart, postStart + leftsize - 1);
            root.right = Helper(inorder, index + 1, inEnd, postorder, postStart + leftsize, postEnd - 1);

            return root;
        }
    }
}
