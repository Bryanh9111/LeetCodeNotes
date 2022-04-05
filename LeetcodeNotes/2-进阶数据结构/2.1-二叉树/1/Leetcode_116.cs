using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._2_进阶数据结构._2._1_二叉树._1
{
    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            left = _left;
            right = _right;
            next = _next;
        }
    }
    /// <summary>
    /// ⼆叉树的问题难点在于，如何把题⽬的要求细化成每个节点需要做的事情, 如果一个节点做不到，就增加函数参数
    /// </summary>
    class Leetcode_116
    {
        public Node Connect(Node root)
        {
            if (root == null)
                return root;
            Helper(root.left, root.right);
            return root;
        }

        private void Helper(Node node1, Node node2)
        {
            if (node1 == null || node2 == null)
                return;
            node1.next = node2;// 将传⼊的两个节点连接

            // 连接相同⽗节点的两个⼦节点
            Helper(node1.left, node1.right);
            Helper(node2.left, node2.right);
            // 连接跨越⽗节点的两个⼦节点
            Helper(node1.right, node2.left);
        }
    }
}
