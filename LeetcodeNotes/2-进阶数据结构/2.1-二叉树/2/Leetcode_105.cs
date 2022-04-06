using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._2_进阶数据结构._2._1_二叉树._2
{
    class Leetcode_105
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            return Helper(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1);
        }

        private TreeNode Helper(int[] preorder, int preStart, int preEnd, int[] inorder, int inStart, int inEnd)
        {
            if (preStart > preEnd)
                return null;
            // root 节点对应的值就是前序遍历数组的第⼀个元素
            int rootVal = preorder[preStart];
            // rootVal 在中序遍历数组中的索引
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
            root.left = Helper(preorder, preStart +  1, preStart + leftsize , inorder, inStart, index - 1);
            root.right = Helper(preorder, preStart +  leftsize + 1, preEnd , inorder, index + 1, inEnd);

            return root;
        }
    }
}
