using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.单调栈
{
    class Leetcode_496
    {
        /// <summary>
        /// TC: O(N)  SC:O(N)
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            IDictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < nums1.Length; i++)
                dic.Add(nums1[i], i);

            var temp = NextGreaterElementBase(nums2);
            int[] res = new int[nums1.Length];
            for (int i = 0; i < nums2.Length; i++)
            {
                if (dic.ContainsKey(nums2[i]))
                    res[dic[nums2[i]]] = temp[i];
            }
            return res;
        }
        /// <summary>
        /// 分析它的时间复杂度，要从整体来看：总共有 n 个元素，每个元素都被 push ⼊栈了⼀次，⽽最多会被 pop
        ///⼀次，没有任何冗余操作。所以总的计算规模是和元素规模 n 成正⽐的，也就是 O(n) 的复杂度。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] NextGreaterElementBase(int[] nums)
        {
            int[] res = new int[nums.Length];
            Stack<int> st = new Stack<int>();
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                while (st.Count > 0 && st.Peek() <= nums[i])
                    st.Pop();

                res[i] = st.Count == 0 ? -1 : st.Peek();
                st.Push(nums[i]);
            }
            return res;
        }
    }
}
