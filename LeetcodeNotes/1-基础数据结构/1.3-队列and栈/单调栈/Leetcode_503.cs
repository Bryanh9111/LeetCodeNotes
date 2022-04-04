using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.单调栈
{
    class Leetcode_503
    {
        /// <summary>
        /// 解法一： 长度翻倍数组
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] NextGreaterElements(int[] nums)
        {
            int[] res = new int[nums.Length];
            Stack<int> st = new Stack<int>();

            int[] new_nums = new int[nums.Length * 2];
            for (int i = 0; i < nums.Length; i++)
            {
                new_nums[i] = nums[i];
                new_nums[i + nums.Length] = nums[i];
            }

            for(int i = new_nums.Length - 1; i >= 0; i--)
            {
                while (st.Count > 0 && st.Peek() <= new_nums[i])
                    st.Pop();
                if(i < nums.Length)
                {
                    res[i] = st.Count == 0 ? -1 : st.Peek();
                }
                st.Push(new_nums[i]);
            }
            return res;
        }
        /// <summary>
        /// 数组环形特效
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="circle_n"></param>
        /// <returns></returns>
        public int[] circleArry(int[] arr, int circle_n)
        {
            int n = arr.Length;
            int limit = n * circle_n;
            int index = 0;
            int[] res = new int[arr.Length * circle_n];
            while(index < limit)
            {
                var temp = index % n;
                res[index] = arr[temp];
                index++;
            }
            return res;
        }
        /// <summary>
        /// 快很多
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] NextGreaterElements_circle(int[] nums)
        {
            int n = nums.Length;
            int[] res = new int[n];
            Stack<int> st = new Stack<int>();

            for(int i = 2 * n - 1; i >= 0; i--)
            {
                while (st.Count > 0 && st.Peek() <= nums[i % n])
                    st.Pop();
                res[i % n] = st.Count == 0 ? -1 : st.Peek();
                st.Push(nums[i % n]);
            }
            return res;
        }
    }
}
