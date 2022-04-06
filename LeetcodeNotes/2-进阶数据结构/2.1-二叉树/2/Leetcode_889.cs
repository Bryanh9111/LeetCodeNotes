using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._2_进阶数据结构._2._1_二叉树._2
{
    class Leetcode_889
    {
        public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder)
        {
            return Helper(preorder, 0, preorder.Length - 1, postorder, 0, postorder.Length - 1);
        }

        private TreeNode Helper(int[] preorder, int preStart, int preEnd, int[] postorder, int postStart, int postEnd)
        {
            if (preStart > preEnd)
                return null;
            if (preStart == preEnd)
            {
                return new TreeNode(preorder[preStart]);
            }

            int rootVal = preorder[preStart];
            // root.left 的值是前序遍历第⼆个元素
            // 通过前序和后序遍历构造⼆叉树的关键在于通过左⼦树的根节点
            // 确定 preorder 和 postorder 中左右⼦树的元素区间
            int leftRootVal = preorder[preStart + 1];

            int index = 0;
            for(int i = postStart; i <= postEnd; i++)
            {
                if(postorder[i] == leftRootVal)
                {
                    index = i;
                    break;
                }
            }
            // 左⼦树的元素个数
            int leftsize = index - postStart + 1;

            TreeNode root = new TreeNode(rootVal);
            root.left = Helper(preorder, preStart + 1, preStart + leftsize, postorder, postStart, index);
            root.right = Helper(preorder, preStart + leftsize + 1, preEnd, postorder, index + 1, postEnd - 1);
            return root;
        }
    }
}
