using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._4_动态规划._4._4_用动态规划玩游戏._2_团灭_LeetCode_打家劫舍问题
{
    internal class Leetcode_337
    {
        IDictionary<TreeNode, int> memo = new Dictionary<TreeNode, int>();
        public int Rob(TreeNode root)
        {
            if (root == null)
                return 0;
            if (memo.ContainsKey(root))
                return memo[root];

            // 抢，然后去下下家
            int do_it = root.val
                + (root.left != null ? Rob(root.left.left) + Rob(root.left.right) : 0)
                + (root.right != null ? Rob(root.right.left) + Rob(root.right.right) : 0);
            // 不抢，然后去下家
            int not_do = Rob(root.left) + Rob(root.right);

            int res = Math.Max(do_it, not_do);
            memo.Add(root, res);
            return res;
        }
    }
    internal class Leetcode_337_better
    {
        public int Rob(TreeNode root)
        {
            int[] res = dp(root);
            return Math.Max(res[0], res[1]);
        }
        /* 返回一个大小为 2 的数组 arr
        arr[0] 表示不抢 root 的话，得到的最大钱数
        arr[1] 表示抢 root 的话，得到的最大钱数 */
        public int[] dp(TreeNode root)
        {
            if (root == null)
                return new int[] { 0, 0 };
            int[] left = dp(root.left);
            int[] right = dp(root.right);

            // 抢，下家就不能抢了
            int rob = root.val + left[0] + right[0];
            // 不抢，下家可抢可不抢，取决于收益大小
            int not_rob = Math.Max(left[0], left[1])
                        + Math.Max(right[0], right[1]);

            return new int[] { not_rob, rob };
        }
    }
}
