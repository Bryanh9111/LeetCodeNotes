using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._2_进阶数据结构._2._1_二叉树._2
{
    class Leetcode_654
    {
        /// <summary>
        /// 对于构造⼆叉树的问题，根节点要做的就是把想办法把⾃⼰构造
        /// 出来
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            return Helper(nums, 0, nums.Length - 1);
        }

        private TreeNode Helper(int[] nums, int start, int end)
        {
            // base case
            if (start > end)
                return null;

            int index = -1, maxVal = Int32.MinValue;
            for(int i = start; i <= end; i++)
            {
                if(maxVal < nums[i])
                {
                    index = i;
                    maxVal = nums[i];
                }    
            }
            TreeNode root = new TreeNode(maxVal);

            root.left = Helper(nums, start, index - 1);
            root.right = Helper(nums, index + 1, end);

            return root;
        }
    }
}
