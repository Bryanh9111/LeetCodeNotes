using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._2_进阶数据结构._2._1_二叉树.二叉树序列化
{
    public class Leetcode_297_pre
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
            if(root == null)
            {
                sb.Append(nullVal).Append(separator);
                return;
            }
            /****** 前序遍历位置 ******/
            sb.Append(root.val).Append(separator);

            Helper_serialize(root.left, sb);
            Helper_serialize(root.right, sb);
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            // 将字符串转化成列表
            IList<string> nodes = new List<string>();
            foreach (var s in data.Split(separator))
                nodes.Add(s);
            return Helper_deserialize(nodes);
        }

        private TreeNode Helper_deserialize(IList<string> nodes)
        {
            if (nodes.Count == 0)
                return null;

            /****** 前序遍历位置 ******/
            // 列表最左侧就是根节点
            string first = nodes[0];
            nodes.RemoveAt(0);
            if (string.Equals(first, nullVal))
                return null;
            TreeNode root = new TreeNode(Convert.ToInt32(first));

            root.left = Helper_deserialize(nodes);
            root.right = Helper_deserialize(nodes);

            return root;
        }
    }
}
