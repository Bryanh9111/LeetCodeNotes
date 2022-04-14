using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._2_进阶数据结构._2._1_二叉树.二叉树序列化
{
    public class Leetcode_297_lvl
    {
        string separator = ",";
        string nullVal = "#";
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            if (root == null) return string.Empty;
            StringBuilder sb = new StringBuilder();
            // 初始化队列，将 root 加入队列
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            while(q.Count > 0)
            {
                TreeNode current = q.Dequeue();

                /* 层级遍历代码位置 */
                if (current == null)
                {
                    sb.Append(nullVal).Append(separator);
                    continue;
                }
                sb.Append(current.val).Append(separator);

                q.Enqueue(current.left);
                q.Enqueue(current.right);
            }

            return sb.ToString();
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (string.IsNullOrEmpty(data))
                return null;

            string[] nodes = data.Split(separator);
            TreeNode root = new TreeNode(Convert.ToInt32(nodes[0]));
            // 队列 q 记录父节点，将 root 加入队列
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            for(int i = 1; i < nodes.Length;)
            {
                // 队列中存的都是父节点
                TreeNode parent = q.Dequeue();
                // 父节点对应的左侧子节点的值
                string left = nodes[i++];
                if (!string.Equals(left, nullVal))
                {
                    parent.left = new TreeNode(Convert.ToInt32(left));
                    q.Enqueue(parent.left);
                }
                else
                    parent.left = null;

                string right = nodes[i++];
                if (!string.Equals(right, nullVal))
                {
                    parent.right = new TreeNode(Convert.ToInt32(right));
                    q.Enqueue(parent.right);
                }
                else
                    parent.right = null;
            }
            return root;
        }
        /// <summary>
        /// 层级遍历框架
        /// </summary>
        /// <param name="root"></param>
        void Traverse(TreeNode root)
        {
            if (root == null)
                return;

            // 初始化队列，将 root 加入队列
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            while(q.Count > 0)
            {
                TreeNode current = q.Dequeue();

                /* 层级遍历代码位置 */
                Console.WriteLine(root.val.ToString());
                /*****************/

                if (current.left != null)
                    q.Enqueue(current.left);

                if (current.right != null)
                    q.Enqueue(current.right);
            }
        }
    }
}
