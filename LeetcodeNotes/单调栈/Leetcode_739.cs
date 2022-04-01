using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.单调栈
{
    class Leetcode_739
    {
        /// <summary>
        /// TC: O(N) SC: O(N)
        /// </summary>
        /// <param name="temperatures"></param>
        /// <returns></returns>
        public int[] DailyTemperatures(int[] temperatures)
        {
            int[] res = new int[temperatures.Length];
            Stack<int> st = new Stack<int>();
            for(int i = temperatures.Length - 1; i >= 0; i--)
            {
                while (st.Count > 0 && temperatures[st.Peek()] <= temperatures[i])
                    st.Pop();
                res[i] = st.Count == 0 ? 0 : st.Peek() - i;
                st.Push(i);
            }
            return res;
        }
        /// <summary>
        /// Time Limit Exceeded
        /// </summary>
        /// <param name="temperatures"></param>
        /// <returns></returns>
        public int[] DailyTemperatures_slow(int[] temperatures)
        {
            IDictionary<int, IList<int>> dic = new Dictionary<int, IList<int>>();
            for(int i = 0; i < temperatures.Length; i++)
            {
                if (dic.ContainsKey(temperatures[i]))
                    dic[temperatures[i]].Add(i);
                else
                    dic.Add(temperatures[i], new List<int>() { i });
            }
            var temp = NextGreaterElementBase(temperatures);
            int[] res = new int[temperatures.Length];
            for(int i = 0; i < temperatures.Length; i++)
            {
                if (temp[i] == -1)
                {
                    res[i] = 0;
                    continue;
                }
                foreach(var n in dic[temp[i]])
                {
                    if (n > i)
                    {
                        res[i] = n - i;
                        break;
                    }    
                }
            }
            return res;
        }
        public int[] NextGreaterElementBase(int[] nums)
        {
            int[] res = new int[nums.Length];
            Stack<int> st = new Stack<int>();
            for(int i = nums.Length - 1; i >= 0; i--)
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
