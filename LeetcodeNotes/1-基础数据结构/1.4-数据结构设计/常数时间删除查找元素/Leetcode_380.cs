using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.常数时间删除查找元素
{
    public class RandomizedSet
    {
        private List<int> nums;// 存储元素的值，取元素O(1)，删除最后一个元素O(1)
        private Dictionary<int, int> valToIndex; // 记录每个元素对应在 nums 中的索引,用来交换元素到列表最后
        public RandomizedSet()
        {
            nums = new List<int>();
            valToIndex = new Dictionary<int, int>();
        }
        private void Swap(int index1, int index2)
        {
            int temp = nums[index1];
            nums[index1] = nums[index2];
            nums[index2] = temp;
        }
        public bool Insert(int val)
        {
            if (valToIndex.ContainsKey(val))
                return false;// 若 val 已存在，不⽤再插⼊
            valToIndex.Add(val, nums.Count);
            nums.Add(val);
            return true;
        }

        public bool Remove(int val)
        {
            if (!valToIndex.ContainsKey(val))
                return false;

            int index = valToIndex[val];// 先拿到 val 的索引
            int last_index = nums.Count - 1;
            valToIndex[nums[last_index]] = index; // 将最后⼀个元素对应的索引修改为 index
            valToIndex.Remove(val);// 删除元素 val 对应的索引
            Swap(index, last_index);// 交换 val 和最后⼀个元素
            nums.RemoveAt(last_index);// 在数组中删除元素 val
            return true;
        }

        public int GetRandom()
        {
            return nums[new Random().Next(0, int.MaxValue) % nums.Count];
        }
    }
}
