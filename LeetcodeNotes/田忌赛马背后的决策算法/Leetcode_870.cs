using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNotes.田忌赛马背后的决策算法
{
    public class DIC
    {
        public int index;
        public int number;
    }
    public partial class Solution
    {
        //time limit exceeds
        public int[] AdvantageCount(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            IDictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < nums2.Length; i++)
                dic.Add(i, nums2[i]);

            dic = dic.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            int[] res = new int[nums1.Length];
            int left = 0, right = nums1.Length - 1;
            int res_index = nums1.Length - 1; 
            while (left <= right)
            {
                if (nums1[right] > dic.ElementAt(right - left).Value)
                    res[dic.ElementAt(right - left).Key] = nums1[right--];
                else
                {
                    res[dic.ElementAt(right - left).Key] = nums1[left++];
                }
            }
            return res;
        }
        /// <summary>
        /// 过了 O(NlogN), 空间换时间，字典存储比arry慢很多
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] AdvantageCount_modify(int[] nums1, int[] nums2)
        {
            int n = nums1.Length;
            Array.Sort(nums1);
            DIC[] dic = new DIC[n];
            for (int i = 0; i < nums2.Length; i++)
            {
                dic[i] = new DIC() { index = i, number = nums2[i] };
            }
            dic = dic.OrderBy(d => d.number).ToArray();

            int[] res = new int[nums1.Length];
            int left = 0, right = nums1.Length - 1;
            int res_index = nums1.Length - 1;
            while (left <= right)
            {
                if (nums1[right] > dic[right - left].number)
                    res[dic[right - left].index] = nums1[right--];
                else
                {
                    res[dic[right - left].index] = nums1[left++];
                }
            }
            return res;
        }
    }
}
