using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._2_进阶数据结构._2._1_二叉树.二叉树序列化
{
    public class Leetcode_297_post
    {
        string separator = ",";
        string nullVal = "#";
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            StringBuilder sb = new StringBuilder();
            Helper_serialize(root, sb);
            return sb.ToString();
        }

        private void Helper_serialize(TreeNode root, StringBuilder sb)
        {
            if (root == null)
            {
                sb.Append(nullVal).Append(separator);
                return;
            }
            Helper_serialize(root.left, sb);
            Helper_serialize(root.right, sb);

            /****** 后序遍历位置 ******/
            sb.Append(root.val).Append(separator);
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            // 将字符串转化成列表
            IList<string> nodes = new List<string>();
            string[] sarry = data.Split(separator);
            for(int i = 0; i < sarry.Length - 1; i++)
                nodes.Add(sarry[i]);
            
            return Helper_deserialize(nodes);
        }
        /// <summary>
        /// 可见，root 的值是列表的最后一个元素。我们应该从后往前取出列表元素，先用最后一个元素构造 root，然后递归调用生成 root 的左右子树。注意，根据上图，从后往前在 nodes 列表中取元素，一定要先构造 root.right 子树，后构造 root.left 子树。
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        private TreeNode Helper_deserialize(IList<string> nodes)
        {
            if (nodes.Count == 0)
                return null;

            // 从后往前取出元素
            string last = nodes[nodes.Count - 1];
            nodes.RemoveAt(nodes.Count - 1);
            if (string.Equals(last, nullVal))
                return null;
            TreeNode root = new TreeNode(Convert.ToInt32(last));
            // 先构造右子树，后构造左子树
            root.right = Helper_deserialize(nodes);
            root.left = Helper_deserialize(nodes);

            return root;
        }
    }
}
