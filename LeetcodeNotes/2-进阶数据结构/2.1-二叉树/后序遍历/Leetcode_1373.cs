using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._2_进阶数据结构._2._1_二叉树.后序遍历
{
    /// <summary>
    /// 如果当前节点要做的事情需要通过左右⼦树的计算结果推导出来，就要⽤到后序遍历。
    /// </summary>
    class Leetcode_1373
    {
        int maxSum = 0;
        public int MaxSumBST(TreeNode root)
        {
            Helper_post(root);
            return maxSum;
        }
        /// <summary>
        /// 只要把前序遍历变成后序遍历，让 Helper_post 函数把辅助函数做的事情顺便做掉
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int[] Helper_post(TreeNode root)
        {
            if (root == null)
                return new int[] { 1, Int32.MaxValue, Int32.MinValue, 0 };

            int[] left = Helper_post(root.left);
            int[] right = Helper_post(root.right);

            int[] res = new int[4];
            // 这个 if 在判断以 root 为根的⼆叉树是不是 BST
            if (left[0] == 1 && right[0] == 1 && root.val > left[2] && root.val < right[1])
            {
                res[0] = 1;// 以 root 为根的⼆叉树是 BST
                res[1] = Math.Min(left[1], root.val);// 计算以 root 为根的这棵 BST 的最⼩值
                res[2] = Math.Max(right[2], root.val);// 计算以 root 为根的这棵 BST 的最⼤值
                res[3] = left[3] + right[3] + root.val;// 计算以 root 为根的这棵 BST 所有节点之和

                maxSum = Math.Max(maxSum, res[3]);
            }
            else
                res[0] = 0;// 其他的值都没必要计算了，因为⽤不到

            return res;
        }
    }

    class Pseudocode
    {
        // 全局变量，记录 BST 最⼤节点之和
        int maxSum = 0;

        public int MaxSumBST(TreeNode root)
        {
            Helper(root);
            return maxSum;
        }
        /// <summary>
        /// 前序遍历的辅助函数，时间复杂度高，递归里面套递归
        /// </summary>
        /// <param name="root"></param>
        public void Helper(TreeNode root)
        {
            if (root == null)
                return;

            /******* 前序遍历位置 *******/
            // 判断左右⼦树是不是 BST
            if (!isBST(root.left) || !isBST(root.right))
            {
                //go to next
            }
            // 计算左⼦树的最⼤值和右⼦树的最⼩值
            int leftMax = findMax(root.left);
            int rightMin = findMin(root.right);

            // 判断以 root 节点为根的树是不是 BST            if(root.val <= leftMax || root.val >= rightMin)
            {
                //go to next
            }

            // 条件都符合，计算当前 BST 的节点之和
            int leftSum = getSum(root.left);
            int rightSum = getSum(root.right);
            int rootSum = leftSum + rightSum + root.val;
            maxSum = Math.Max(maxSum, rootSum);

            // 递归左右⼦树
            Helper(root.left);
            Helper(root.right);
        }

        int findMax(TreeNode root)
        {
            return -1;
        }
        int findMin(TreeNode root)
        {
            return -1;
        }
        int getSum(TreeNode root)
        {
            return -1;
        }
        bool isBST(TreeNode root)
        {
            return true;
        }


        /// <summary>
        /// 只要把前序遍历变成后序遍历，让 Helper_post 函数把辅助函数做的事情顺便做掉，O(N)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int[] Helper_post(TreeNode root)
        {
            if (root == null)
                return new int[] { 1, Int32.MaxValue, Int32.MinValue, 0 };

            int[] left = Helper_post(root.left);
            int[] right = Helper_post(root.right);

            /******* 后序遍历位置 *******/
            // 通过 left 和 right 推导返回值
            // 并且正确更新 maxSum 变量
            /**************************/

            //Helper_post(root) 返回⼀个⼤⼩为 4 的 int 数组，我们暂且称它为 res，其中：
            //res[0] 记录以 root 为根的⼆叉树是否是 BST，若为 1 则说明是 BST，若为 0 则说明不是 BST；
            //res[1] 记录以 root 为根的⼆叉树所有节点中的最⼩值；
            //res[2] 记录以 root 为根的⼆叉树所有节点中的最⼤值；
            //res[3] 记录以 root 为根的⼆叉树所有节点值之和。
            int[] res = new int[4];
            // 这个 if 在判断以 root 为根的⼆叉树是不是 BST
            if (left[0] == 1 && right[0] == 1 && root.val > left[2] && root.val < right[1])
            {
                res[0] = 1;// 以 root 为根的⼆叉树是 BST
                res[1] = Math.Min(left[1], root.val);// 计算以 root 为根的这棵 BST 的最⼩值
                res[2] = Math.Max(right[2], root.val);// 计算以 root 为根的这棵 BST 的最⼤值
                res[3] = left[3] + right[3] + root.val;// 计算以 root 为根的这棵 BST 所有节点之和

                maxSum = Math.Max(maxSum, res[3]);
            }
            else
                res[0] = 0;// 其他的值都没必要计算了，因为⽤不到

            return res;
        }
    }
}
