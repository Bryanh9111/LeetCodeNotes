using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNotes._3_暴_搜索算法._3._1_DFS._2_集合划分问题
{
    /// <summary>
    /// time limit exceeded-以数字的视角
    /// </summary>
    internal class Leetcode_698
    {
        public bool CanPartitionKSubsets(int[] nums, int k)
        {
            // 排除⼀些基本情况
            if (k > nums.Length)
                return false;
            int sum = nums.Sum();
            if (sum % k != 0)
                return false;

            // k 个桶（集合），记录每个桶装的数字之和
            int[] bucket = new int[k];
            return Helper(nums, 0, bucket, sum / k);
        }
        // 递归穷举 nums 中的每个数字
        public bool Helper(int[] nums, int index, int[] bucket, int target)
        {
            if(index == nums.Length)
            {
                // 检查所有桶的数字之和是否都是 target
                for (int i = 0; i < bucket.Length; i++)
                {
                    if (bucket[i] != target)
                        return false;
                }
                // nums 成功平分成 k 个⼦集
                return true;
            }
            // 穷举 nums[index] 可能装⼊的桶
            for (int i = 0; i < bucket.Length; i++)
            {
                // 剪枝，桶装装满了
                if (bucket[i] + nums[index] > target)
                    continue;

                // 将 nums[index] 装⼊ bucket[i]
                bucket[i] += nums[index];
                // 递归穷举下⼀个数字的选择
                if (Helper(nums, index + 1, bucket, target))
                    return true;
                // 撤销选择
                bucket[i] -= nums[index];
            }
            // nums[index] 装⼊哪个桶都不⾏
            return false;
        }
    }
    /// <summary>
    /// time limit exceeded-以数字的视角
    /// </summary>
    internal class Leetcode_698_fast
    {
        public bool CanPartitionKSubsets(int[] nums, int k)
        {
            // 排除⼀些基本情况
            if (k > nums.Length)
                return false;
            int sum = nums.Sum();
            if (sum % k != 0)
                return false;

            // k 个桶（集合），记录每个桶装的数字之和
            int[] bucket = new int[k];

            /* 降序排序 nums 数组 */
            Array.Sort(nums);
            for (int i = 0, j = nums.Length - 1; i < j; i++, j--)
            {
                // 交换 nums[i] 和 nums[j]
                int temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
            }

            return Helper(nums, 0, bucket, sum / k);
        }
        // 递归穷举 nums 中的每个数字
        public bool Helper(int[] nums, int index, int[] bucket, int target)
        {
            if (index == nums.Length)
            {
                // 检查所有桶的数字之和是否都是 target
                for (int i = 0; i < bucket.Length; i++)
                {
                    if (bucket[i] != target)
                        return false;
                }
                // nums 成功平分成 k 个⼦集
                return true;
            }
            // 穷举 nums[index] 可能装⼊的桶
            for (int i = 0; i < bucket.Length; i++)
            {
                // 剪枝，桶装装满了
                if (bucket[i] + nums[index] > target)
                    continue;

                // 将 nums[index] 装⼊ bucket[i]
                bucket[i] += nums[index];
                // 递归穷举下⼀个数字的选择
                if (Helper(nums, index + 1, bucket, target))
                    return true;
                // 撤销选择
                bucket[i] -= nums[index];
            }
            // nums[index] 装⼊哪个桶都不⾏
            return false;
        }
    }
    /// <summary>
    /// 以桶的视角-慢
    /// </summary>
    internal class Leetcode_698_bucket
    {
        //// 装满所有桶为⽌
        //while (k > 0) {
        // // 记录当前桶中的数字之和
            // int bucket = 0;
            // for (int i = 0; i<nums.length; i++) {
            // // 决定是否将 nums[i] 放⼊当前桶中
            // bucket += nums[i] or 0;
            // if (bucket == target) {
            // // 装满了⼀个桶，装下⼀个桶
            // k--;
            // break;
            // }
            //}
        //}

        public bool CanPartitionKSubsets(int[] nums, int k)
        {
            // 排除⼀些基本情况
            if (k > nums.Length)
                return false;
            int sum = nums.Sum();
            if (sum % k != 0)
                return false;

            return Helper(k, 0, nums, 0, new bool[nums.Length], sum / k);
        }
        // 递归穷举 nums 中的每个数字
        public bool Helper(int k, int bucket, int[] nums, int start, bool[] used, int target)
        {
            // base case
            // 所有桶都被装满了，⽽且 nums ⼀定全部⽤完了
            // 因为 target == sum / k
            if (k == 0)
                return true;
            if(bucket == target)
            {
                // 装满了当前桶，递归穷举下⼀个桶的选择
                // 让下⼀个桶从 nums[0] 开始选数字
                return Helper(k - 1, 0, nums, 0, used, target);
            }
            // 从 start 开始向后探查有效的 nums[i] 装⼊当前桶
            for (int i = start; i < nums.Length; i++)
            {
                // 剪枝
                // nums[i] 已经被装⼊别的桶中
                if (used[i])
                    continue;
                // 当前桶装不下 nums[i]
                if (nums[i] + bucket > target)
                    continue;
                // 做选择，将 nums[i] 装⼊当前桶中
                used[i] = true;
                bucket += nums[i];
                // 递归穷举下⼀个数字是否装⼊当前桶
                if (Helper(k, bucket, nums, i + 1, used, target))
                    return true;
                used[i] = false;
                bucket -= nums[i];
            }
            return false;
        }
    }
    /// <summary>
    /// 以桶的视角-快
    /// </summary>
    internal class Leetcode_698_bucket_fast
    {
        IDictionary<String, bool> memo = new Dictionary<string, bool>();
        public bool CanPartitionKSubsets(int[] nums, int k)
        {
            // 排除⼀些基本情况
            if (k > nums.Length)
                return false;
            int sum = nums.Sum();
            if (sum % k != 0)
                return false;

            return Helper(k, 0, nums, 0, new bool[nums.Length], sum / k);
        }
        // 递归穷举 nums 中的每个数字
        public bool Helper(int k, int bucket, int[] nums, int start, bool[] used, int target)
        {
            // base case
            // 所有桶都被装满了，⽽且 nums ⼀定全部⽤完了
            // 因为 target == sum / k
            if (k == 0)
                return true;

            // 将 used 的状态转化成形如 [true, false, ...] 的字符串
            // 便于存⼊ HashMap
            StringBuilder statesb = new StringBuilder();
            foreach (var b in used)
                statesb.Append(b);
            string state = statesb.ToString();

            if (bucket == target)
            {
                // 装满了当前桶，递归穷举下⼀个桶的选择
                bool res = Helper(k - 1, 0, nums, 0, used, target);
                // 将当前状态和结果存⼊备忘录
                if (memo.ContainsKey(state))
                    memo[state] = res;
                else
                    memo.Add(state, res);

                return res;
            }
            // 如果当前状态曾今计算过，就直接返回，不要再递归穷举了
            if (memo.ContainsKey(state))
                return memo[state];

            // 从 start 开始向后探查有效的 nums[i] 装⼊当前桶
            for (int i = start; i < nums.Length; i++)
            {
                // 剪枝
                // nums[i] 已经被装⼊别的桶中
                if (used[i])
                    continue;
                // 当前桶装不下 nums[i]
                if (nums[i] + bucket > target)
                    continue;
                // 做选择，将 nums[i] 装⼊当前桶中
                used[i] = true;
                bucket += nums[i];
                // 递归穷举下⼀个数字是否装⼊当前桶
                if (Helper(k, bucket, nums, i + 1, used, target))
                    return true;
                used[i] = false;
                bucket -= nums[i];
            }
            return false;
        }
    }
}
