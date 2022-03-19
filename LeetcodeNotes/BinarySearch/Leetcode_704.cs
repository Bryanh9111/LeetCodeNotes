using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.BinarySearch
{
    public partial class Solution
    {
        public int Search(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1; //[left, right]

            while(left <= right) //[2,2]需要搜索, [3,2]停止
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] > target)
                    right = mid - 1;
                else if (nums[mid] < target)
                    left = mid + 1;
            }
            return -1;
        }
    }
}
