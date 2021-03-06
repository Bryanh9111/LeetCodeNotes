using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.DifferencialArray
{
    public class Leetcode_370
    {
        /// <summary>
        /// Use O(1) to update diff array instead of O(N) each time
        /// </summary>
        /// <param name="length"></param>
        /// <param name="updates"></param>
        /// <returns></returns>
        public int[] GetModifiedArray(int length, int[][] updates)
        {
            //create the diff array
            int[] arr = new int[length];
            int[] diff = new int[length];
            diff[0] = arr[0];
            for (int i = 1; i < length; i++)
                diff[i] = arr[i] - arr[i - 1];

            //update the diff
            foreach(var update in updates)
            {
                diff[update[0]] += update[2];
                if (update[1] < diff.Length - 1)
                    diff[update[1] + 1] -= update[2];
            }

            //get the original array from diff array
            arr[0] = diff[0];
            for (int i = 1; i < diff.Length; i++)
                arr[i] = arr[i - 1] + diff[i]; 

            return arr;
        }
        /// <summary>
        /// time limit exceeded
        /// </summary>
        /// <param name="length"></param>
        /// <param name="updates"></param>
        /// <returns></returns>
        public int[] GetModifiedArray_Slow(int length, int[][] updates)
        {
            int[] arr = new int[length];
            foreach(var update in updates)
            {
                for (int i = update[0]; i <= update[1]; i++)
                    arr[i] += update[2];
            }
            return arr;
        }
    }
    /// <summary>
    /// general class implementation
    /// </summary>
    public class Difference
    {
        private int[] diff;

        public Difference(int[] nums)
        {
            if(nums != null && nums.Length >= 0)
            {
                diff = new int[nums.Length];
                diff[0] = nums[0];
                for (int i = 1; i < nums.Length; i++)
                    diff[i] = nums[i] - nums[i - 1];
            }
        }

        public void Increment(int i, int j, int val)
        {
            diff[i] += val;
            if (j < diff.Length - 1)
                diff[j + 1] -= val;
        }

        public int[] Result()
        {
            int[] res = new int[diff.Length];
            res[0] = diff[0];
            for (int i = 1; i < diff.Length; i++)
                res[i] = res[i - 1] + diff[i];
            return res;
        }
    }
}
