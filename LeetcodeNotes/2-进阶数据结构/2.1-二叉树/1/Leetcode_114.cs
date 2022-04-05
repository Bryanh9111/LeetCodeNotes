using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._2_进阶数据结构._2._1_二叉树._1
{
    /// <summary>
    /// 1、将 root 的左⼦树和右⼦树拉平。
    /// 2、将 root 的右⼦树接到左⼦树下⽅，然后将整个左⼦树作为右⼦树。
    /// </summary>
    public class Leetcode_114
    {
        public void Flatten(TreeNode root)
        {
            if (root == null)
                return;
            Flatten(root.left);
            Flatten(root.right);

            /**** 后序遍历位置 ****/
            // 1、左右⼦树已经被拉平成⼀条链表
            TreeNode left = root.left;
            TreeNode right = root.right;

            // 2、将左⼦树作为右⼦树
            root.left = null;
            root.right = left;

            // 3、将原先的右⼦树接到当前右⼦树(之前的左子树)的末端
            TreeNode p = root;
            while (p.right != null)
                p = p.right;
            p.right = right;
        }
    }
}
