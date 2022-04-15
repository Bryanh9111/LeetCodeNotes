using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._2_进阶数据结构._2._2_二叉搜索树._2
{
    class Leetcode_450
    {
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null)
                return null;
            if (root.val == key)
            {
                //found it, delete it

                //make movements:
                //情况 1/2
                if (root.left == null)
                    return root.right;
                if (root.right == null)
                    return root.left;
                //情况 3：A 有两个⼦节点，麻烦了，为了不破坏 BST 的性质，A 必须找到左⼦树中最⼤的那个节点，或者右
                //⼦树中最⼩的那个节点来接替⾃⼰。
                TreeNode minNode = GetMinHelper(root.right);
                // 删除右⼦树最⼩的节点
                root.right = DeleteNode(root.right, minNode.val);
                // ⽤右⼦树最⼩的节点替换 root 节点
                minNode.left = root.left;
                minNode.right = root.right;
                root = minNode;
            }
            else if (root.val > key)// 去左⼦树找
            {
                root.left = DeleteNode(root.left, key);
            }
            else if (root.val < key)// 去右⼦树找
            {
                root.right = DeleteNode(root.right, key);
            }
            return root;
        }

        public TreeNode GetMinHelper(TreeNode root)
        {
            // BST 最左边的就是最⼩的
            while (root.left != null)
                root = root.left;
            return root;
        }


        public TreeNode PseudoCode(TreeNode root, int key)
        {
            if(root.val == key)
            {
                //found it, delete it

                //make movements:
                //情况 1：A 恰好是末端节点，两个⼦节点都为空，那么它可以当场去世了
                if (root.left == null && root.right == null)
                    return null;
                //情况 2：A 只有⼀个⾮空⼦节点，那么它要让这个孩⼦接替⾃⼰的位置
                if (root.left == null)
                    return root.right;
                if (root.right == null)
                    return root.left;
                //情况 3：A 有两个⼦节点，麻烦了，为了不破坏 BST 的性质，A 必须找到左⼦树中最⼤的那个节点，或者右
                //⼦树中最⼩的那个节点来接替⾃⼰。
                if(root.left != null && root.right != null)
                {
                    // 找到右⼦树的最⼩节点
                    TreeNode minNodeRight = GetMinHelper(root.right);
                    // 把 root 改成 minNode
                    root.val = minNodeRight.val;
                    // 转⽽去删除 minNode
                    root.right = PseudoCode(root.right, minNodeRight.val);
                }
            }
            else if(root.val > key)// 去左⼦树找
            {
                root.left = PseudoCode(root.left, key);
            }
            else if(root.val < key)// 去右⼦树找
            {
                root.right = PseudoCode(root.right, key);
            }
            return root;
        }
    }
}
