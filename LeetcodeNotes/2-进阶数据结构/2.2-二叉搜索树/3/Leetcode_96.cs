using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._2_进阶数据结构._2._2_二叉搜索树._3
{
    /// <summary>
    /// Time limit exceedeed
    /// </summary>
    class Leetcode_96
    {
        //左子树的组合数和右子树的组合数乘积就是n作为根节点时的 BST 个数
        public int NumTrees(int n)
        {
            //计算闭区间 [1, n] 组成的 BST 个数
            return Helper(1, n);
        }
        //计算闭区间 [lo, hi] 组成的 BST 个数
        public int Helper(int low, int high)
        {
            //空区间，也就对应着空节点 null，虽然是空节点，但是也是一种情况，所以要返回 1 而不能返回 0
            if (low > high)
                return 1;

            int res = 0;
            for(int i = low; i <= high; i++)
            {
                // i 的值为根节点 root
                int left = Helper(low, i - 1);
                int right = Helper(i + 1, high);
                // 左右子树的组合数乘积是 BST 的总数
                res += left * right;
            }
            return res;
        }
    }

    class Leetcode_96_fast
    {
        int[,] memo;
        //左子树的组合数和右子树的组合数乘积就是n作为根节点时的 BST 个数
        public int NumTrees(int n)
        {
            memo = new int[n + 1, n + 1];
            //计算闭区间 [1, n] 组成的 BST 个数
            return Helper(1, n);
        }
        //计算闭区间 [lo, hi] 组成的 BST 个数
        public int Helper(int low, int high)
        {
            //空区间，也就对应着空节点 null，虽然是空节点，但是也是一种情况，所以要返回 1 而不能返回 0
            if (low > high)
                return 1;

            // 查备忘录
            if (memo[low, high] != 0)
                return memo[low, high];

            int res = 0;
            for (int i = low; i <= high; i++)
            {
                // i 的值为根节点 root
                int left = Helper(low, i - 1);
                int right = Helper(i + 1, high);
                // 左右子树的组合数乘积是 BST 的总数
                res += left * right;
            }
            // 将结果存入备忘录
            memo[low, high] = res;

            return res;
        }
    }
}
